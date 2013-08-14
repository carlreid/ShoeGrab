using CefSharp;
using CefSharp.WinForms;
using oAuthConnection;
using Rhino.Licensing;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using TweetinCore.Enum;
using TweetinCore.Interfaces;
using Tweetinvi;
using TwitterToken;

namespace ShoeGrab
{
    public partial class mainForm : MetroFramework.Forms.MetroForm
    {
        int _tweetsChecked = 0;
        IToken _token;
        //IUser _user = null;
        TweetStream _tStream;
        LookSettings _lookSettings;
        KeyWordManager _keywordManager;
        WebView webView;
        TokenUser _user = null;
        OCRSolver _ocrSolver = null;

        string _userEmail = null;
        int _accessLevel = -1;

        //float delayer = 0;

        string _publicKey = null;

        public mainForm(string twitterAuth, string twitterAuthSecret, string userEmail, int accessLevel)
        {
            InitializeComponent();

            _ocrSolver = new OCRSolver();

            if (!File.Exists("publicKey.xml"))
            {
                MessageBox.Show("Missing data, please redownload the application.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                _publicKey = File.ReadAllText("publicKey.xml");
            }

            _userEmail = userEmail;
            _accessLevel = accessLevel;

            //Setup the webView and Settings
            // Disable caching.
            //Useful: https://github.com/cefsharp/CefSharp/wiki/Frequently-asked-questions
            BrowserSettings settings = new BrowserSettings();
            settings.ApplicationCacheDisabled = true;
            settings.PageCacheDisabled = true;
            settings.DeveloperToolsDisabled = true;

            webView = new WebView("about:blank", settings);
            webView.Location = new Point(133, 50);
            webView.Size = new Size(1279, 554);
            webView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            webView.PropertyChanged += webView_PropertyChanged;
            
            this.Controls.Add(webView);

            //Setup the auth token
            _token = new Token(twitterAuth, twitterAuthSecret, "X7y6Z60t38Pwx0XgWoADAw", "5hGZEjJWhChTTWu5YP9YgM97JZhROmWo8uv0ORk71o");

            //Load in the user information
            _user = new TokenUser(_token);

            //Setup the stream
            _tStream = new TweetStream(processTweetStream);
            _tStream.StreamUrl = "https://userstream.twitter.com/1.1/user.json";

            //Start stream and setup panel
            _tStream.StartStream(_token);

            //Enable thje update panel and buttons, used to start with them disabled while user logged into Twitter.
            updatePanel.Visible = true;
            webView.Visible = false;

            usernameLabel.Text = _user.ScreenName;
            userAvatar.ImageLocation = _user.ProfileImageURLHttps;

            managerButton.Enabled = true;
            dashboardButton.Enabled = true;
            webviewButton.Enabled = true;
            settingsButton.Enabled = true;


            _lookSettings = new LookSettings();
            //webView.DocumentReady += webView_DocumentReady;
            _keywordManager = new KeyWordManager(_lookSettings, followUser);

            Properties.Settings.Default.PropertyChanged += settingsChanged;

            //Show if Enabled/Disabled
            if (Properties.Settings.Default.rsvpEnabled)
            {
                rsvpEnabledLabel.Text = "RSVP: Enabled";
                rsvpEnabledLabel.ForeColor = Color.Lime;
            }
            else
            {
                rsvpEnabledLabel.Text = "RSVP: Disabled";
                rsvpEnabledLabel.ForeColor = Color.Red;
            }
            if (Properties.Settings.Default.linkEnabled)
            {
                linkSniperEnabledLabel.Text = "Link Sniper: Enabled";
                linkSniperEnabledLabel.ForeColor = Color.Lime;
            }
            else
            {
                linkSniperEnabledLabel.Text = "Link Sniper: Disabled";
                linkSniperEnabledLabel.ForeColor = Color.Red;
            }

        }

        void webView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("IsLoading", StringComparison.OrdinalIgnoreCase))
            {
                if (!webView.IsLoading)
                {
                    webForwardButton.Enabled = webView.CanGoForward;
                    webBackButton.Enabled = webView.CanGoBack;
                    if (webView.InvokeRequired)
                    {
                        webView.Invoke(new MethodInvoker(delegate
                            {
                                webView.Focus();
                            }));
                    };
                }
            }
        }

