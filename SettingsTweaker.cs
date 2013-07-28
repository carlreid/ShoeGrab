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

            //Select the correct browser setting
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

            //Select the correct checkout setting
            switch (Properties.Settings.Default.checkoutSetting)
            {
                case 0:
                    checkoutNikeRadio.Checked = true;
                    break;
                case 1:
                    checkoutGuestRadio.Checked = true;
                    break;
                case 2:
                    checkoutPaypalRadio.Checked = true;
                    break;
                default:
                    checkoutGuestRadio.Checked = true;
                    break;
            }

            //Set the auto enabled to the correct checked state
            checkoutEnabledToggle.Checked = Properties.Settings.Default.autoCheckout;
            //Set the shoe size to the current shoe size
            shoeSizeText.Text = Properties.Settings.Default.shoeSize.ToString();

            //Set the Nike login and password
            nikeLoginEmailText.Text = Properties.Settings.Default.checkoutEmail;
            nikeLoginPasswordText.Text = Properties.Settings.Default.checkoutPassword;

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
            //Browser setting
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

            //Checkout setting
            if (checkoutNikeRadio.Checked)
            {
                Properties.Settings.Default.checkoutSetting = 0;
            }
            else if (checkoutGuestRadio.Checked)
            {
                Properties.Settings.Default.checkoutSetting = 1;
            } if (checkoutPaypalRadio.Checked)
            {
                Properties.Settings.Default.checkoutSetting = 2;
            }

            //Auto checkout setting
            Properties.Settings.Default.autoCheckout = checkoutEnabledToggle.Checked;

            //Shoe Size, check if int. Could have copy pasted.
            if (System.Text.RegularExpressions.Regex.IsMatch("[^0-9]", shoeSizeText.Text))
            {
                MessageBox.Show("Please enter only numbers for shoe size.", "Shoe Size", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                shoeSizeText.Text = Properties.Settings.Default.shoeSize.ToString();
                e.Cancel = true;
            }
            else
            {
                Properties.Settings.Default.shoeSize = Int32.Parse(shoeSizeText.Text);
            }

            //Save email and password
            if (!IsValidEmail(nikeLoginEmailText.Text))
            {
                MessageBox.Show("The email you entered is not formatted corectly. Please double check it.", "Bad Email", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Cancel = true;
            }
            else
            {
                Properties.Settings.Default.checkoutEmail = nikeLoginEmailText.Text;
            }
            Properties.Settings.Default.checkoutPassword = nikeLoginPasswordText.Text;

            //Save all set settings
            Properties.Settings.Default.Save();
        }

        private void shoeSizeText_Click(object sender, EventArgs e)
        {
            shoeSizeText.Text = "";
        }

        private void shoeSizeKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
