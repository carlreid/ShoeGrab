using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;

namespace ShoeGrab
{
    public class LookSettings
    {
        List<String> _keyWords;
        List<String> _watchUsers;
        List<String> _rsvpKeyWords;
        List<String> _rsvpWatchUsers;

        public LookSettings()
        {
            _keyWords = new List<string>(Properties.Settings.Default.keyWords.Split(','));
            _watchUsers = new List<string>(Properties.Settings.Default.watchUsers.Split(','));
            _rsvpKeyWords = new List<string>(Properties.Settings.Default.rsvpKeyWords.Split(','));
            _rsvpWatchUsers = new List<string>(Properties.Settings.Default.rsvpWatchUsers.Split(','));
        }

        public void saveSettings()
        {
            string[] keyWordsArr = _keyWords.ToArray();
            Properties.Settings.Default.keyWords = String.Join(",", keyWordsArr);

            string[] watchUsersArr = _watchUsers.ToArray();
            Properties.Settings.Default.watchUsers = String.Join(",", watchUsersArr);

            string[] rsvpkeyWordsArr = _rsvpKeyWords.ToArray();
            Properties.Settings.Default.rsvpKeyWords = String.Join(",", rsvpkeyWordsArr);

            string[] rsvpWatchUsersArr = _rsvpWatchUsers.ToArray();
            Properties.Settings.Default.rsvpWatchUsers = String.Join(",", rsvpWatchUsersArr);

            Properties.Settings.Default.Save();
        }

        public void setKeyWords(List<String> keywords)
        {
            _keyWords = keywords;
            saveSettings();
        }

        public void rsvpSetKeyWords(List<String> keywords)
        {
            _rsvpKeyWords = keywords;
            saveSettings();
        }

        public void setWatchUser(List<String> watchusers)
        {
            _watchUsers = watchusers;
            saveSettings();
        }

        public void rsvpSetWatchUser(List<String> watchusers)
        {
            _rsvpWatchUsers = watchusers;
            saveSettings();
        }

        public List<String> getKeyWords()
        {
            return _keyWords;
        }

        public List<String> getWatchUsers()
        {
            return _watchUsers;
        }

        public List<String> getRSVPKeyWords()
        {
            return _rsvpKeyWords;
        }

        public List<String> getRSVPWatchUsers()
        {
            return _rsvpWatchUsers;
        }

        public bool checkKeywords(Tweet tweet)
        {
            return _keyWords.Any(w => tweet.Text.Contains(w)) || _watchUsers.Any(w => tweet.Creator.ScreenName.Contains(w));
        }

    }
}
