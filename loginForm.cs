using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoeGrab
{
    public partial class loginForm : MetroFramework.Forms.MetroForm
    {
        public loginForm()
        {
            InitializeComponent();
            this.Text += System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
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
            string reqType = "shoegrab";

            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = "user=" + username;
            postData += ("&pass=" + password);
            postData += ("&req=" + reqType);
            byte[] data = encoding.GetBytes(postData);

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://shop.gigime.co.uk/login.php");

            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;

            Stream requestStream = myRequest.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse )myRequest.GetResponse();

            Stream answer = response.GetResponseStream();
            StreamReader answerReader = new StreamReader(answer);
            Console.WriteLine(answerReader.ReadToEnd());

        }
    }
}
