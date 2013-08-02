using oAuthConnection;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing;
using System.Net;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
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
        IUser _user = null;
        TweetStream _tStream;
        LookSettings _lookSettings;
        KeyWordManager _keywordManager;

        public mainForm()
        {
            InitializeComponent();

            _token = new Token("", "", "NcurVbma1EO225iVz2iIg", "4R0lMIAmhRbMwiPunDcwvfAkKfzNOq5PkGi6taPd7Q");

            _lookSettings = new LookSettings();
            webView.DocumentReady += webView_DocumentReady;
            _keywordManager = new KeyWordManager(_lookSettings, followUser);

            //Setup the stream
            _tStream = new TweetStream(processTweetStream);
            _tStream.StreamUrl = "https://userstream.twitter.com/1.1/user.json";

            Properties.Settings.Default.PropertyChanged += settingsChanged;

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
            if (requestAuthToken())
            {
                webView.Source = new Uri("https://api.twitter.com/oauth/authenticate?oauth_token=" + _token.AccessToken);
            }
            //webView.Source = new Uri("http://store.nike.com/us/en_us/pd/jordan-spizike-shoe/pid-705452/pgid-848594");
        }

        void webView_DocumentReady(object sender, Awesomium.Core.UrlEventArgs e)
        {
            if (_user == null)
            {
                string source = webView.ExecuteJavascriptWithResult("document.documentElement.outerHTML");

                if (source.Contains("<code>"))
                {
                    var startTag = "<code>";
                    int startIndex = source.IndexOf(startTag) + startTag.Length;
                    int endIndex = source.IndexOf("</code>", startIndex);
                    string code = source.Substring(startIndex, endIndex - startIndex);

                    if (verifyCode(code))
                    {
                        //Start stream and setup panel
                        _tStream.StartStream(_token);
                        updatePanel.Visible = true;
                        webView.Visible = false;
                        usernameLabel.Text = _user.Screen_Name;
                        userAvatar.ImageLocation = _user.Profile_Image_URL_Https;

                        //Enable buttons
                        managerButton.Enabled = true;
                        dashboardButton.Enabled = true;
                        webviewButton.Enabled = true;
                        settingsButton.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Unable to verify PIN. Please try again.");
                    }
                }
            }

            webForwardButton.Enabled = webView.CanGoForward();
            webBackButton.Enabled = webView.CanGoBack();
            webView.Focus();
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

            //value = Uri.EscapeDataString(value);
            //value = Regex.Replace(value, "(%[0-9a-f][0-9a-f])", c => c.Value.ToUpper());
            //return value;
        }

        IUser getUser(IToken token, string username)
        {
            IUser user = new User(username, token);
            return user;
        }

        void followUser(string username)
        {
            //IToken queryToken = token;
            //Dictionary<string, object> result =  queryToken.ExecutePOSTQuery("https://api.twitter.com/1.1/friendships/create.json?screen_name=" + username + "&follow=true");

            NameValueCollection results = doPOSTRequest("https://api.twitter.com/1.1/friendships/create.json?screen_name=" + username + "&follow=true");
        }

        NameValueCollection doPOSTRequest(string url)
        {
            OAuthCredentials creds = new OAuthCredentials(_token.AccessToken, _token.AccessTokenSecret, _token.ConsumerKey, _token.ConsumerSecret);
            OAuthWebRequestGenerator gen = new OAuthWebRequestGenerator();

            HttpWebRequest req = gen.GenerateWebRequest(url, HttpMethod.POST, creds);
            req.Method = "POST";
            req.ContentLength = 0;
            req.ServicePoint.Expect100Continue = false;

            HttpWebResponse s = (HttpWebResponse)req.GetResponse();
            System.IO.Stream stream = s.GetResponseStream();
            string responseData = new System.IO.StreamReader(stream).ReadToEnd();

            return HttpUtility.ParseQueryString(responseData);
        }

        NameValueCollection doGETRequest(string url)
        {
            OAuthCredentials creds = new OAuthCredentials(_token.AccessToken, _token.AccessTokenSecret, _token.ConsumerKey, _token.ConsumerSecret);
            OAuthWebRequestGenerator gen = new OAuthWebRequestGenerator();

            HttpWebRequest req = gen.GenerateWebRequest(url, HttpMethod.GET, creds);
            req.Method = "GET";
            //req.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            //req.ContentLength = 0;
            //req.ServicePoint.Expect100Continue = false;

            HttpWebResponse s = (HttpWebResponse)req.GetResponse();
            System.IO.Stream stream = s.GetResponseStream();
            string responseData = new System.IO.StreamReader(stream).ReadToEnd();           

            return HttpUtility.ParseQueryString(responseData); ;
        }

        bool requestAuthToken()
        {
            NameValueCollection result = doPOSTRequest("https://api.twitter.com/oauth/request_token?oauth_callback=oob");

            if (result.Get("oauth_callback_confirmed") == "true")
            {
                _token.AccessToken = result.Get("oauth_token");
                _token.AccessTokenSecret = result.Get("oauth_token_secret");
                return true;
            }
            else
            {
                MessageBox.Show("Unable to request authentication token");
                return false;
            }
        }

        bool verifyCode(string code)
        {
            NameValueCollection result = doPOSTRequest("https://api.twitter.com/oauth/access_token?oauth_verifier=" + code);

            if (result.Get("screen_name") != "")
            {
                _token.AccessToken = result.Get("oauth_token");
                _token.AccessTokenSecret = result.Get("oauth_token_secret");
                _user = getUser(_token, result.Get("screen_name"));
                return true;
            }
            else
            {
                MessageBox.Show("Unable to verify pin.");
                return false;
            }

        }

        private void processTweetStream(Tweet tweet, bool force = false)
        {
            //Only check if the link sniper or rsvp is enabled.
            if (Properties.Settings.Default.linkEnabled || Properties.Settings.Default.rsvpEnabled)
            {
                //Check to see if the tweet contains a keyword/username
                if (_lookSettings.checkKeywords(tweet))
                {
                    //If the link sniper is enabled, check to see if there's a link.
                    if (Properties.Settings.Default.linkEnabled)
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
                                            webView.Source = new Uri(urls[0]);
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
                                                if (webView.Source.ToString().Contains("/pd/"))
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

                    
                    //If the RSVP is enabled, check to see if the tweet contains #RSVP and specified keyword
                    if (Properties.Settings.Default.linkEnabled)
                    {
                        if (tweet.Text.Contains("#RSVP") && tweet.Text.Contains(Properties.Settings.Default.rsvpKeyWords))
                        {
                            //TODO:
                            // 1) Download image
                            // 2) Cleanup image + OCR
                            // 3) DM the result
                        }
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

        private void doAutoCheckout(){
            webView.ExecuteJavascript(@"
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
                                $(""div:regex(class, add-to-cart)"").click();

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
                    webView.ExecuteJavascript(@"
                        document.getElementById('tunnelEmailInput').value = '" + Properties.Settings.Default.checkoutEmail + @"';
                        document.getElementById('tunnelPasswordInput').value = '" + Properties.Settings.Default.checkoutPassword + @"';
                        document.getElementById('ch4_loginButton').click();"
                    );
                    break;
                case 1:
                    webView.ExecuteJavascript(@"
                        document.getElementById('ch4_loginGuestBtn').click();"
                    );  
                    break;
                case 2:
                    webView.ExecuteJavascript(@"
                        window.location = document.getElementById('ch4_loginPaypal').children[2].children[0].getAttribute('href');"
                    );
                    break;
                default:    //Guest checkout
                    webView.ExecuteJavascript(@"
                        document.getElementById('ch4_loginGuestBtn').click();"
                    );  
                    break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            webView.ExecuteJavascript(@"
                        window.location = document.getElementById('ch4_loginPaypal').children[2].children[0].getAttribute('href');"
            );
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
            if (webView.CanGoBack())
            {
                webView.GoBack();
            }
        }

        private void webForwardButton_Click(object sender, EventArgs e)
        {
            if (webView.CanGoForward())
            {
                webView.GoForward();
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
                            webView.Source = new Uri("");
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
    }
}
