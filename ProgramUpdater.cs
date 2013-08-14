using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using NAppUpdate.Framework;
//using NAppUpdate.Framework.Common;
//using NAppUpdate.Framework.Sources;
using System.IO;
using System.Windows.Forms;

namespace ShoeGrab
{
    public class ProgramUpdater
    {
        public ProgramUpdater()
        {

        }

        //public void CheckForUpdates()
        //{
        //    string feedXml = "http://www.vyprbot.com/update/shoegrab/UpdateFeed.xml";
        //    IUpdateSource feedSource = new SimpleWebSource(feedXml);

        //    // Get a local pointer to the UpdateManager instance
        //    UpdateManager updManager = UpdateManager.Instance;

        //    // Only check for updates if we haven't done so already
        //    if (updManager.State != UpdateManager.UpdateProcessState.NotChecked)
        //    {
        //        MessageBox.Show("Update process has already initialized; current state: " + updManager.State.ToString());
        //        return;
        //    }

        //    try
        //    {
        //        // Check for updates - returns true if relevant updates are found (after processing all the tasks and
        //        // conditions)
        //        // Throws exceptions in case of bad arguments or unexpected results
        //        updManager.CheckForUpdates(feedSource);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex is NAppUpdateException)
        //        {
        //            // This indicates a feed or network error; ex will contain all the info necessary
        //            // to deal with that
        //        }
        //        else MessageBox.Show(ex.ToString());
        //        return;
        //    }


        //    if (updManager.UpdatesAvailable == 0)
        //    {
        //        MessageBox.Show("Your software is up to date");
        //        return;
        //    }

        //    DialogResult dr = MessageBox.Show(string.Format("Updates are available to your software ({0} total). Do you want to download and prepare them now? You can always do this at a later time.", updManager.UpdatesAvailable), "Software updates available", MessageBoxButtons.YesNo);

        //    if (dr == DialogResult.Yes)
        //    {
        //        updManager.BeginPrepareUpdates(OnPrepareUpdatesCompleted, null);
        //    }
        //}

        //private void OnPrepareUpdatesCompleted(IAsyncResult asyncResult)
        //{
        //    try
        //    {
        //        ((UpdateProcessAsyncResult)asyncResult).EndInvoke();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(string.Format("Updates preperation failed. Check the feed and try again.{0}{1}", Environment.NewLine, ex));
        //        return;
        //    }

        //    // Get a local pointer to the UpdateManager instance
        //    UpdateManager updManager = UpdateManager.Instance;

        //    DialogResult dr = MessageBox.Show("Updates are ready to install. Do you wish to install them now?", "Software updates ready", MessageBoxButtons.YesNo);

        //    if (dr != DialogResult.Yes) return;
        //    // This is a synchronous method by design, make sure to save all user work before calling
        //    // it as it might restart your application
        //    try
        //    {
        //        bool reloadApp = true;
        //        bool enableLogging = false;
        //        bool enableShowConsole = false;

        //        updManager.ApplyUpdates(reloadApp, enableLogging, enableShowConsole);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(string.Format("Error while trying to install software updates{0}{1}", Environment.NewLine, ex));
        //    }
        //}
    }
}
