using Rhino.Licensing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoeGrab
{
    public partial class loginForm : MetroFramework.Forms.MetroForm
    {
        string publicKey;
        public string twitterAuth = "";
        public string twitterAuthSecret = "";
        public string email = "";
        public int acLevel = -1;

        public loginForm()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists("publicKey.xml"))
            {
                MessageBox.Show("Missing data, please redownload the application.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                publicKey = File.ReadAllText("publicKey.xml");
            }

            this.Text += System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];
        }

        private void emailTextBox_Click(object sender, EventArgs e)
        {
            if (emailTextBox.Text == "your@ema.il")
            {
                emailTextBox.Text = "";
            }
        }

        private void passwordTextBox_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == "Password")
            {
                passwordTextBox.Text = "";
            }
        }

        private void formPreviewKey(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    MessageBox.Show("DO LOGIN");
            //}
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = emailTextBox.Text;
            string password = passwordTextBox.Text;

            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = "email=" + username;
            postData += ("&password=" + password);
            byte[] data = encoding.GetBytes(postData);

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://www.vyprbot.com/login");

            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            myRequest.UserAgent = "ShoeGrab";

            Stream requestStream = myRequest.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse )myRequest.GetResponse();

            Stream answer = response.GetResponseStream();
            StreamReader answerReader = new StreamReader(answer);
            string responseHTML = answerReader.ReadToEnd();

            Match regexResult = Regex.Match(responseHTML, @"(?<={{)(.*\n?)(?=}})");
            string[] dataValues = regexResult.ToString().Split(':');

            if (dataValues.Length > 1)
            {
                //Check if the auth data is ok
                twitterAuth = dataValues[0];
                twitterAuthSecret = dataValues[1];
                email = emailTextBox.Text;
                Int32.TryParse(dataValues[2], out acLevel);

                if (!String.IsNullOrEmpty(twitterAuth) && !String.IsNullOrEmpty(twitterAuthSecret))
                {
                    //Okay, user is valid ShoeBot user, do license checking if needed.
                    int accessLevel;
                    Int32.TryParse(dataValues[2], out accessLevel);

                    if (accessLevel > 0)
                    {
                        if (!File.Exists("license.xml"))
                        {
                            //License doesn't exist, no worries, they may have just bought.
                            //Perform a POST to the server and request the license using email/pass
                            HttpWebRequest licenseRequest = (HttpWebRequest)WebRequest.Create("http://www.vyprbot.com/auth/license.php");

                            licenseRequest.Method = "POST";
                            licenseRequest.ContentType = "application/x-www-form-urlencoded";
                            licenseRequest.ContentLength = data.Length;
                            licenseRequest.UserAgent = "ShoeGrab";

                            Stream licRequestStream = licenseRequest.GetRequestStream();
                            licRequestStream.Write(data, 0, data.Length);
                            licRequestStream.Close();

                            HttpWebResponse licResponse = (HttpWebResponse)licenseRequest.GetResponse();

                            Stream licAnswer = licResponse.GetResponseStream();
                            StreamReader licAnswerReader = new StreamReader(licAnswer);
                            string licResponseHTML = licAnswerReader.ReadToEnd();

                            if (!String.IsNullOrEmpty(licResponseHTML) && licResponseHTML != "na")
                            {
                                File.WriteAllText("license.xml", licResponseHTML);
                            }
                            else
                            {
                                MessageBox.Show("If you just purchased, please try again in a moment", "No valid license", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        try
                        {
                            LicenseValidator validator = new LicenseValidator(publicKey, "license.xml");
                            validator.AssertValidLicense();

                            //Check to see if the email and license are the same as on the license
                            if (validator.Name == emailTextBox.Text && validator.LicenseType == (LicenseType)Enum.Parse(typeof(LicenseType), dataValues[2]))
                            {
                                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            }
                        }
                        catch (LicenseNotFoundException ex)
                        {
                            MessageBox.Show("Invalid Licence");
                        }
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("You have not linked your account to Twitter, click the Link button.", "Link to Twitter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                if (dataValues[0] == "BADLOGIN")
                {
                    loginInfoLabel.Text = "Error: Invalid Login";
                    loginInfoLabel.Visible = true;
                }
                else
                {
                    MessageBox.Show("ShoeGrab isn't on your account.");
                }
            }

        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.vyprbot.com/register");
        }

        private void forgotButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.vyprbot.com/forgot");
        }

        private void linkButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.vyprbot.com/account");
        }
    }
}
