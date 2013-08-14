using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoeGrab
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new mainForm());
            //Application.Run(new OCRImage());
            //Application.Run(new SettingsTweaker());

            //ProgramUpdater _updater = new ProgramUpdater();
            //_updater.CheckForUpdates();

            //var fileDownloader = new FileDownloader("http://www.vyprbot.com/update/shoegrab/NAppUpdate.Framework.dll");

            //byte[] fileData = fileDownloader.Download();

            //int i = fileData.Length;

            using (var form = new loginForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Application.Run(new mainForm(form.twitterAuth, form.twitterAuthSecret, form.email, form.acLevel));
                }
            }

            //Application.Run(new loginForm(ref this));
        }



    }
}
