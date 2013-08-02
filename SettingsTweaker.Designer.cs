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
            this.checkoutPaypalRadio = new MetroFramework.Controls.MetroRadioButton();
            this.checkoutGuestRadio = new MetroFramework.Controls.MetroRadioButton();
            this.checkoutNikeRadio = new MetroFramework.Controls.MetroRadioButton();
            this.plainTextLabel = new MetroFramework.Controls.MetroLabel();
            this.nikeLoginGroup = new System.Windows.Forms.GroupBox();
            this.nikeLoginPassword = new MetroFramework.Controls.MetroLabel();
            this.nikeLoginPasswordText = new MetroFramework.Controls.MetroTextBox();
            this.nikeLoginEmail = new MetroFramework.Controls.MetroLabel();
            this.nikeNikePLoginLabel = new MetroFramework.Controls.MetroLabel();
            this.nikeLoginEmailText = new MetroFramework.Controls.MetroTextBox();
            this.checkoutEnabledLabel = new MetroFramework.Controls.MetroLabel();
            this.checkoutEnabledToggle = new MetroFramework.Controls.MetroToggle();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.shoeSizeText = new MetroFramework.Controls.MetroTextBox();
            this.rsvpSettingsLabel = new MetroFramework.Controls.MetroLabel();
            this.rsvpGroup = new System.Windows.Forms.GroupBox();
            this.lastNameText = new MetroFramework.Controls.MetroTextBox();
            this.firstNameText = new MetroFramework.Controls.MetroTextBox();
            this.lastNameLabel = new MetroFramework.Controls.MetroLabel();
            this.firstNameLabel = new MetroFramework.Controls.MetroLabel();
            this.rsvpEnabledToggle = new MetroFramework.Controls.MetroToggle();
            this.rsvpEnabledLabel = new MetroFramework.Controls.MetroLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.linkSniperEnabledLabel = new MetroFramework.Controls.MetroLabel();
            this.linkEnabledToggle = new MetroFramework.Controls.MetroToggle();
            this.rsvpKeywordText = new MetroFramework.Controls.MetroTextBox();
            this.rsvpKeyWordLabel = new MetroFramework.Controls.MetroLabel();
            this.browserSettingsGroup.SuspendLayout();
            this.checkoutGroup.SuspendLayout();
            this.nikeLoginGroup.SuspendLayout();
            this.rsvpGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // browserExeLabel
            // 
            this.browserExeLabel.AutoSize = true;
            this.browserExeLabel.Location = new System.Drawing.Point(6, -4);
            this.browserExeLabel.Name = "browserExeLabel";
            this.browserExeLabel.Size = new System.Drawing.Size(60, 19);
            this.browserExeLabel.TabIndex = 0;
            this.browserExeLabel.Text = "Browser:";
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
            this.browserPathTextBox.TabIndex = 5;
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
            this.useCustomBrowser.TabIndex = 4;
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
            this.useDefaultRadio.TabIndex = 3;
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
            this.useBuiltInRadio.TabIndex = 2;
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
            this.helpLabel.Location = new System.Drawing.Point(83, 485);
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
            this.autoCheckoutLabel.Size = new System.Drawing.Size(212, 19);
            this.autoCheckoutLabel.TabIndex = 9;
            this.autoCheckoutLabel.Text = "Auto Checkout:    (Built in Browser)";
            this.autoCheckoutLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // checkoutGroup
            // 
            this.checkoutGroup.Controls.Add(this.checkoutPaypalRadio);
            this.checkoutGroup.Controls.Add(this.checkoutGuestRadio);
            this.checkoutGroup.Controls.Add(this.checkoutNikeRadio);
            this.checkoutGroup.Controls.Add(this.plainTextLabel);
            this.checkoutGroup.Controls.Add(this.nikeLoginGroup);
            this.checkoutGroup.Controls.Add(this.checkoutEnabledLabel);
            this.checkoutGroup.Controls.Add(this.checkoutEnabledToggle);
            this.checkoutGroup.Location = new System.Drawing.Point(23, 175);
            this.checkoutGroup.Name = "checkoutGroup";
            this.checkoutGroup.Size = new System.Drawing.Size(464, 134);
            this.checkoutGroup.TabIndex = 10;
            this.checkoutGroup.TabStop = false;
            // 
            // checkoutPaypalRadio
            // 
            this.checkoutPaypalRadio.AutoSize = true;
            this.checkoutPaypalRadio.Location = new System.Drawing.Point(11, 67);
            this.checkoutPaypalRadio.Name = "checkoutPaypalRadio";
            this.checkoutPaypalRadio.Size = new System.Drawing.Size(58, 15);
            this.checkoutPaypalRadio.TabIndex = 8;
            this.checkoutPaypalRadio.Text = "PayPal";
            this.checkoutPaypalRadio.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.checkoutPaypalRadio.UseSelectable = true;
            // 
            // checkoutGuestRadio
            // 
            this.checkoutGuestRadio.AutoSize = true;
            this.checkoutGuestRadio.Location = new System.Drawing.Point(11, 46);
            this.checkoutGuestRadio.Name = "checkoutGuestRadio";
            this.checkoutGuestRadio.Size = new System.Drawing.Size(53, 15);
            this.checkoutGuestRadio.TabIndex = 7;
            this.checkoutGuestRadio.Text = "Guest";
            this.checkoutGuestRadio.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.checkoutGuestRadio.UseSelectable = true;
            // 
            // checkoutNikeRadio
            // 
            this.checkoutNikeRadio.AutoSize = true;
            this.checkoutNikeRadio.Checked = true;
            this.checkoutNikeRadio.Location = new System.Drawing.Point(11, 25);
            this.checkoutNikeRadio.Name = "checkoutNikeRadio";
            this.checkoutNikeRadio.Size = new System.Drawing.Size(84, 15);
            this.checkoutNikeRadio.TabIndex = 6;
            this.checkoutNikeRadio.TabStop = true;
            this.checkoutNikeRadio.Text = "Nike/Nike+";
            this.checkoutNikeRadio.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.checkoutNikeRadio.UseSelectable = true;
            // 
            // plainTextLabel
            // 
            this.plainTextLabel.AutoSize = true;
            this.plainTextLabel.FontSize = MetroFramework.MetroLabelSize.Small;
            this.plainTextLabel.Location = new System.Drawing.Point(177, 109);
            this.plainTextLabel.Name = "plainTextLabel";
            this.plainTextLabel.Size = new System.Drawing.Size(214, 15);
            this.plainTextLabel.TabIndex = 9;
            this.plainTextLabel.Text = "All login information is stored in plain text.";
            this.plainTextLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // nikeLoginGroup
            // 
            this.nikeLoginGroup.Controls.Add(this.nikeLoginPassword);
            this.nikeLoginGroup.Controls.Add(this.nikeLoginPasswordText);
            this.nikeLoginGroup.Controls.Add(this.nikeLoginEmail);
            this.nikeLoginGroup.Controls.Add(this.nikeNikePLoginLabel);
            this.nikeLoginGroup.Controls.Add(this.nikeLoginEmailText);
            this.nikeLoginGroup.Location = new System.Drawing.Point(113, 23);
            this.nikeLoginGroup.Name = "nikeLoginGroup";
            this.nikeLoginGroup.Size = new System.Drawing.Size(338, 78);
            this.nikeLoginGroup.TabIndex = 6;
            this.nikeLoginGroup.TabStop = false;
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
            this.nikeLoginPasswordText.TabIndex = 10;
            this.nikeLoginPasswordText.Text = "password";
            this.nikeLoginPasswordText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.nikeLoginPasswordText.UseSelectable = true;
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
            this.nikeLoginEmailText.TabIndex = 9;
            this.nikeLoginEmailText.Text = "email@email.com";
            this.nikeLoginEmailText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.nikeLoginEmailText.UseSelectable = true;
            // 
            // checkoutEnabledLabel
            // 
            this.checkoutEnabledLabel.AutoSize = true;
            this.checkoutEnabledLabel.FontSize = MetroFramework.MetroLabelSize.Small;
            this.checkoutEnabledLabel.Location = new System.Drawing.Point(8, 90);
            this.checkoutEnabledLabel.Name = "checkoutEnabledLabel";
            this.checkoutEnabledLabel.Size = new System.Drawing.Size(50, 15);
            this.checkoutEnabledLabel.TabIndex = 1;
            this.checkoutEnabledLabel.Text = "Enabled:";
            this.checkoutEnabledLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // checkoutEnabledToggle
            // 
            this.checkoutEnabledToggle.AutoSize = true;
            this.checkoutEnabledToggle.Location = new System.Drawing.Point(16, 107);
            this.checkoutEnabledToggle.Name = "checkoutEnabledToggle";
            this.checkoutEnabledToggle.Size = new System.Drawing.Size(80, 17);
            this.checkoutEnabledToggle.Style = MetroFramework.MetroColorStyle.Green;
            this.checkoutEnabledToggle.TabIndex = 11;
            this.checkoutEnabledToggle.Text = "Off";
            this.checkoutEnabledToggle.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.checkoutEnabledToggle.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.Location = new System.Drawing.Point(402, 41);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(58, 15);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Shoe Size:";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // shoeSizeText
            // 
            this.shoeSizeText.Location = new System.Drawing.Point(461, 38);
            this.shoeSizeText.MaxLength = 32767;
            this.shoeSizeText.Name = "shoeSizeText";
            this.shoeSizeText.PasswordChar = '\0';
            this.shoeSizeText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.shoeSizeText.SelectedText = "";
            this.shoeSizeText.Size = new System.Drawing.Size(27, 23);
            this.shoeSizeText.TabIndex = 1;
            this.shoeSizeText.Text = "11";
            this.shoeSizeText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.shoeSizeText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.shoeSizeText.UseSelectable = true;
            this.shoeSizeText.Click += new System.EventHandler(this.shoeSizeText_Click);
            this.shoeSizeText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.shoeSizeKeyPress);
            // 
            // rsvpSettingsLabel
            // 
            this.rsvpSettingsLabel.AutoSize = true;
            this.rsvpSettingsLabel.Location = new System.Drawing.Point(7, -4);
            this.rsvpSettingsLabel.Name = "rsvpSettingsLabel";
            this.rsvpSettingsLabel.Size = new System.Drawing.Size(43, 19);
            this.rsvpSettingsLabel.TabIndex = 11;
            this.rsvpSettingsLabel.Text = "RSVP:";
            this.rsvpSettingsLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // rsvpGroup
            // 
            this.rsvpGroup.Controls.Add(this.rsvpKeywordText);
            this.rsvpGroup.Controls.Add(this.rsvpKeyWordLabel);
            this.rsvpGroup.Controls.Add(this.rsvpEnabledLabel);
            this.rsvpGroup.Controls.Add(this.rsvpEnabledToggle);
            this.rsvpGroup.Controls.Add(this.lastNameText);
            this.rsvpGroup.Controls.Add(this.firstNameText);
            this.rsvpGroup.Controls.Add(this.lastNameLabel);
            this.rsvpGroup.Controls.Add(this.firstNameLabel);
            this.rsvpGroup.Controls.Add(this.rsvpSettingsLabel);
            this.rsvpGroup.Location = new System.Drawing.Point(23, 369);
            this.rsvpGroup.Name = "rsvpGroup";
            this.rsvpGroup.Size = new System.Drawing.Size(465, 96);
            this.rsvpGroup.TabIndex = 12;
            this.rsvpGroup.TabStop = false;
            // 
            // lastNameText
            // 
            this.lastNameText.Location = new System.Drawing.Point(77, 55);
            this.lastNameText.MaxLength = 256;
            this.lastNameText.Name = "lastNameText";
            this.lastNameText.PasswordChar = '\0';
            this.lastNameText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.lastNameText.SelectedText = "";
            this.lastNameText.Size = new System.Drawing.Size(134, 23);
            this.lastNameText.Style = MetroFramework.MetroColorStyle.Blue;
            this.lastNameText.TabIndex = 13;
            this.lastNameText.Text = "Bloggs";
            this.lastNameText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lastNameText.UseSelectable = true;
            // 
            // firstNameText
            // 
            this.firstNameText.Location = new System.Drawing.Point(77, 26);
            this.firstNameText.MaxLength = 256;
            this.firstNameText.Name = "firstNameText";
            this.firstNameText.PasswordChar = '\0';
            this.firstNameText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.firstNameText.SelectedText = "";
            this.firstNameText.Size = new System.Drawing.Size(134, 23);
            this.firstNameText.Style = MetroFramework.MetroColorStyle.Blue;
            this.firstNameText.TabIndex = 12;
            this.firstNameText.Text = "Joe";
            this.firstNameText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.firstNameText.UseSelectable = true;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lastNameLabel.Location = new System.Drawing.Point(7, 58);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(64, 15);
            this.lastNameLabel.TabIndex = 13;
            this.lastNameLabel.Text = "Last Name:";
            this.lastNameLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.FontSize = MetroFramework.MetroLabelSize.Small;
            this.firstNameLabel.Location = new System.Drawing.Point(6, 29);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(65, 15);
            this.firstNameLabel.TabIndex = 12;
            this.firstNameLabel.Text = "First Name:";
            this.firstNameLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // rsvpEnabledToggle
            // 
            this.rsvpEnabledToggle.AutoSize = true;
            this.rsvpEnabledToggle.Location = new System.Drawing.Point(326, 28);
            this.rsvpEnabledToggle.Name = "rsvpEnabledToggle";
            this.rsvpEnabledToggle.Size = new System.Drawing.Size(80, 17);
            this.rsvpEnabledToggle.Style = MetroFramework.MetroColorStyle.Green;
            this.rsvpEnabledToggle.TabIndex = 14;
            this.rsvpEnabledToggle.Text = "Off";
            this.rsvpEnabledToggle.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.rsvpEnabledToggle.UseSelectable = true;
            // 
            // rsvpEnabledLabel
            // 
            this.rsvpEnabledLabel.AutoSize = true;
            this.rsvpEnabledLabel.FontSize = MetroFramework.MetroLabelSize.Small;
            this.rsvpEnabledLabel.Location = new System.Drawing.Point(270, 28);
            this.rsvpEnabledLabel.Name = "rsvpEnabledLabel";
            this.rsvpEnabledLabel.Size = new System.Drawing.Size(50, 15);
            this.rsvpEnabledLabel.TabIndex = 15;
            this.rsvpEnabledLabel.Text = "Enabled:";
            this.rsvpEnabledLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkEnabledToggle);
            this.groupBox1.Controls.Add(this.linkSniperEnabledLabel);
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Location = new System.Drawing.Point(23, 318);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 42);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(6, -4);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(76, 19);
            this.metroLabel2.TabIndex = 12;
            this.metroLabel2.Text = "Link Sniper:";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // linkSniperEnabledLabel
            // 
            this.linkSniperEnabledLabel.AutoSize = true;
            this.linkSniperEnabledLabel.FontSize = MetroFramework.MetroLabelSize.Small;
            this.linkSniperEnabledLabel.Location = new System.Drawing.Point(171, 15);
            this.linkSniperEnabledLabel.Name = "linkSniperEnabledLabel";
            this.linkSniperEnabledLabel.Size = new System.Drawing.Size(50, 15);
            this.linkSniperEnabledLabel.TabIndex = 16;
            this.linkSniperEnabledLabel.Text = "Enabled:";
            this.linkSniperEnabledLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // linkEnabledToggle
            // 
            this.linkEnabledToggle.AutoSize = true;
            this.linkEnabledToggle.Location = new System.Drawing.Point(219, 14);
            this.linkEnabledToggle.Name = "linkEnabledToggle";
            this.linkEnabledToggle.Size = new System.Drawing.Size(80, 17);
            this.linkEnabledToggle.Style = MetroFramework.MetroColorStyle.Green;
            this.linkEnabledToggle.TabIndex = 17;
            this.linkEnabledToggle.Text = "Off";
            this.linkEnabledToggle.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.linkEnabledToggle.UseSelectable = true;
            // 
            // rsvpKeywordText
            // 
            this.rsvpKeywordText.Location = new System.Drawing.Point(303, 55);
            this.rsvpKeywordText.MaxLength = 256;
            this.rsvpKeywordText.Name = "rsvpKeywordText";
            this.rsvpKeywordText.PasswordChar = '\0';
            this.rsvpKeywordText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.rsvpKeywordText.SelectedText = "";
            this.rsvpKeywordText.Size = new System.Drawing.Size(134, 23);
            this.rsvpKeywordText.Style = MetroFramework.MetroColorStyle.Blue;
            this.rsvpKeywordText.TabIndex = 16;
            this.rsvpKeywordText.Text = "Jordan";
            this.rsvpKeywordText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.rsvpKeywordText.UseSelectable = true;
            // 
            // rsvpKeyWordLabel
            // 
            this.rsvpKeyWordLabel.AutoSize = true;
            this.rsvpKeyWordLabel.FontSize = MetroFramework.MetroLabelSize.Small;
            this.rsvpKeyWordLabel.Location = new System.Drawing.Point(233, 58);
            this.rsvpKeyWordLabel.Name = "rsvpKeyWordLabel";
            this.rsvpKeyWordLabel.Size = new System.Drawing.Size(59, 15);
            this.rsvpKeyWordLabel.TabIndex = 17;
            this.rsvpKeyWordLabel.Text = "Key Word:";
            this.rsvpKeyWordLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // SettingsTweaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 526);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rsvpGroup);
            this.Controls.Add(this.autoCheckoutLabel);
            this.Controls.Add(this.checkoutGroup);
            this.Controls.Add(this.helpLabel);
            this.Controls.Add(this.shoeSizeText);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.browserSettingsGroup);
            this.MaximizeBox = false;
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
            this.rsvpGroup.ResumeLayout(false);
            this.rsvpGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private MetroFramework.Controls.MetroLabel rsvpSettingsLabel;
        private System.Windows.Forms.GroupBox rsvpGroup;
        private MetroFramework.Controls.MetroTextBox lastNameText;
        private MetroFramework.Controls.MetroTextBox firstNameText;
        private MetroFramework.Controls.MetroLabel lastNameLabel;
        private MetroFramework.Controls.MetroLabel firstNameLabel;
        private MetroFramework.Controls.MetroLabel rsvpEnabledLabel;
        private MetroFramework.Controls.MetroToggle rsvpEnabledToggle;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroToggle linkEnabledToggle;
        private MetroFramework.Controls.MetroLabel linkSniperEnabledLabel;
        private MetroFramework.Controls.MetroTextBox rsvpKeywordText;
        private MetroFramework.Controls.MetroLabel rsvpKeyWordLabel;
    }
}