namespace ShoeGrab
{
    partial class SettingsTweaker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.browserExeLabel = new MetroFramework.Controls.MetroLabel();
            this.browserPathTextBox = new MetroFramework.Controls.MetroTextBox();
            this.browserSettingsGroup = new System.Windows.Forms.GroupBox();
            this.useCustomBrowser = new MetroFramework.Controls.MetroRadioButton();
            this.useDefaultRadio = new MetroFramework.Controls.MetroRadioButton();
            this.useBuiltInRadio = new MetroFramework.Controls.MetroRadioButton();
            this.helpLabel = new MetroFramework.Controls.MetroLabel();
            this.autoCheckoutLabel = new MetroFramework.Controls.MetroLabel();
            this.checkoutGroup = new System.Windows.Forms.GroupBox();
            this.checkoutEnabledToggle = new MetroFramework.Controls.MetroToggle();
            this.checkoutEnabledLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.shoeSizeText = new MetroFramework.Controls.MetroTextBox();
            this.nikeNikePLoginLabel = new MetroFramework.Controls.MetroLabel();
            this.nikeLoginEmailText = new MetroFramework.Controls.MetroTextBox();
            this.nikeLoginGroup = new System.Windows.Forms.GroupBox();
            this.nikeLoginEmail = new MetroFramework.Controls.MetroLabel();
            this.nikeLoginPassword = new MetroFramework.Controls.MetroLabel();
            this.nikeLoginPasswordText = new MetroFramework.Controls.MetroTextBox();
            this.plainTextLabel = new MetroFramework.Controls.MetroLabel();
            this.checkoutNikeRadio = new MetroFramework.Controls.MetroRadioButton();
            this.checkoutGuestRadio = new MetroFramework.Controls.MetroRadioButton();
            this.checkoutPaypalRadio = new MetroFramework.Controls.MetroRadioButton();
            this.browserSettingsGroup.SuspendLayout();
            this.checkoutGroup.SuspendLayout();
            this.nikeLoginGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // browserExeLabel
            // 
            this.browserExeLabel.AutoSize = true;
            this.browserExeLabel.Location = new System.Drawing.Point(6, -4);
            this.browserExeLabel.Name = "browserExeLabel";
            this.browserExeLabel.Size = new System.Drawing.Size(108, 19);
            this.browserExeLabel.TabIndex = 0;
            this.browserExeLabel.Text = "Browser Settings:";
            this.browserExeLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // browserPathTextBox
            // 
            this.browserPathTextBox.Location = new System.Drawing.Point(152, 60);
            this.browserPathTextBox.MaxLength = 32767;
            this.browserPathTextBox.Name = "browserPathTextBox";
            this.browserPathTextBox.PasswordChar = '\0';
            this.browserPathTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.browserPathTextBox.SelectedText = "";
            this.browserPathTextBox.Size = new System.Drawing.Size(295, 23);
            this.browserPathTextBox.TabIndex = 1;
            this.browserPathTextBox.Text = "Point to your browser.";
            this.browserPathTextBox.UseSelectable = true;
            this.browserPathTextBox.Visible = false;
            this.browserPathTextBox.Click += new System.EventHandler(this.browserPathTextBox_Click);
            // 
            // browserSettingsGroup
            // 
            this.browserSettingsGroup.Controls.Add(this.useCustomBrowser);
            this.browserSettingsGroup.Controls.Add(this.browserExeLabel);
            this.browserSettingsGroup.Controls.Add(this.useDefaultRadio);
            this.browserSettingsGroup.Controls.Add(this.browserPathTextBox);
            this.browserSettingsGroup.Controls.Add(this.useBuiltInRadio);
            this.browserSettingsGroup.Location = new System.Drawing.Point(23, 63);
            this.browserSettingsGroup.Name = "browserSettingsGroup";
            this.browserSettingsGroup.Size = new System.Drawing.Size(464, 100);
            this.browserSettingsGroup.TabIndex = 5;
            this.browserSettingsGroup.TabStop = false;
            // 
            // useCustomBrowser
            // 
            this.useCustomBrowser.AutoSize = true;
            this.useCustomBrowser.Location = new System.Drawing.Point(11, 62);
            this.useCustomBrowser.Name = "useCustomBrowser";
            this.useCustomBrowser.Size = new System.Drawing.Size(135, 15);
            this.useCustomBrowser.TabIndex = 8;
            this.useCustomBrowser.Text = "Use Custom Browser:";
            this.useCustomBrowser.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.useCustomBrowser.UseSelectable = true;
            this.useCustomBrowser.CheckedChanged += new System.EventHandler(this.customBrowserChecked);
            // 
            // useDefaultRadio
            // 
            this.useDefaultRadio.AutoSize = true;
            this.useDefaultRadio.Location = new System.Drawing.Point(11, 41);
            this.useDefaultRadio.Name = "useDefaultRadio";
            this.useDefaultRadio.Size = new System.Drawing.Size(128, 15);
            this.useDefaultRadio.TabIndex = 7;
            this.useDefaultRadio.Text = "Use Default Browser";
            this.useDefaultRadio.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.useDefaultRadio.UseSelectable = true;
            // 
            // useBuiltInRadio
            // 
            this.useBuiltInRadio.AutoSize = true;
            this.useBuiltInRadio.Checked = true;
            this.useBuiltInRadio.Location = new System.Drawing.Point(11, 20);
            this.useBuiltInRadio.Name = "useBuiltInRadio";
            this.useBuiltInRadio.Size = new System.Drawing.Size(129, 15);
            this.useBuiltInRadio.TabIndex = 6;
            this.useBuiltInRadio.TabStop = true;
            this.useBuiltInRadio.Text = "Use Built-in Browser";
            this.useBuiltInRadio.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.useBuiltInRadio.UseSelectable = true;
            // 
            // helpLabel
            // 
            this.helpLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.helpLabel.AutoSize = true;
            this.helpLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.helpLabel.Location = new System.Drawing.Point(83, 349);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(346, 19);
            this.helpLabel.TabIndex = 6;
            this.helpLabel.Text = "All changes are saved when you close this window.";
            this.helpLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // autoCheckoutLabel
            // 
            this.autoCheckoutLabel.AutoSize = true;
            this.autoCheckoutLabel.Location = new System.Drawing.Point(28, 171);
            this.autoCheckoutLabel.Name = "autoCheckoutLabel";
            this.autoCheckoutLabel.Size = new System.Drawing.Size(261, 19);
            this.autoCheckoutLabel.TabIndex = 9;
            this.autoCheckoutLabel.Text = "Auto Checkout Settings:    (Built in Browser)";
            this.autoCheckoutLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // checkoutGroup
            // 
            this.checkoutGroup.Controls.Add(this.checkoutPaypalRadio);
            this.checkoutGroup.Controls.Add(this.checkoutGuestRadio);
            this.checkoutGroup.Controls.Add(this.checkoutNikeRadio);
            this.checkoutGroup.Controls.Add(this.plainTextLabel);
            this.checkoutGroup.Controls.Add(this.nikeLoginGroup);
            this.checkoutGroup.Controls.Add(this.shoeSizeText);
            this.checkoutGroup.Controls.Add(this.metroLabel1);
            this.checkoutGroup.Controls.Add(this.checkoutEnabledLabel);
            this.checkoutGroup.Controls.Add(this.checkoutEnabledToggle);
            this.checkoutGroup.Location = new System.Drawing.Point(23, 175);
            this.checkoutGroup.Name = "checkoutGroup";
            this.checkoutGroup.Size = new System.Drawing.Size(464, 148);
            this.checkoutGroup.TabIndex = 10;
            this.checkoutGroup.TabStop = false;
            // 
            // checkoutEnabledToggle
            // 
            this.checkoutEnabledToggle.AutoSize = true;
            this.checkoutEnabledToggle.Location = new System.Drawing.Point(371, 16);
            this.checkoutEnabledToggle.Name = "checkoutEnabledToggle";
            this.checkoutEnabledToggle.Size = new System.Drawing.Size(80, 17);
            this.checkoutEnabledToggle.Style = MetroFramework.MetroColorStyle.Green;
            this.checkoutEnabledToggle.TabIndex = 0;
            this.checkoutEnabledToggle.Text = "Off";
            this.checkoutEnabledToggle.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.checkoutEnabledToggle.UseSelectable = true;
            // 
            // checkoutEnabledLabel
            // 
            this.checkoutEnabledLabel.AutoSize = true;
            this.checkoutEnabledLabel.FontSize = MetroFramework.MetroLabelSize.Small;
            this.checkoutEnabledLabel.Location = new System.Drawing.Point(321, 17);
            this.checkoutEnabledLabel.Name = "checkoutEnabledLabel";
            this.checkoutEnabledLabel.Size = new System.Drawing.Size(50, 15);
            this.checkoutEnabledLabel.TabIndex = 1;
            this.checkoutEnabledLabel.Text = "Enabled:";
            this.checkoutEnabledLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.Location = new System.Drawing.Point(10, 101);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(58, 15);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Shoe Size:";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // shoeSizeText
            // 
            this.shoeSizeText.Location = new System.Drawing.Point(69, 98);
            this.shoeSizeText.MaxLength = 32767;
            this.shoeSizeText.Name = "shoeSizeText";
            this.shoeSizeText.PasswordChar = '\0';
            this.shoeSizeText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.shoeSizeText.SelectedText = "";
            this.shoeSizeText.Size = new System.Drawing.Size(27, 23);
            this.shoeSizeText.TabIndex = 3;
            this.shoeSizeText.Text = "11";
            this.shoeSizeText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.shoeSizeText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.shoeSizeText.UseSelectable = true;
            this.shoeSizeText.Click += new System.EventHandler(this.shoeSizeText_Click);
            this.shoeSizeText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.shoeSizeKeyPress);
            // 
            // nikeNikePLoginLabel
            // 
            this.nikeNikePLoginLabel.AutoSize = true;
            this.nikeNikePLoginLabel.FontSize = MetroFramework.MetroLabelSize.Small;
            this.nikeNikePLoginLabel.Location = new System.Drawing.Point(7, -1);
            this.nikeNikePLoginLabel.Name = "nikeNikePLoginLabel";
            this.nikeNikePLoginLabel.Size = new System.Drawing.Size(96, 15);
            this.nikeNikePLoginLabel.TabIndex = 4;
            this.nikeNikePLoginLabel.Text = "Nike/Nike+ Login:";
            this.nikeNikePLoginLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // nikeLoginEmailText
            // 
            this.nikeLoginEmailText.Location = new System.Drawing.Point(63, 20);
            this.nikeLoginEmailText.MaxLength = 256;
            this.nikeLoginEmailText.Name = "nikeLoginEmailText";
            this.nikeLoginEmailText.PasswordChar = '\0';
            this.nikeLoginEmailText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nikeLoginEmailText.SelectedText = "";
            this.nikeLoginEmailText.Size = new System.Drawing.Size(263, 23);
            this.nikeLoginEmailText.Style = MetroFramework.MetroColorStyle.Blue;
            this.nikeLoginEmailText.TabIndex = 5;
            this.nikeLoginEmailText.Text = "email@email.com";
            this.nikeLoginEmailText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.nikeLoginEmailText.UseSelectable = true;
            // 
            // nikeLoginGroup
            // 
            this.nikeLoginGroup.Controls.Add(this.nikeLoginPassword);
            this.nikeLoginGroup.Controls.Add(this.nikeLoginPasswordText);
            this.nikeLoginGroup.Controls.Add(this.nikeLoginEmail);
            this.nikeLoginGroup.Controls.Add(this.nikeNikePLoginLabel);
            this.nikeLoginGroup.Controls.Add(this.nikeLoginEmailText);
            this.nikeLoginGroup.Location = new System.Drawing.Point(113, 37);
            this.nikeLoginGroup.Name = "nikeLoginGroup";
            this.nikeLoginGroup.Size = new System.Drawing.Size(338, 78);
            this.nikeLoginGroup.TabIndex = 6;
            this.nikeLoginGroup.TabStop = false;
            // 
            // nikeLoginEmail
            // 
            this.nikeLoginEmail.AutoSize = true;
            this.nikeLoginEmail.FontSize = MetroFramework.MetroLabelSize.Small;
            this.nikeLoginEmail.Location = new System.Drawing.Point(27, 24);
            this.nikeLoginEmail.Name = "nikeLoginEmail";
            this.nikeLoginEmail.Size = new System.Drawing.Size(36, 15);
            this.nikeLoginEmail.TabIndex = 6;
            this.nikeLoginEmail.Text = "Email:";
            this.nikeLoginEmail.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // nikeLoginPassword
            // 
            this.nikeLoginPassword.AutoSize = true;
            this.nikeLoginPassword.FontSize = MetroFramework.MetroLabelSize.Small;
            this.nikeLoginPassword.Location = new System.Drawing.Point(5, 51);
            this.nikeLoginPassword.Name = "nikeLoginPassword";
            this.nikeLoginPassword.Size = new System.Drawing.Size(58, 15);
            this.nikeLoginPassword.TabIndex = 8;
            this.nikeLoginPassword.Text = "Password:";
            this.nikeLoginPassword.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // nikeLoginPasswordText
            // 
            this.nikeLoginPasswordText.Location = new System.Drawing.Point(63, 47);
            this.nikeLoginPasswordText.MaxLength = 31;
            this.nikeLoginPasswordText.Name = "nikeLoginPasswordText";
            this.nikeLoginPasswordText.PasswordChar = '✓';
            this.nikeLoginPasswordText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nikeLoginPasswordText.SelectedText = "";
            this.nikeLoginPasswordText.Size = new System.Drawing.Size(263, 23);
            this.nikeLoginPasswordText.Style = MetroFramework.MetroColorStyle.Blue;
            this.nikeLoginPasswordText.TabIndex = 7;
            this.nikeLoginPasswordText.Text = "password";
            this.nikeLoginPasswordText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.nikeLoginPasswordText.UseSelectable = true;
            // 
            // plainTextLabel
            // 
            this.plainTextLabel.AutoSize = true;
            this.plainTextLabel.FontSize = MetroFramework.MetroLabelSize.Small;
            this.plainTextLabel.Location = new System.Drawing.Point(125, 123);
            this.plainTextLabel.Name = "plainTextLabel";
            this.plainTextLabel.Size = new System.Drawing.Size(214, 15);
            this.plainTextLabel.TabIndex = 9;
            this.plainTextLabel.Text = "All login information is stored in plain text.";
            this.plainTextLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // checkoutNikeRadio
            // 
            this.checkoutNikeRadio.AutoSize = true;
            this.checkoutNikeRadio.Checked = true;
            this.checkoutNikeRadio.Location = new System.Drawing.Point(11, 25);
            this.checkoutNikeRadio.Name = "checkoutNikeRadio";
            this.checkoutNikeRadio.Size = new System.Drawing.Size(84, 15);
            this.checkoutNikeRadio.TabIndex = 9;
            this.checkoutNikeRadio.Text = "Nike/Nike+";
            this.checkoutNikeRadio.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.checkoutNikeRadio.UseSelectable = true;
            // 
            // checkoutGuestRadio
            // 
            this.checkoutGuestRadio.AutoSize = true;
            this.checkoutGuestRadio.Location = new System.Drawing.Point(11, 46);
            this.checkoutGuestRadio.Name = "checkoutGuestRadio";
            this.checkoutGuestRadio.Size = new System.Drawing.Size(53, 15);
            this.checkoutGuestRadio.TabIndex = 10;
            this.checkoutGuestRadio.Text = "Guest";
            this.checkoutGuestRadio.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.checkoutGuestRadio.UseSelectable = true;
            // 
            // checkoutPaypalRadio
            // 
            this.checkoutPaypalRadio.AutoSize = true;
            this.checkoutPaypalRadio.Location = new System.Drawing.Point(11, 67);
            this.checkoutPaypalRadio.Name = "checkoutPaypalRadio";
            this.checkoutPaypalRadio.Size = new System.Drawing.Size(58, 15);
            this.checkoutPaypalRadio.TabIndex = 11;
            this.checkoutPaypalRadio.Text = "PayPal";
            this.checkoutPaypalRadio.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.checkoutPaypalRadio.UseSelectable = true;
            // 
            // SettingsTweaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 390);
            this.Controls.Add(this.autoCheckoutLabel);
            this.Controls.Add(this.checkoutGroup);
            this.Controls.Add(this.helpLabel);
            this.Controls.Add(this.browserSettingsGroup);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(518, 390);
            this.MinimumSize = new System.Drawing.Size(518, 390);
            this.Name = "SettingsTweaker";
            this.Resizable = false;
            this.Text = "Settings";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClosing);
            this.browserSettingsGroup.ResumeLayout(false);
            this.browserSettingsGroup.PerformLayout();
            this.checkoutGroup.ResumeLayout(false);
            this.checkoutGroup.PerformLayout();
            this.nikeLoginGroup.ResumeLayout(false);
            this.nikeLoginGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel browserExeLabel;
        private MetroFramework.Controls.MetroTextBox browserPathTextBox;
        private System.Windows.Forms.GroupBox browserSettingsGroup;
        private MetroFramework.Controls.MetroRadioButton useCustomBrowser;
        private MetroFramework.Controls.MetroRadioButton useDefaultRadio;
        private MetroFramework.Controls.MetroRadioButton useBuiltInRadio;
        private MetroFramework.Controls.MetroLabel helpLabel;
        private MetroFramework.Controls.MetroLabel autoCheckoutLabel;
        private System.Windows.Forms.GroupBox checkoutGroup;
        private MetroFramework.Controls.MetroLabel checkoutEnabledLabel;
        private MetroFramework.Controls.MetroToggle checkoutEnabledToggle;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox shoeSizeText;
        private System.Windows.Forms.GroupBox nikeLoginGroup;
        private MetroFramework.Controls.MetroLabel nikeLoginPassword;
        private MetroFramework.Controls.MetroTextBox nikeLoginPasswordText;
        private MetroFramework.Controls.MetroLabel nikeLoginEmail;
        private MetroFramework.Controls.MetroLabel nikeNikePLoginLabel;
        private MetroFramework.Controls.MetroTextBox nikeLoginEmailText;
        private MetroFramework.Controls.MetroLabel plainTextLabel;
        private MetroFramework.Controls.MetroRadioButton checkoutNikeRadio;
        private MetroFramework.Controls.MetroRadioButton checkoutPaypalRadio;
        private MetroFramework.Controls.MetroRadioButton checkoutGuestRadio;
    }
}