        void settingsChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "rsvpEnabled")
            {
                if (Properties.Settings.Default.rsvpEnabled)
                {
                    rsvpEnabledLabel.Text = "RSVP: Enabled";
                    rsvpEnabledLabel.ForeColor = Color.Lime;
                }
                else
                {
                    rsvpEnabledLabel.Text = "RSVP: Disabled";
                    rsvpEnabledLabel.ForeColor = Color.Red;
                }
            }
            else if (e.PropertyName == "linkEnabled")
            {
                if (Properties.Settings.Default.linkEnabled)
                {
                    linkSniperEnabledLabel.Text = "Link Sniper: Enabled";
                    linkSniperEnabledLabel.ForeColor = Color.Lime;
                }
                else
                {
                    linkSniperEnabledLabel.Text = "Link Sniper: Disabled";
                    linkSniperEnabledLabel.ForeColor = Color.Red;
                }
            }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        public string UrlEncode(string value)
        {
            string[] UriRfc3986CharsToEscape = new[] { "!", "*", "'", "(", ")" };
            StringBuilder escaped = new StringBuilder(Uri.EscapeDataString(value));

            // Upgrade the escaping to RFC 3986, if necessary.
            for (int i = 0; i < UriRfc3986CharsToEscape.Length; i++)
            {
                escaped.Replace(UriRfc3986CharsToEscape[i], Uri.HexEscape(UriRfc3986CharsToEscape[i][0]));
            }

            // Return the fully-RFC3986-escaped string.
            return escaped.ToString();
        }

        IUser getUser(IToken token, string username)
        {
            IUser user = new User(username, token);
            return user;
        }

        void followUser(string username)
        {
            _token.ExecutePOSTQuery("https://api.twitter.com/1.1/friendships/create.json?screen_name=" + username + "&follow=true");
        }


        private void processTweetStream(Tweet tweet, bool force = false)
        {
            //Only check if the link sniper or rsvp is enabled.
            if (Properties.Settings.Default.linkEnabled || Properties.Settings.Default.rsvpEnabled)
            {
                //Check to see if the tweet contains a keyword/username
                if (_lookSettings.checkKeywords(tweet) || _lookSettings.checkRSVPKeywords(tweet))
                {

                    //Keyword Matched, lets see how fast we should handle it and recheck that license!
                    //Check if it exists again, someone may have deleted it, some people are plain stupid.
                    if (!File.Exists("license.xml"))
                    {
                        MessageBox.Show("Looks like your license is missing, the program will close, relogging should fix this.", "Where has it gone?", MessageBoxButtons.OK);
                        this.Close();
                    }

                    //Okay file exists, lets check it.
                    try
                    {
                        LicenseValidator validator = new LicenseValidator(_publicKey, "license.xml");
                        validator.AssertValidLicense();

                        //Check to see if the email and license are the same as on the license
                        if (validator.Name == _userEmail && validator.LicenseType == (LicenseType)_accessLevel)
                        {
                            //License is okay, continue with Tweet parsing, using the accessLevel to perform delay if needed.

                            if (validator.LicenseType == LicenseType.Trial)
                            {
                                int trialDelaySeconds = 10;
                                trialTweetFoundLabel.Invoke(new MethodInvoker(delegate
                                {
                                    trialTweetFoundLabel.Visible = true;
                                }));

                                BackgroundWorker bw = new BackgroundWorker();

                                // this allows our worker to report progress during work
                                bw.WorkerReportsProgress = true;

                                // what to do in the background thread
                                bw.DoWork += new DoWorkEventHandler(
                                delegate(object o, DoWorkEventArgs args)
                                {
                                    BackgroundWorker b = o as BackgroundWorker;

                                    // do some simple processing for 10 seconds
                                    for (int i = 1; i <= trialDelaySeconds; i++)
                                    {
                                        // report the progress in percent
                                        b.ReportProgress(trialDelaySeconds - i);
                                        Thread.Sleep(1000);
                                    }
                                });

                                // what to do when progress changed (update the progress bar for example)
                                bw.ProgressChanged += new ProgressChangedEventHandler(
                                delegate(object o, ProgressChangedEventArgs args)
                                {
                                    trialTweetFoundLabel.Invoke(new MethodInvoker(delegate
                                    {
                                        trialTweetFoundLabel.Text = string.Format("Tweet Found\nLoading in {0} seconds!", args.ProgressPercentage);
                                    }));
                                });

                                // what to do when worker completes its task (notify the user)
                                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                                delegate(object o, RunWorkerCompletedEventArgs args)
                                {
                                    trialTweetFoundLabel.Invoke(new MethodInvoker(delegate
                                    {
                                        trialTweetFoundLabel.Visible = false;
                                    }));
                                    parseTweetForSnipeandRSVP(tweet);
                                });

                                bw.RunWorkerAsync();
                            }
                            else
                            {
                                parseTweetForSnipeandRSVP(tweet);
                            }
                        }
                    }
                    catch (LicenseNotFoundException ex)
                    {
                        MessageBox.Show("Invalid Licence");
                    }
                }
            }

            if (lastTweetLabel.InvokeRequired)
            {
                lastTweetLabel.Invoke(new MethodInvoker(delegate { lastTweetLabel.Text = "Last Tweet: " + tweet.Text; }));
            }
            if (tweetsCheckedCounterLabel.InvokeRequired)
            {
                tweetsCheckedCounterLabel.Invoke(new MethodInvoker(delegate { tweetsCheckedCounterLabel.Text = (++_tweetsChecked).ToString(); }));
            }
        }

        private void parseTweetForSnipeandRSVP(Tweet tweet)
        {
            //If the link sniper is enabled, check to see if there's a link.
            if (Properties.Settings.Default.linkEnabled)
            {
                //Double check to see if this tweet is for the link sniper
                if (_lookSettings.checkKeywords(tweet)/* && !tweet.Text.Contains("#RSVP")*/)
                {

                    List<string> urls = parseURLFromString(tweet.Text);

                    if (urls.Count > 0 && Uri.IsWellFormedUriString(urls[0], UriKind.RelativeOrAbsolute))
                    {
                        switch (Properties.Settings.Default.browserSetting)
                        {
                            case 0:
                                if (webView.InvokeRequired)
                                {
                                    webView.Invoke(new MethodInvoker(delegate
                                    {
                                        webView.Visible = true;
                                        //webView.BringToFront();
                                        string realURL = GetRealUrl(urls[0]);
                                        webView.Load(realURL);
                                        webView.SetNavState(true, true, false);
                                        this.TopMost = true;
                                        this.TopMost = false;

                                        updatePanel.Visible = false;

                                        webForwardButton.Visible = true;
                                        webBackButton.Visible = true;

                                        //Begin auto checkout
                                        if (Properties.Settings.Default.autoCheckout)
                                        {
                                            //Wait till the page has loaded
                                            while (webView.IsLoading)
                                            {
                                                Application.DoEvents();
                                            }

                                            //Once loaded, chech to see if the URL has /pd/ before running the autoCart code

                                            if (webView.Address.ToString().Contains("/pd/"))
                                            {
                                                doAutoCheckout();
                                            }
                                        }


                                    }));
                                }
                                break;
                            case 1:
                                System.Diagnostics.Process.Start(urls[0]);
                                break;
                            case 2:
                                string browserPath = System.IO.Path.GetFullPath(Properties.Settings.Default.browserPath);
                                System.Diagnostics.Process.Start(browserPath, urls[0]);
                                break;
                            default:
                                break;
                        }
                        //MessageBox.Show(tweet.Text);
                    }
                }
            }


            //If the RSVP is enabled, check to see if the tweet contains #RSVP and specified keyword
            if (Properties.Settings.Default.rsvpEnabled)
            {
                //Check if this tweet contains rsvp words
                if (tweet.Text.Contains("#RSVP") && _lookSettings.checkRSVPKeywords(tweet))
                {
                    string solvedHashTag = "";

                    //Check to see if the media count is more than one. We only want to check for images.
                    if (tweet.Media.Count >= 1)
                    {
                        //Begin a loop in case of multiple
                        for (int mediaCount = 0; mediaCount < tweet.Media.Count; ++mediaCount)
                        {
                            //Check to see if the media type is an image
                            if (tweet.Media[mediaCount].MediaType == "photo")
                            {
                                //Get the image URL
                                string imageURL = tweet.Media[mediaCount].MediaURL;
                                
                                string hashTag = _ocrSolver.CleanAndOCRImage(imageURL);

                                if (!String.IsNullOrEmpty(hashTag))
                                {
                                    //Was solved, store in solvedHashTag
                                    solvedHashTag = hashTag;
                                }
                                else
                                {
                                    //Hashtag is empty which means the OCR/Image Process failed, ask the user.
                                    using (var form = new OCRImage(imageURL))
                                    {
                                        var result = form.ShowDialog();
                                        if (result == DialogResult.OK)
                                        {
                                            solvedHashTag = form.userText;
                                        }
                                        else
                                        {
                                            solvedHashTag = "";
                                        }
                                    }
                                }


                                //Check to see if the solved hashtag has value and begin DM if it has.
                                if (!String.IsNullOrEmpty(solvedHashTag))
                                {

                                    string builtName = Properties.Settings.Default.firstName + " " + Properties.Settings.Default.lastName;
                                    string shoeSize = Properties.Settings.Default.shoeSize.ToString();

                                    IUser receiver = new User(tweet.Creator.Id);
                                    IMessage msg = new Tweetinvi.Message(UrlEncode(String.Format("{0} {1} {2}", solvedHashTag, builtName, shoeSize)), receiver);
                                    try
                                    {
                                        msg.Send(_token);
                                    }
                                    catch (WebException ex)
                                    {
                                        this.Invoke(new MethodInvoker(delegate
                                        {
                                            MessageBox.Show(this, "Unable to send a Direct Message to " + tweet.Creator.ScreenName + ".", "Unable to Direct Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }));
                                    }
                                }


                            }
                        }
                    }

                }
            }
        }

        public static bool IsUrlImage(string url)
        {
            try
            {
                var request = WebRequest.Create(url);
                request.Timeout = 5000;
                using (var response = request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (!response.ContentType.Contains("text/html"))
                        {
                            using (var br = new BinaryReader(responseStream))
                            {
                                // e.g. test for a JPEG header here
                                var soi = br.ReadUInt16();  // Start of Image (SOI) marker (FFD8)
                                var jfif = br.ReadUInt16(); // JFIF marker (FFE0)
                                return soi == 0xd8ff && jfif == 0xe0ff;
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                //Trace.WriteLine(ex);
                //throw;
                return false;
            }
            return false;
        }

        private void doAutoCheckout(){
            webView.ExecuteScript(@"
                                jQuery.expr[':'].regex = function(elem, index, match) {
	                                var matchParams = match[3].split(','),
		                                validLabels = /^(data|css):/,
		                                attr = {
			                                method: matchParams[0].match(validLabels) ? 
						                                matchParams[0].split(':')[0] : 'attr',
			                                property: matchParams.shift().replace(validLabels,'')
		                                },
		                                regexFlags = 'ig',
		                                regex = new RegExp(matchParams.join('').replace(/^\s+|\s+$/g,''), regexFlags);
	                                return regex.test(jQuery(elem)[attr.method](attr.property));
                                }

                                var size = " + Properties.Settings.Default.shoeSize + @";

                                //Show dropdowns - Not needed.
                                //$(""a[class$='nike-button nike-button-orange buy-button']"").click();

                                //Select shoe size
                                $(""select[name$='skuAndSize']"").val(function() {
	                                return $(""option:regex(value, :"" + size + "")"").val();
                                }).change();


                                //Add to cart
                                //$(""div[class$='button-container add-to-cart']"").click();
                                $(""button:regex(class, add-to-cart)"").click();

                                //Checkout
                                //$(""div[class$='cart facet nav-section l-cell']"").children().children().click();
                                $(""div:regex(class, cart)"").children().children().click();"
                );

            //Wait till the page has loaded
            while (webView.IsLoading)
            {
                Application.DoEvents();
            }


            switch (Properties.Settings.Default.checkoutSetting)
            {
                case 0:
                    webView.ExecuteScript(@"
                        document.getElementById('tunnelEmailInput').value = '" + Properties.Settings.Default.checkoutEmail + @"';
                        document.getElementById('tunnelPasswordInput').value = '" + Properties.Settings.Default.checkoutPassword + @"';
                        document.getElementById('ch4_loginButton').click();"
                    );
                    break;
                case 1:
                    webView.ExecuteScript(@"
                        document.getElementById('ch4_loginGuestBtn').click();"
                    );  
                    break;
                case 2:
                    webView.ExecuteScript(@"
                        window.location = document.getElementById('ch4_loginPaypal').children[2].children[0].getAttribute('href');"
                    );
                    break;
                default:    //Guest checkout
                    webView.ExecuteScript(@"
                        document.getElementById('ch4_loginGuestBtn').click();"
                    );  
                    break;
            }

        }
        
        private void managerButton_Click(object sender, EventArgs e)
        {
            if (_user == null)
            {
                MessageBox.Show("You must login to Twitter first.", "Please Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_keywordManager.IsDisposed)
                _keywordManager = new KeyWordManager(_lookSettings, followUser);

            _keywordManager.Show();
        }

        private List<string> parseURLFromString(string str)
        {
            //From http://stackoverflow.com/questions/9125016/get-url-from-a-text
            List<string> list = new List<string>();
            Regex urlRx = new
            Regex(@"(http|ftp|https)://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?",
            RegexOptions.IgnoreCase);

            MatchCollection matches = urlRx.Matches(str);
            foreach (Match match in matches)
            {
                list.Add(match.Value);
            }
            return list;
        }

        private void webBackButton_Click(object sender, EventArgs e)
        {
            if (webView.CanGoBack)
            {
                webView.Back();
            }
        }

        private void webForwardButton_Click(object sender, EventArgs e)
        {
            if (webView.CanGoForward)
            {
                webView.Forward();
            }
        }

        private void dashboardEnable(object sender, EventArgs e)
        {
            if (dashboardButton.Enabled)
            {
                dashboardButton.Style = MetroFramework.MetroColorStyle.Green;
            }
            else
            {
                dashboardButton.Style = MetroFramework.MetroColorStyle.Black;
            }
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            updatePanel.Visible = true;
            webView.Visible = false;
            webBackButton.Visible = false;
            webForwardButton.Visible = false;
        }


        private void webviewButton_Click(object sender, EventArgs e)
        {
            updatePanel.Visible = false;
            webView.Visible = true;
            webBackButton.Visible = true;
            webForwardButton.Visible = true;
        }

        private void managerEnabled(object sender, EventArgs e)
        {
            if (managerButton.Enabled)
            {
                managerButton.Style = MetroFramework.MetroColorStyle.Red;
            }
            else
            {
                managerButton.Style = MetroFramework.MetroColorStyle.Black;
            }
        }

        private void webviewEnabled(object sender, EventArgs e)
        {
            if (webviewButton.Enabled)
            {
                webviewButton.Style = MetroFramework.MetroColorStyle.Teal;
            }
            else
            {
                webviewButton.Style = MetroFramework.MetroColorStyle.Black;
            }
        }

        private void settingEnabled(object sender, EventArgs e)
        {
            if (settingsButton.Enabled)
            {
                settingsButton.Style = MetroFramework.MetroColorStyle.Silver;
            }
            else
            {
                settingsButton.Style = MetroFramework.MetroColorStyle.Black;
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsTweaker settings = new SettingsTweaker();
            settings.Show();
        }

        private void bitcoinAdrLink_Click(object sender, EventArgs e)
        {
            string bitCoinURL = "";

            switch (Properties.Settings.Default.browserSetting)
            {
                case 0:
                    if (webView.InvokeRequired)
                    {
                        webView.Invoke(new MethodInvoker(delegate
                        {
                            webView.Visible = true;
                            //webView.BringToFront();
                            webView.Load(bitCoinURL);
                            this.TopMost = true;
                            this.TopMost = false;

                            updatePanel.Visible = false;

                            webForwardButton.Visible = true;
                            webBackButton.Visible = true;

                        }));
                    }
                    break;
                case 1:
                    System.Diagnostics.Process.Start("");
                    break;
                case 2:
                    string browserPath = System.IO.Path.GetFullPath(Properties.Settings.Default.browserPath);
                    System.Diagnostics.Process.Start(browserPath, "");
                    break;
                default:
                    break;
            }
        }

        private static string GetRealUrl(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Head;
            WebResponse response = request.GetResponse();
            return response.ResponseUri.ToString();
        }
    }
}
