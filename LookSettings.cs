﻿using System;
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

        public LookSettings()
        {
            _keyWords = new List<string>(Properties.Settings.Default.keyWords.Split(','));
            _watchUsers = new List<string>(Properties.Settings.Default.watchUsers.Split(','));
        }

        public void saveSettings()
        {
            string[] keyWordsArr = _keyWords.ToArray();
            Properties.Settings.Default.keyWords = String.Join(",", keyWordsArr);

            string[] watchUsersArr = _watchUsers.ToArray();
            Properties.Settings.Default.watchUsers = String.Join(",", watchUsersArr);

            Properties.Settings.Default.Save();
        }

        public void setKeyWords(List<String> keywords)
        {
            _keyWords = keywords;
            saveSettings();
        }

        public void setWatchUser(List<String> watchusers)
        {
            _watchUsers = watchusers;
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

        public bool checkKeywords(Tweet tweet)
        {
            return _keyWords.Any(w => tweet.Text.Contains(w)) || _watchUsers.Any(w => tweet.Creator.Screen_Name.Contains(w));
        }

    }
}
