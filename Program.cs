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

            using (var form = new loginForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Application.Run(new mainForm(form.twitterAuth, form.twitterAuthSecret));
                }
            }

            //Application.Run(new loginForm(ref this));

        }
    }
}
