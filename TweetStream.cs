/*
 * Modified from the Stream class in Tweetinvi
 * Couldn't seem to get it to populate tweets correctly so did it myself.
 * Also added BackgroundWorker so it runs on its own thread
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using TweetinCore.Enum;
using TweetinCore.Interfaces;
using Tweetinvi;
using Tweetinvi.Utils;

namespace ShoeGrab
{
    class TweetStream
    {

        #region Delegates
        /// <summary>
        /// Sends a Tweet each time it gets one from Stream
        /// </summary>
        /// <param name="tweet">The Tweet</param>
        /// <param name="force">
        /// Allows you to know whether you want to continue the delegate execution if the Tweet should not
        /// correspond to what you expect -> null for example
        /// </param>
        public delegate void ProcessTweetDelegate(Tweet tweet, bool force);
        private ProcessTweetDelegate _processTweetDelegate;
        public ProcessTweetDelegate processTweetDelegate
        {
            get { return _processTweetDelegate; }
            set { _processTweetDelegate = value; }
        }

        // Future implementation
        //public delegate void DayProcessedDelegate(int day_number, int nb_tweets);
        //public DayProcessedDelegate _dayProcessedDelegate;
        #endregion

        #region Private Attributes
        private StreamState _state;
        private bool _isRunning = false;
        private string _streamUrl = "https://stream.twitter.com/1.1/statuses/sample.json";
        private BackgroundWorker bw = new BackgroundWorker();
        #endregion

        #region Public Attributes
        /// <summary>
        /// Address of the Streaming API
        /// </summary>
        public string StreamUrl
        {
            get { return _streamUrl; }
            set
            {
                if (_streamUrl != value)
                {
                    _streamUrl = value;
                }
            }
        }

        /// <summary>
        /// Define whether the stream should keep reading or not.
        /// It also implies that if the stream is already reading it cannot start again.
        /// </summary>
        public StreamState state
        {
            get { return _state; }
            set
            {
                if (_state != value)
                {
                    _state = value;
                    _isRunning = _state == StreamState.Resume || _state == StreamState.Pause;
                }
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public TweetStream() { }

        /// <summary>
        /// Constructor defining the delegate used each time a Tweet is retrieved from the Streaming API
        /// </summary>
        /// <param name="processTweetDelegate">Delegate function that will handle each Tweet</param>
        public TweetStream(ProcessTweetDelegate processTweetDelegate)
            : this()
        {
            _processTweetDelegate = processTweetDelegate;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Init a Stream
        /// </summary>
        /// <param name="webRequest">WebRequest to connect to streaming API</param>
        /// <returns>The stream connected to Twitter Streaming API</returns>
        private static StreamReader init_webRequest(WebRequest webRequest)
        {
            StreamReader reader = null;
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            try
            {
                reader = new StreamReader(webResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8"));
            }
            catch (ArgumentException ex)
            {
                if (ex.Message == "Stream was not readable.")
                {
                    webRequest.Abort();
                    // Modified by Linvi
                }
                else
                    throw ex;
            }

            return reader;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Method to start a stream from a Token
        /// </summary>
        /// <param name="token">Token to get the credentials to query the stream</param>
        public void StartStream(IToken token)
        {
            if (bw.IsBusy)
            {
                throw new OperationCanceledException("You cannot run the stream multiple times");
            }

            bw.DoWork += new DoWorkEventHandler(delegate(object o, DoWorkEventArgs args)
            {
                checkStream(token);
            });

            bw.RunWorkerAsync();
        }
        #endregion

        private void checkStream(IToken token)
        {
            #region Variables
            long todayTicks = DateTime.Now.Ticks;
            DateTime init = new DateTime(todayTicks - todayTicks % TimeSpan.TicksPerDay + 1);

            state = StreamState.Resume;
            HttpWebRequest webRequest = token.GetQueryWebRequest(StreamUrl, HttpMethod.GET);
            StreamReader reader = init_webRequest(webRequest);

            string jsonTweet = "";
            int error_occured = 0;
            #endregion

            while (state != StreamState.Stop)
            {
                try
                {
                    if (reader != null)
                        jsonTweet = reader.ReadLine();

                    #region Error Checking

                    if (string.IsNullOrEmpty(jsonTweet))
                    {
                        if (error_occured == 0)
                        {
                            ++error_occured;
                        }
                        else if (error_occured == 1)
                        {
                            ++error_occured;
                            webRequest.Abort();
                            reader = init_webRequest(webRequest);
                        }
                        else if (error_occured == 2)
                        {
                            ++error_occured;
                            webRequest.Abort();
                            webRequest = token.GetQueryWebRequest(StreamUrl, HttpMethod.GET);
                            reader = init_webRequest(webRequest);
                        }
                        else
                        {
                            Console.WriteLine("Twitter API is not accessible");
                            Trace.WriteLine("Twitter API is not accessible");
                            break;
                        }
                    }
                    else if (error_occured != 0)
                    {
                        error_occured = 0;
                    }

                    #endregion

                    // Create a new optimized tweet

                    JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                    dynamic result = jsSerializer.Deserialize<dynamic>(jsonTweet);

                    if (result is object[])
                    {
                        object[] temp = (jsSerializer.Deserialize<dynamic>(jsonTweet) as object[]);

                        if (temp != null)
                        {
                            result = temp.OfType<Dictionary<string, object>>().ToArray();
                        }
                    }

                    if (result is Dictionary<string, object>)
                    {

                        Dictionary<string, object> tweetData = result as Dictionary<string, object>;

                        if (tweetData.ContainsKey("id"))
                        {

                            Tweet tweet = new Tweet(result, null, false);

                            if (processTweetDelegate != null)
                            {
                                processTweetDelegate(tweet, false);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Non-tweet data");
                            continue;
                        }
                    }
                }
                catch (IOException ex)
                {
                    // Verify the implementation of the Exception handler
                    #region IOException Handler
                    if (ex.Message == "Unable to read data from the transport connection: The connection was closed.")
                        reader = init_webRequest(webRequest);

                    try
                    {
                        jsonTweet = reader.ReadLine();
                    }
                    catch (IOException ex2)
                    {
                        if (ex2.Message == "Unable to read data from the transport connection: The connection was closed.")
                        {
                            Trace.WriteLine("Streamreader was unable to read from the stream!");
                            if (processTweetDelegate != null)
                                processTweetDelegate(null, true);
                            break;
                        }
                    }
                    #endregion
                }
            }

            #region Clean
            webRequest.Abort();
            reader.Dispose();
            state = StreamState.Stop;
            #endregion
        }


    }
}
