using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoeGrab
{
    public partial class KeyWordManager : MetroFramework.Forms.MetroForm
    {
        LookSettings _lookSettings;
        Action<string> _followUser;

        public KeyWordManager(LookSettings lookSettings, Action<string> followUser)
        {
            InitializeComponent();
            _lookSettings = lookSettings;
            _followUser = followUser;
            setupKeywordText();
            setupUsernameText();
        }

        private void setupKeywordText(){
            List<String> keyWords = _lookSettings.getKeyWords();
            keyWordTextBox.Text = string.Join(Environment.NewLine, keyWords);

            //RSVP
            keyWords = _lookSettings.getRSVPKeyWords();
            rsvpKeywordTextBox.Text = string.Join(Environment.NewLine, keyWords);
        }

        private void setupUsernameText()
        {
            List<String> usernames = _lookSettings.getWatchUsers();
            userNameTextBox.Text = string.Join(Environment.NewLine, usernames);

            //RSVP
            usernames = _lookSettings.getRSVPWatchUsers();
            rsvpUserNameTextBox.Text = string.Join(Environment.NewLine, usernames);
        }

        private void KeyWordManager_Load(object sender, EventArgs e)
        {
            List<String> keyWords = _lookSettings.getKeyWords();
            keyWordTextBox.Text = string.Join(Environment.NewLine, keyWords);
        }

        private void acceptKeyWords_Click(object sender, EventArgs e)
        {
            List<String> newKeyWords = new List<string>(keyWordTextBox.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
            _lookSettings.setKeyWords(newKeyWords);
        }

        private void denyKeyWords_Click(object sender, EventArgs e)
        {
            List<String> keyWords = _lookSettings.getKeyWords();
            keyWordTextBox.Text = string.Join(Environment.NewLine, keyWords);
        }

        private void acceptUsernames_Click(object sender, EventArgs e)
        {
            List<String> newUserNames = new List<string>(userNameTextBox.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
            _lookSettings.setWatchUser(newUserNames);
        }

        private void denyUsernames_Click(object sender, EventArgs e)
        {
            List<String> usernames = _lookSettings.getWatchUsers();
            userNameTextBox.Text = string.Join(Environment.NewLine, usernames);
        }

        private void followAllButton_Click(object sender, EventArgs e)
        {
            //Accept the list first
            List<String> newUserNames = new List<string>(userNameTextBox.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
            _lookSettings.setWatchUser(newUserNames);

            foreach (string user in _lookSettings.getWatchUsers())
            {
                _followUser(user);
            }
        }

        private void rsvpAcceptKeyWords_Click(object sender, EventArgs e)
        {
            List<String> newKeyWords = new List<string>(rsvpKeywordTextBox.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
            _lookSettings.rsvpSetKeyWords(newKeyWords);
        }

        private void rsvpDenyKeyWords_Click(object sender, EventArgs e)
        {
            List<String> keyWords = _lookSettings.getRSVPKeyWords();
            rsvpKeywordTextBox.Text = string.Join(Environment.NewLine, keyWords);
        }

        private void rsvpFollowAllButton_Click(object sender, EventArgs e)
        {
            //Accept the list first
            List<String> newUserNames = new List<string>(rsvpUserNameTextBox.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
            _lookSettings.rsvpSetWatchUser(newUserNames);

            foreach (string user in _lookSettings.getRSVPWatchUsers())
            {
                _followUser(user);
            }
        }

        private void rsvpAcceptUsernames_Click(object sender, EventArgs e)
        {
            List<String> newUserNames = new List<string>(rsvpUserNameTextBox.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
            _lookSettings.rsvpSetWatchUser(newUserNames);
        }

        private void rsvpDenyUsernames_Click(object sender, EventArgs e)
        {
            List<String> usernames = _lookSettings.getRSVPWatchUsers();
            rsvpUserNameTextBox.Text = string.Join(Environment.NewLine, usernames);
        }
    }
}
