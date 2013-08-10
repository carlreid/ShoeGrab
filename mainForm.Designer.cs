namespace ShoeGrab
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            this.managerButton = new MetroFramework.Controls.MetroTile();
            this.updatePanel = new MetroFramework.Controls.MetroPanel();
            this.qrCodeBitcoinPicture = new System.Windows.Forms.PictureBox();
            this.rsvpEnabledLabel = new MetroFramework.Controls.MetroLabel();
            this.linkSniperEnabledLabel = new MetroFramework.Controls.MetroLabel();
            this.tweetsCheckedCounterLabel = new System.Windows.Forms.Label();
            this.tweetsCheckedLabel = new MetroFramework.Controls.MetroLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.usernameLabel = new MetroFramework.Controls.MetroLabel();
            this.userAvatar = new System.Windows.Forms.PictureBox();
            this.lastTweetLabel = new MetroFramework.Controls.MetroLabel();
            this.webBackButton = new MetroFramework.Controls.MetroButton();
            this.webForwardButton = new MetroFramework.Controls.MetroButton();
            this.dashboardButton = new MetroFramework.Controls.MetroTile();
            this.webView = new Awesomium.Windows.Forms.WebControl(this.components);
            this.webviewButton = new MetroFramework.Controls.MetroTile();
            this.settingsButton = new MetroFramework.Controls.MetroTile();
            this.bitcoinAdrLink = new MetroFramework.Controls.MetroLink();
            this.donateLabel = new MetroFramework.Controls.MetroLabel();
            this.updatePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qrCodeBitcoinPicture)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // managerButton
            // 
            this.managerButton.ActiveControl = null;
            this.managerButton.Enabled = false;
            this.managerButton.Location = new System.Drawing.Point(23, 63);
            this.managerButton.Name = "managerButton";
            this.managerButton.Size = new System.Drawing.Size(100, 100);
            this.managerButton.Style = MetroFramework.MetroColorStyle.Black;
            this.managerButton.TabIndex = 2;
            this.managerButton.Text = "Manage\r\nKey Words";
            this.managerButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.managerButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.managerButton.UseSelectable = true;
            this.managerButton.UseStyleColors = true;
            this.managerButton.EnabledChanged += new System.EventHandler(this.managerEnabled);
            this.managerButton.Click += new System.EventHandler(this.managerButton_Click);
            // 
            // updatePanel
            // 
            this.updatePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updatePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.updatePanel.Controls.Add(this.qrCodeBitcoinPicture);
            this.updatePanel.Controls.Add(this.rsvpEnabledLabel);
            this.updatePanel.Controls.Add(this.linkSniperEnabledLabel);
            this.updatePanel.Controls.Add(this.tweetsCheckedCounterLabel);
            this.updatePanel.Controls.Add(this.tweetsCheckedLabel);
            this.updatePanel.Controls.Add(this.tableLayoutPanel1);
            this.updatePanel.Controls.Add(this.lastTweetLabel);
            this.updatePanel.HorizontalScrollbarBarColor = true;
            this.updatePanel.HorizontalScrollbarHighlightOnWheel = false;
            this.updatePanel.HorizontalScrollbarSize = 10;
            this.updatePanel.Location = new System.Drawing.Point(133, 63);
            this.updatePanel.Name = "updatePanel";
            this.updatePanel.Size = new System.Drawing.Size(1279, 541);
            this.updatePanel.TabIndex = 3;
            this.updatePanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.updatePanel.VerticalScrollbarBarColor = true;
            this.updatePanel.VerticalScrollbarHighlightOnWheel = false;
            this.updatePanel.VerticalScrollbarSize = 10;
            this.updatePanel.Visible = false;
            // 
            // qrCodeBitcoinPicture
            // 
            this.qrCodeBitcoinPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.qrCodeBitcoinPicture.Image = global::ShoeGrab.Properties.Resources.qr;
            this.qrCodeBitcoinPicture.Location = new System.Drawing.Point(1176, 439);
            this.qrCodeBitcoinPicture.Name = "qrCodeBitcoinPicture";
            this.qrCodeBitcoinPicture.Size = new System.Drawing.Size(100, 100);
            this.qrCodeBitcoinPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.qrCodeBitcoinPicture.TabIndex = 10;
            this.qrCodeBitcoinPicture.TabStop = false;
            // 
            // rsvpEnabledLabel
            // 
            this.rsvpEnabledLabel.AutoSize = true;
            this.rsvpEnabledLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.rsvpEnabledLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.rsvpEnabledLabel.ForeColor = System.Drawing.Color.Red;
            this.rsvpEnabledLabel.Location = new System.Drawing.Point(92, 21);
            this.rsvpEnabledLabel.Name = "rsvpEnabledLabel";
            this.rsvpEnabledLabel.Size = new System.Drawing.Size(140, 25);
            this.rsvpEnabledLabel.TabIndex = 9;
            this.rsvpEnabledLabel.Text = "RSVP: Disabled";
            this.rsvpEnabledLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.rsvpEnabledLabel.UseCustomForeColor = true;
            // 
            // linkSniperEnabledLabel
            // 
            this.linkSniperEnabledLabel.AutoSize = true;
            this.linkSniperEnabledLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.linkSniperEnabledLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.linkSniperEnabledLabel.ForeColor = System.Drawing.Color.Red;
            this.linkSniperEnabledLabel.Location = new System.Drawing.Point(42, 46);
            this.linkSniperEnabledLabel.Name = "linkSniperEnabledLabel";
            this.linkSniperEnabledLabel.Size = new System.Drawing.Size(190, 25);
            this.linkSniperEnabledLabel.TabIndex = 8;
            this.linkSniperEnabledLabel.Text = "Link Sniper: Disabled";
            this.linkSniperEnabledLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.linkSniperEnabledLabel.UseCustomForeColor = true;
            // 
            // tweetsCheckedCounterLabel
            // 
            this.tweetsCheckedCounterLabel.AutoSize = true;
            this.tweetsCheckedCounterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tweetsCheckedCounterLabel.ForeColor = System.Drawing.Color.White;
            this.tweetsCheckedCounterLabel.Location = new System.Drawing.Point(45, 189);
            this.tweetsCheckedCounterLabel.Name = "tweetsCheckedCounterLabel";
            this.tweetsCheckedCounterLabel.Size = new System.Drawing.Size(98, 108);
            this.tweetsCheckedCounterLabel.TabIndex = 7;
            this.tweetsCheckedCounterLabel.Text = "0";
            // 
            // tweetsCheckedLabel
            // 
            this.tweetsCheckedLabel.AutoSize = true;
            this.tweetsCheckedLabel.Location = new System.Drawing.Point(42, 160);
            this.tweetsCheckedLabel.Name = "tweetsCheckedLabel";
            this.tweetsCheckedLabel.Size = new System.Drawing.Size(101, 19);
            this.tweetsCheckedLabel.TabIndex = 6;
            this.tweetsCheckedLabel.Text = "Tweets Checked";
            this.tweetsCheckedLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.usernameLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.userAvatar, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1074, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(202, 97);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.usernameLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.usernameLabel.ForeColor = System.Drawing.Color.White;
            this.usernameLabel.Location = new System.Drawing.Point(137, 70);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(62, 25);
            this.usernameLabel.TabIndex = 3;
            this.usernameLabel.Text = "Name";
            this.usernameLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.usernameLabel.UseCustomBackColor = true;
            this.usernameLabel.UseCustomForeColor = true;
            // 
            // userAvatar
            // 
            this.userAvatar.Location = new System.Drawing.Point(135, 3);
            this.userAvatar.Name = "userAvatar";
            this.userAvatar.Size = new System.Drawing.Size(64, 64);
            this.userAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userAvatar.TabIndex = 4;
            this.userAvatar.TabStop = false;
            // 
            // lastTweetLabel
            // 
            this.lastTweetLabel.AutoSize = true;
            this.lastTweetLabel.Location = new System.Drawing.Point(42, 136);
            this.lastTweetLabel.Name = "lastTweetLabel";
            this.lastTweetLabel.Size = new System.Drawing.Size(1195, 19);
            this.lastTweetLabel.TabIndex = 2;
            this.lastTweetLabel.Text = "Last Tweet: #####################################################################" +
    "#######################################################################";
            this.lastTweetLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // webBackButton
            // 
            this.webBackButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.webBackButton.Enabled = false;
            this.webBackButton.Location = new System.Drawing.Point(694, 19);
            this.webBackButton.Name = "webBackButton";
            this.webBackButton.Size = new System.Drawing.Size(75, 23);
            this.webBackButton.Style = MetroFramework.MetroColorStyle.Green;
            this.webBackButton.TabIndex = 8;
            this.webBackButton.Text = "<<";
            this.webBackButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.webBackButton.UseSelectable = true;
            this.webBackButton.Visible = false;
            this.webBackButton.Click += new System.EventHandler(this.webBackButton_Click);
            // 
            // webForwardButton
            // 
            this.webForwardButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.webForwardButton.Enabled = false;
            this.webForwardButton.Location = new System.Drawing.Point(775, 19);
            this.webForwardButton.Name = "webForwardButton";
            this.webForwardButton.Size = new System.Drawing.Size(75, 23);
            this.webForwardButton.Style = MetroFramework.MetroColorStyle.Green;
            this.webForwardButton.TabIndex = 9;
            this.webForwardButton.Text = ">>";
            this.webForwardButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.webForwardButton.UseSelectable = true;
            this.webForwardButton.Visible = false;
            this.webForwardButton.Click += new System.EventHandler(this.webForwardButton_Click);
            // 
            // dashboardButton
            // 
            this.dashboardButton.ActiveControl = null;
            this.dashboardButton.Enabled = false;
            this.dashboardButton.Location = new System.Drawing.Point(23, 169);
            this.dashboardButton.Name = "dashboardButton";
            this.dashboardButton.Size = new System.Drawing.Size(100, 100);
            this.dashboardButton.Style = MetroFramework.MetroColorStyle.Black;
            this.dashboardButton.TabIndex = 10;
            this.dashboardButton.Text = "Dashboard";
            this.dashboardButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dashboardButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.dashboardButton.UseSelectable = true;
            this.dashboardButton.UseStyleColors = true;
            this.dashboardButton.EnabledChanged += new System.EventHandler(this.dashboardEnable);
            this.dashboardButton.Click += new System.EventHandler(this.dashboardButton_Click);
            // 
            // webView
            // 
            this.webView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView.Location = new System.Drawing.Point(133, 50);
            this.webView.Size = new System.Drawing.Size(1279, 554);
            this.webView.TabIndex = 11;
            // 
            // webviewButton
            // 
            this.webviewButton.ActiveControl = null;
            this.webviewButton.Enabled = false;
            this.webviewButton.Location = new System.Drawing.Point(23, 275);
            this.webviewButton.Name = "webviewButton";
            this.webviewButton.Size = new System.Drawing.Size(100, 100);
            this.webviewButton.Style = MetroFramework.MetroColorStyle.Black;
            this.webviewButton.TabIndex = 12;
            this.webviewButton.Text = "Web View";
            this.webviewButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.webviewButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.webviewButton.UseSelectable = true;
            this.webviewButton.EnabledChanged += new System.EventHandler(this.webviewEnabled);
            this.webviewButton.Click += new System.EventHandler(this.webviewButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.ActiveControl = null;
            this.settingsButton.Enabled = false;
            this.settingsButton.Location = new System.Drawing.Point(23, 381);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(100, 100);
            this.settingsButton.Style = MetroFramework.MetroColorStyle.Black;
            this.settingsButton.TabIndex = 13;
            this.settingsButton.Text = "Settings";
            this.settingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.settingsButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.settingsButton.UseSelectable = true;
            this.settingsButton.EnabledChanged += new System.EventHandler(this.settingEnabled);
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // bitcoinAdrLink
            // 
            this.bitcoinAdrLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bitcoinAdrLink.Location = new System.Drawing.Point(1148, 604);
            this.bitcoinAdrLink.Name = "bitcoinAdrLink";
            this.bitcoinAdrLink.Size = new System.Drawing.Size(263, 23);
            this.bitcoinAdrLink.TabIndex = 8;
            this.bitcoinAdrLink.Text = "1PVZw93m99c9u72jShcrYxwe75P2tjURCh";
            this.bitcoinAdrLink.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.bitcoinAdrLink.UseSelectable = true;
            this.bitcoinAdrLink.Click += new System.EventHandler(this.bitcoinAdrLink_Click);
            // 
            // donateLabel
            // 
            this.donateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.donateLabel.AutoSize = true;
            this.donateLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.donateLabel.Location = new System.Drawing.Point(1099, 605);
            this.donateLabel.Name = "donateLabel";
            this.donateLabel.Size = new System.Drawing.Size(57, 19);
            this.donateLabel.TabIndex = 8;
            this.donateLabel.Text = "Donate:";
            this.donateLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 627);
            this.Controls.Add(this.donateLabel);
            this.Controls.Add(this.bitcoinAdrLink);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.webviewButton);
            this.Controls.Add(this.dashboardButton);
            this.Controls.Add(this.updatePanel);
            this.Controls.Add(this.webForwardButton);
            this.Controls.Add(this.webBackButton);
            this.Controls.Add(this.managerButton);
            this.Controls.Add(this.webView);
            this.MinimumSize = new System.Drawing.Size(1432, 627);
            this.Name = "mainForm";
            this.Text = "ShoeGrab";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.updatePanel.ResumeLayout(false);
            this.updatePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qrCodeBitcoinPicture)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private MetroFramework.Controls.MetroTile managerButton;
        private MetroFramework.Controls.MetroPanel updatePanel;
        private MetroFramework.Controls.MetroLabel lastTweetLabel;
        private MetroFramework.Controls.MetroLabel usernameLabel;
        private System.Windows.Forms.PictureBox userAvatar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroLabel tweetsCheckedLabel;
        private System.Windows.Forms.Label tweetsCheckedCounterLabel;
        private MetroFramework.Controls.MetroButton webBackButton;
        private MetroFramework.Controls.MetroButton webForwardButton;
        private MetroFramework.Controls.MetroTile dashboardButton;
        private Awesomium.Windows.Forms.WebControl webView;
        private MetroFramework.Controls.MetroTile webviewButton;
        private MetroFramework.Controls.MetroTile settingsButton;
        private MetroFramework.Controls.MetroLink bitcoinAdrLink;
        private MetroFramework.Controls.MetroLabel donateLabel;
        private MetroFramework.Controls.MetroLabel linkSniperEnabledLabel;
        private MetroFramework.Controls.MetroLabel rsvpEnabledLabel;
        private System.Windows.Forms.PictureBox qrCodeBitcoinPicture;
    }
}

