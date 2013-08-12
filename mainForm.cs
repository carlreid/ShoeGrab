using CefSharp;
using CefSharp.WinForms;
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
        //IUser _user = null;
        TweetStream _tStream;
        LookSettings _lookSettings;
        KeyWordManager _keywordManager;
        WebView webView;
        TokenUser _user = null;

        public mainForm(string twitterAuth, string twitterAuthSecret)
        {
            InitializeComponent();

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
            _token = new Token(twitterAuth, twitterAuthSecret, "m28VNc4Cg3qxT4H0JuyWA", "Xn9nrjSJH9vDUpurOMpcWJpF295AXfbLZL8MoG2z8Q");
            //_token = new Token(twitterAuth, twitterAuthSecret, "", "");

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
                    //if (_user == null)
                    //{
                    //    string source = webView.EvaluateScript("document.documentElement.outerHTML").ToString();

                    //    if (source.Contains("<code>"))
                    //    {
                    //        var startTag = "<code>";
                    //        int startIndex = source.IndexOf(startTag) + startTag.Length;
                    //        int endIndex = source.IndexOf("</code>", startIndex);
                    //        string code = source.Substring(startIndex, endIndex - startIndex);

                    //        if (verifyCode(code))
                    //        {
                    //            //Start stream and setup panel
                    //            _tStream.StartStream(_token);

                    //            if (updatePanel.InvokeRequired)
                    //            {
                    //                updatePanel.Invoke(new MethodInvoker(delegate
                    //                    {
                    //                        updatePanel.Visible = true;
                    //                    }
                    //                ));
                    //            }

                    //            if (webView.InvokeRequired)
                    //            {
                    //                webView.Invoke(new MethodInvoker(delegate
                    //                {
                    //                    webView.Visible = false;
                    //                }
                    //                ));
                    //            }

                    //            if (usernameLabel.InvokeRequired)
                    //            {
                    //                usernameLabel.Invoke(new MethodInvoker(delegate
                    //                {
                    //                    usernameLabel.Text = _user.ScreenName;
                    //                }
                    //                ));
                    //            }

                    //            if (userAvatar.InvokeRequired)
                    //            {
                    //                userAvatar.Invoke(new MethodInvoker(delegate
                    //                {
                    //                    userAvatar.ImageLocation = _user.ProfileImageURLHttps;
                    //                }
                    //                ));
                    //            }
                                

                    //            //Enable buttons
                    //            if (managerButton.InvokeRequired)
                    //            {
                    //                managerButton.Invoke(new MethodInvoker(delegate
                    //                {
                    //                    managerButton.Enabled = true;
                    //                }
                    //                ));
                    //            }

                    //            if (dashboardButton.InvokeRequired)
                    //            {
                    //                dashboardButton.Invoke(new MethodInvoker(delegate
                    //                {
                    //                    dashboardButton.Enabled = true;
                    //                }
                    //                ));
                    //            }

                    //            if (webviewButton.InvokeRequired)
                    //            {
                    //                webviewButton.Invoke(new MethodInvoker(delegate
                    //                {
                    //                    webviewButton.Enabled = true;
                    //                }
                    //                ));
                    //            }

                    //            if (settingsButton.InvokeRequired)
                    //            {
                    //                settingsButton.Invoke(new MethodInvoker(delegate
                    //                {
                    //                    settingsButton.Enabled = true;
                    //                }
                    //                ));
                    //            }
                    //        }
                    //        else
                    //        {
                    //            MessageBox.Show("Unable to verify PIN. Please try again.");
                    //        }
                    //    }
                    //}

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
            //while (!webView.IsBrowserInitialized)
            //{
            //    Application.DoEvents();
            //}
            //if (requestAuthToken())
            //{
            //    webView.Load("https://api.twitter.com/oauth/authenticate?oauth_token=" + _token.AccessToken);
            //}
        }

        //void webView_DocumentReady(object sender, Awesomium.Core.UrlEventArgs e)
        //{
        //    if (_user == null)
        //    {
        //        string source = webView.ExecuteJavascriptWithResult("document.documentElement.outerHTML");

        //        if (source.Contains("<code>"))
        //        {
        //            var startTag = "<code>";
        //            int startIndex = source.IndexOf(startTag) + startTag.Length;
        //            int endIndex = source.IndexOf("</code>", startIndex);
        //            string code = source.Substring(startIndex, endIndex - startIndex);

        //            if (verifyCode(code))
        //            {
        //                //Start stream and setup panel
        //                _tStream.StartStream(_token);
        //                updatePanel.Visible = true;
        //                webView.Visible = false;
        //                usernameLabel.Text = _user.Screen_Name;
        //                userAvatar.ImageLocation = _user.Profile_Image_URL_Https;

        //                //Enable buttons
        //                managerButton.Enabled = true;
        //                dashboardButton.Enabled = true;
        //                webviewButton.Enabled = true;
        //                settingsButton.Enabled = true;
        //            }
        //            else
        //            {
        //                MessageBox.Show("Unable to verify PIN. Please try again.");
        //            }
        //        }
        //    }

        //    webForwardButton.Enabled = webView.CanGoForward();
        //    webBackButton.Enabled = webView.CanGoBack();
        //    webView.Focus();
        //}

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

            //NameValueCollection results = doPOSTRequest("https://api.twitter.com/1.1/friendships/create.json?screen_name=" + username + "&follow=true");
            _token.ExecutePOSTQuery("https://api.twitter.com/1.1/friendships/create.json?screen_name=" + username + "&follow=true");
        }

        //NameValueCollection doPOSTRequest(string url)
        //{
        //    OAuthCredentials creds = new OAuthCredentials(_token.AccessToken, _token.AccessTokenSecret, _token.ConsumerKey, _token.ConsumerSecret);
        //    OAuthWebRequestGenerator gen = new OAuthWebRequestGenerator();

        //    HttpWebRequest req = gen.GenerateWebRequest(url, HttpMethod.POST, creds);
        //    //HttpWebRequest req = gen.GenerateWebRequest(url, HttpMethod.POST, );

        //    req.Method = "POST";
        //    req.ContentLength = 0;
        //    req.ServicePoint.Expect100Continue = false;

        //    HttpWebResponse s = (HttpWebResponse)req.GetResponse();
        //    System.IO.Stream stream = s.GetResponseStream();
        //    string responseData = new System.IO.StreamReader(stream).ReadToEnd();

        //    return HttpUtility.ParseQueryString(responseData);
        //}

        //NameValueCollection doGETRequest(string url)
        //{
        //    OAuthCredentials creds = new OAuthCredentials(_token.AccessToken, _token.AccessTokenSecret, _token.ConsumerKey, _token.ConsumerSecret);
        //    OAuthWebRequestGenerator gen = new OAuthWebRequestGenerator();

        //    HttpWebRequest req = gen.GenerateWebRequest(url, HttpMethod.GET, creds);
        //    req.Method = "GET";
        //    //req.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
        //    //req.ContentLength = 0;
        //    //req.ServicePoint.Expect100Continue = false;

        //    HttpWebResponse s = (HttpWebResponse)req.GetResponse();
        //    System.IO.Stream stream = s.GetResponseStream();
        //    string responseData = new System.IO.StreamReader(stream).ReadToEnd();           

        //    return HttpUtility.ParseQueryString(responseData); ;
        //}

        //bool requestAuthToken()
        //{
        //    NameValueCollection result = doPOSTRequest("https://api.twitter.com/oauth/request_token?oauth_callback=oob");

        //    if (result.Get("oauth_callback_confirmed") == "true")
        //    {
        //        _token.AccessToken = result.Get("oauth_token");
        //        _token.AccessTokenSecret = result.Get("oauth_token_secret");
        //        return true;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Unable to request authentication token");
        //        return false;
        //    }
        //}

        //bool verifyCode(string code)
        //{
        //    NameValueCollection result = doPOSTRequest("https://api.twitter.com/oauth/access_token?oauth_verifier=" + code);

        //    if (result.Get("screen_name") != "")
        //    {
        //        _token.AccessToken = result.Get("oauth_token");
        //        _token.AccessTokenSecret = result.Get("oauth_token_secret");
        //        _user = getUser(_token, result.Get("screen_name"));
        //        return true;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Unable to verify pin.");
        //        return false;
        //    }

        //}

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
