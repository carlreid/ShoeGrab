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
    public partial class SettingsTweaker : MetroFramework.Forms.MetroForm
    {
        public SettingsTweaker()
        {
            InitializeComponent();

            switch (Properties.Settings.Default.browserSetting)
            {
                case 0:
                    useBuiltInRadio.Checked = true;
                    break;
                case 1:
                    useDefaultRadio.Checked = true;
                    break;
                case 2:
                    useCustomBrowser.Checked = true;
                    browserPathTextBox.Text = Properties.Settings.Default.browserPath;
                    break;
                default:
                    useBuiltInRadio.Checked = true;
                    break;
            }

        }

        private void customBrowserChecked(object sender, EventArgs e)
        {
            if (useCustomBrowser.Checked)
            {
                browserPathTextBox.Text = Properties.Settings.Default.browserPath;
                browserPathTextBox.Visible = true;
                if (browserPathTextBox.Text == "")
                {
                    displayBrowserFind();
                }
            }
            else
            {
                browserPathTextBox.Visible = false;
            }
        }

        private void browserPathTextBox_Click(object sender, EventArgs e)
        {
            displayBrowserFind();
        }

        private void displayBrowserFind()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Executable files (*.exe)|*.exe";
            fileDialog.FilterIndex = 0;
            DialogResult result = fileDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (fileDialog.CheckFileExists && fileDialog.CheckPathExists)
                {
                    Properties.Settings.Default.browserPath = fileDialog.InitialDirectory + fileDialog.FileName;
                    browserPathTextBox.Text = Properties.Settings.Default.browserPath;
                    Properties.Settings.Default.Save();
                }
            }

        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            if (useBuiltInRadio.Checked)
            {
                Properties.Settings.Default.browserSetting = 0;
            }
            else if (useDefaultRadio.Checked)
            {
                Properties.Settings.Default.browserSetting = 1;
            } if (useCustomBrowser.Checked)
            {
                Properties.Settings.Default.browserSetting = 2;
            }
            Properties.Settings.Default.Save();
        }

    }
}
