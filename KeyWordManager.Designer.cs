namespace ShoeGrab
{
    partial class KeyWordManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyWordManager));
            this.keyWordLabel = new MetroFramework.Controls.MetroLabel();
            this.keyWordTextBox = new MetroFramework.Controls.MetroTextBox();
            this.userNameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.usernamesLabel = new MetroFramework.Controls.MetroLabel();
            this.acceptKeyWords = new MetroFramework.Controls.MetroButton();
            this.denyKeyWords = new MetroFramework.Controls.MetroButton();
            this.denyUsernames = new MetroFramework.Controls.MetroButton();
            this.acceptUsernames = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.followAllButton = new MetroFramework.Controls.MetroButton();
            this.linkSnipeGroup = new System.Windows.Forms.GroupBox();
            this.linkSnipeLabelText = new MetroFramework.Controls.MetroLabel();
            this.rsvpGroup = new System.Windows.Forms.GroupBox();
            this.rsvpUserNameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.rsvpUsernamesLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.rsvpFollowAllButton = new MetroFramework.Controls.MetroButton();
            this.rsvpDenyUsernames = new MetroFramework.Controls.MetroButton();
            this.rsvpAcceptUsernames = new MetroFramework.Controls.MetroButton();
            this.rsvpKeywordTextBox = new MetroFramework.Controls.MetroTextBox();
            this.rsvpDenyKeyWords = new MetroFramework.Controls.MetroButton();
            this.rsvpAcceptKeyWords = new MetroFramework.Controls.MetroButton();
            this.rsvpKeywordLabel = new MetroFramework.Controls.MetroLabel();
            this.linkSnipeGroup.SuspendLayout();
            this.rsvpGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // keyWordLabel
            // 
            this.keyWordLabel.AutoSize = true;
            this.keyWordLabel.Location = new System.Drawing.Point(30, 27);
            this.keyWordLabel.Name = "keyWordLabel";
            this.keyWordLabel.Size = new System.Drawing.Size(158, 19);
            this.keyWordLabel.TabIndex = 1;
            this.keyWordLabel.Text = "Key Words (One Per Line)";
            this.keyWordLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // keyWordTextBox
            // 
            this.keyWordTextBox.Location = new System.Drawing.Point(22, 51);
            this.keyWordTextBox.MaxLength = 32767;
            this.keyWordTextBox.Multiline = true;
            this.keyWordTextBox.Name = "keyWordTextBox";
            this.keyWordTextBox.PasswordChar = '\0';
            this.keyWordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.keyWordTextBox.SelectedText = "";
            this.keyWordTextBox.Size = new System.Drawing.Size(180, 419);
            this.keyWordTextBox.TabIndex = 4;
            this.keyWordTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.keyWordTextBox.UseSelectable = true;
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(232, 51);
            this.userNameTextBox.MaxLength = 32767;
            this.userNameTextBox.Multiline = true;
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.PasswordChar = '\0';
            this.userNameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.userNameTextBox.SelectedText = "";
            this.userNameTextBox.Size = new System.Drawing.Size(180, 419);
            this.userNameTextBox.TabIndex = 6;
            this.userNameTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.userNameTextBox.UseSelectable = true;
            // 
            // usernamesLabel
            // 
            this.usernamesLabel.AutoSize = true;
            this.usernamesLabel.Location = new System.Drawing.Point(241, 27);
            this.usernamesLabel.Name = "usernamesLabel";
            this.usernamesLabel.Size = new System.Drawing.Size(160, 19);
            this.usernamesLabel.TabIndex = 5;
            this.usernamesLabel.Text = "Usernames (One Per Line)";
            this.usernamesLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // acceptKeyWords
            // 
            this.acceptKeyWords.Highlight = true;
            this.acceptKeyWords.Location = new System.Drawing.Point(132, 476);
            this.acceptKeyWords.Name = "acceptKeyWords";
            this.acceptKeyWords.Size = new System.Drawing.Size(32, 32);
            this.acceptKeyWords.Style = MetroFramework.MetroColorStyle.Green;
            this.acceptKeyWords.TabIndex = 7;
            this.acceptKeyWords.Text = "✓";
            this.acceptKeyWords.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.acceptKeyWords.UseSelectable = true;
            this.acceptKeyWords.Click += new System.EventHandler(this.acceptKeyWords_Click);
            // 
            // denyKeyWords
            // 
            this.denyKeyWords.Highlight = true;
            this.denyKeyWords.Location = new System.Drawing.Point(170, 476);
            this.denyKeyWords.Name = "denyKeyWords";
            this.denyKeyWords.Size = new System.Drawing.Size(32, 32);
            this.denyKeyWords.Style = MetroFramework.MetroColorStyle.Red;
            this.denyKeyWords.TabIndex = 8;
            this.denyKeyWords.Text = "✖";
            this.denyKeyWords.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.denyKeyWords.UseSelectable = true;
            this.denyKeyWords.Click += new System.EventHandler(this.denyKeyWords_Click);
            // 
            // denyUsernames
            // 
            this.denyUsernames.Highlight = true;
            this.denyUsernames.Location = new System.Drawing.Point(380, 476);
            this.denyUsernames.Name = "denyUsernames";
            this.denyUsernames.Size = new System.Drawing.Size(32, 32);
            this.denyUsernames.Style = MetroFramework.MetroColorStyle.Red;
            this.denyUsernames.TabIndex = 10;
            this.denyUsernames.Text = "✖";
            this.denyUsernames.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.denyUsernames.UseSelectable = true;
            this.denyUsernames.Click += new System.EventHandler(this.denyUsernames_Click);
            // 
            // acceptUsernames
            // 
            this.acceptUsernames.Highlight = true;
            this.acceptUsernames.Location = new System.Drawing.Point(342, 476);
            this.acceptUsernames.Name = "acceptUsernames";
            this.acceptUsernames.Size = new System.Drawing.Size(32, 32);
            this.acceptUsernames.Style = MetroFramework.MetroColorStyle.Green;
            this.acceptUsernames.TabIndex = 9;
            this.acceptUsernames.Text = "✓";
            this.acceptUsernames.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.acceptUsernames.UseSelectable = true;
            this.acceptUsernames.Click += new System.EventHandler(this.acceptUsernames_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(78, 601);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(770, 38);
            this.metroLabel2.TabIndex = 11;
            this.metroLabel2.Text = resources.GetString("metroLabel2.Text");
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // followAllButton
            // 
            this.followAllButton.Highlight = true;
            this.followAllButton.Location = new System.Drawing.Point(232, 476);
            this.followAllButton.Name = "followAllButton";
            this.followAllButton.Size = new System.Drawing.Size(80, 32);
            this.followAllButton.Style = MetroFramework.MetroColorStyle.Silver;
            this.followAllButton.TabIndex = 12;
            this.followAllButton.Text = "Follow All";
            this.followAllButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.followAllButton.UseSelectable = true;
            this.followAllButton.Click += new System.EventHandler(this.followAllButton_Click);
            // 
            // linkSnipeGroup
            // 
            this.linkSnipeGroup.Controls.Add(this.linkSnipeLabelText);
            this.linkSnipeGroup.Controls.Add(this.followAllButton);
            this.linkSnipeGroup.Controls.Add(this.usernamesLabel);
            this.linkSnipeGroup.Controls.Add(this.keyWordTextBox);
            this.linkSnipeGroup.Controls.Add(this.denyKeyWords);
            this.linkSnipeGroup.Controls.Add(this.denyUsernames);
            this.linkSnipeGroup.Controls.Add(this.acceptUsernames);
            this.linkSnipeGroup.Controls.Add(this.acceptKeyWords);
            this.linkSnipeGroup.Controls.Add(this.keyWordLabel);
            this.linkSnipeGroup.Controls.Add(this.userNameTextBox);
            this.linkSnipeGroup.Location = new System.Drawing.Point(23, 63);
            this.linkSnipeGroup.Name = "linkSnipeGroup";
            this.linkSnipeGroup.Size = new System.Drawing.Size(434, 524);
            this.linkSnipeGroup.TabIndex = 13;
            this.linkSnipeGroup.TabStop = false;
            // 
            // linkSnipeLabelText
            // 
            this.linkSnipeLabelText.AutoSize = true;
            this.linkSnipeLabelText.Location = new System.Drawing.Point(6, -4);
            this.linkSnipeLabelText.Name = "linkSnipeLabelText";
            this.linkSnipeLabelText.Size = new System.Drawing.Size(76, 19);
            this.linkSnipeLabelText.TabIndex = 0;
            this.linkSnipeLabelText.Text = "Link Sniper:";
            this.linkSnipeLabelText.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // rsvpGroup
            // 
            this.rsvpGroup.Controls.Add(this.rsvpKeywordTextBox);
            this.rsvpGroup.Controls.Add(this.rsvpDenyKeyWords);
            this.rsvpGroup.Controls.Add(this.rsvpAcceptKeyWords);
            this.rsvpGroup.Controls.Add(this.rsvpKeywordLabel);
            this.rsvpGroup.Controls.Add(this.rsvpFollowAllButton);
            this.rsvpGroup.Controls.Add(this.rsvpDenyUsernames);
            this.rsvpGroup.Controls.Add(this.rsvpAcceptUsernames);
            this.rsvpGroup.Controls.Add(this.metroLabel4);
            this.rsvpGroup.Controls.Add(this.rsvpUsernamesLabel);
            this.rsvpGroup.Controls.Add(this.rsvpUserNameTextBox);
            this.rsvpGroup.Location = new System.Drawing.Point(468, 63);
            this.rsvpGroup.Name = "rsvpGroup";
            this.rsvpGroup.Size = new System.Drawing.Size(434, 524);
            this.rsvpGroup.TabIndex = 14;
            this.rsvpGroup.TabStop = false;
            // 
            // rsvpUserNameTextBox
            // 
            this.rsvpUserNameTextBox.Location = new System.Drawing.Point(225, 53);
            this.rsvpUserNameTextBox.MaxLength = 32767;
            this.rsvpUserNameTextBox.Multiline = true;
            this.rsvpUserNameTextBox.Name = "rsvpUserNameTextBox";
            this.rsvpUserNameTextBox.PasswordChar = '\0';
            this.rsvpUserNameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.rsvpUserNameTextBox.SelectedText = "";
            this.rsvpUserNameTextBox.Size = new System.Drawing.Size(180, 419);
            this.rsvpUserNameTextBox.TabIndex = 7;
            this.rsvpUserNameTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.rsvpUserNameTextBox.UseSelectable = true;
            // 
            // rsvpUsernamesLabel
            // 
            this.rsvpUsernamesLabel.AutoSize = true;
            this.rsvpUsernamesLabel.Location = new System.Drawing.Point(232, 27);
            this.rsvpUsernamesLabel.Name = "rsvpUsernamesLabel";
            this.rsvpUsernamesLabel.Size = new System.Drawing.Size(160, 19);
            this.rsvpUsernamesLabel.TabIndex = 8;
            this.rsvpUsernamesLabel.Text = "Usernames (One Per Line)";
            this.rsvpUsernamesLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(6, -4);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(43, 19);
            this.metroLabel4.TabIndex = 9;
            this.metroLabel4.Text = "RSVP:";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // rsvpFollowAllButton
            // 
            this.rsvpFollowAllButton.Highlight = true;
            this.rsvpFollowAllButton.Location = new System.Drawing.Point(225, 478);
            this.rsvpFollowAllButton.Name = "rsvpFollowAllButton";
            this.rsvpFollowAllButton.Size = new System.Drawing.Size(80, 32);
            this.rsvpFollowAllButton.Style = MetroFramework.MetroColorStyle.Silver;
            this.rsvpFollowAllButton.TabIndex = 15;
            this.rsvpFollowAllButton.Text = "Follow All";
            this.rsvpFollowAllButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.rsvpFollowAllButton.UseSelectable = true;
            this.rsvpFollowAllButton.Click += new System.EventHandler(this.rsvpFollowAllButton_Click);
            // 
            // rsvpDenyUsernames
            // 
            this.rsvpDenyUsernames.Highlight = true;
            this.rsvpDenyUsernames.Location = new System.Drawing.Point(373, 478);
            this.rsvpDenyUsernames.Name = "rsvpDenyUsernames";
            this.rsvpDenyUsernames.Size = new System.Drawing.Size(32, 32);
            this.rsvpDenyUsernames.Style = MetroFramework.MetroColorStyle.Red;
            this.rsvpDenyUsernames.TabIndex = 14;
            this.rsvpDenyUsernames.Text = "✖";
            this.rsvpDenyUsernames.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.rsvpDenyUsernames.UseSelectable = true;
            this.rsvpDenyUsernames.Click += new System.EventHandler(this.rsvpDenyUsernames_Click);
            // 
            // rsvpAcceptUsernames
            // 
            this.rsvpAcceptUsernames.Highlight = true;
            this.rsvpAcceptUsernames.Location = new System.Drawing.Point(335, 478);
            this.rsvpAcceptUsernames.Name = "rsvpAcceptUsernames";
            this.rsvpAcceptUsernames.Size = new System.Drawing.Size(32, 32);
            this.rsvpAcceptUsernames.Style = MetroFramework.MetroColorStyle.Green;
            this.rsvpAcceptUsernames.TabIndex = 13;
            this.rsvpAcceptUsernames.Text = "✓";
            this.rsvpAcceptUsernames.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.rsvpAcceptUsernames.UseSelectable = true;
            this.rsvpAcceptUsernames.Click += new System.EventHandler(this.rsvpAcceptUsernames_Click);
            // 
            // rsvpKeywordTextBox
            // 
            this.rsvpKeywordTextBox.Location = new System.Drawing.Point(21, 51);
            this.rsvpKeywordTextBox.MaxLength = 32767;
            this.rsvpKeywordTextBox.Multiline = true;
            this.rsvpKeywordTextBox.Name = "rsvpKeywordTextBox";
            this.rsvpKeywordTextBox.PasswordChar = '\0';
            this.rsvpKeywordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.rsvpKeywordTextBox.SelectedText = "";
            this.rsvpKeywordTextBox.Size = new System.Drawing.Size(180, 419);
            this.rsvpKeywordTextBox.TabIndex = 17;
            this.rsvpKeywordTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.rsvpKeywordTextBox.UseSelectable = true;
            // 
            // rsvpDenyKeyWords
            // 
            this.rsvpDenyKeyWords.Highlight = true;
            this.rsvpDenyKeyWords.Location = new System.Drawing.Point(169, 476);
            this.rsvpDenyKeyWords.Name = "rsvpDenyKeyWords";
            this.rsvpDenyKeyWords.Size = new System.Drawing.Size(32, 32);
            this.rsvpDenyKeyWords.Style = MetroFramework.MetroColorStyle.Red;
            this.rsvpDenyKeyWords.TabIndex = 19;
            this.rsvpDenyKeyWords.Text = "✖";
            this.rsvpDenyKeyWords.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.rsvpDenyKeyWords.UseSelectable = true;
            this.rsvpDenyKeyWords.Click += new System.EventHandler(this.rsvpDenyKeyWords_Click);
            // 
            // rsvpAcceptKeyWords
            // 
            this.rsvpAcceptKeyWords.Highlight = true;
            this.rsvpAcceptKeyWords.Location = new System.Drawing.Point(131, 476);
            this.rsvpAcceptKeyWords.Name = "rsvpAcceptKeyWords";
            this.rsvpAcceptKeyWords.Size = new System.Drawing.Size(32, 32);
            this.rsvpAcceptKeyWords.Style = MetroFramework.MetroColorStyle.Green;
            this.rsvpAcceptKeyWords.TabIndex = 18;
            this.rsvpAcceptKeyWords.Text = "✓";
            this.rsvpAcceptKeyWords.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.rsvpAcceptKeyWords.UseSelectable = true;
            this.rsvpAcceptKeyWords.Click += new System.EventHandler(this.rsvpAcceptKeyWords_Click);
            // 
            // rsvpKeywordLabel
            // 
            this.rsvpKeywordLabel.AutoSize = true;
            this.rsvpKeywordLabel.Location = new System.Drawing.Point(29, 27);
            this.rsvpKeywordLabel.Name = "rsvpKeywordLabel";
            this.rsvpKeywordLabel.Size = new System.Drawing.Size(158, 19);
            this.rsvpKeywordLabel.TabIndex = 16;
            this.rsvpKeywordLabel.Text = "Key Words (One Per Line)";
            this.rsvpKeywordLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // KeyWordManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 658);
            this.Controls.Add(this.rsvpGroup);
            this.Controls.Add(this.linkSnipeGroup);
            this.Controls.Add(this.metroLabel2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(928, 658);
            this.MinimumSize = new System.Drawing.Size(928, 658);
            this.Name = "KeyWordManager";
            this.Resizable = false;
            this.Text = "Key Word Manager";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.KeyWordManager_Load);
            this.linkSnipeGroup.ResumeLayout(false);
            this.linkSnipeGroup.PerformLayout();
            this.rsvpGroup.ResumeLayout(false);
            this.rsvpGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel keyWordLabel;
        private MetroFramework.Controls.MetroTextBox keyWordTextBox;
        private MetroFramework.Controls.MetroTextBox userNameTextBox;
        private MetroFramework.Controls.MetroLabel usernamesLabel;
        private MetroFramework.Controls.MetroButton acceptKeyWords;
        private MetroFramework.Controls.MetroButton denyKeyWords;
        private MetroFramework.Controls.MetroButton denyUsernames;
        private MetroFramework.Controls.MetroButton acceptUsernames;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton followAllButton;
        private System.Windows.Forms.GroupBox linkSnipeGroup;
        private MetroFramework.Controls.MetroLabel linkSnipeLabelText;
        private System.Windows.Forms.GroupBox rsvpGroup;
        private MetroFramework.Controls.MetroTextBox rsvpKeywordTextBox;
        private MetroFramework.Controls.MetroButton rsvpDenyKeyWords;
        private MetroFramework.Controls.MetroButton rsvpAcceptKeyWords;
        private MetroFramework.Controls.MetroLabel rsvpKeywordLabel;
        private MetroFramework.Controls.MetroButton rsvpFollowAllButton;
        private MetroFramework.Controls.MetroButton rsvpDenyUsernames;
        private MetroFramework.Controls.MetroButton rsvpAcceptUsernames;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel rsvpUsernamesLabel;
        private MetroFramework.Controls.MetroTextBox rsvpUserNameTextBox;
    }
}