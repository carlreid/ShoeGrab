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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.acceptKeyWords = new MetroFramework.Controls.MetroButton();
            this.denyKeyWords = new MetroFramework.Controls.MetroButton();
            this.denyUsernames = new MetroFramework.Controls.MetroButton();
            this.acceptUsernames = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.followAllButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // keyWordLabel
            // 
            this.keyWordLabel.AutoSize = true;
            this.keyWordLabel.Location = new System.Drawing.Point(171, 60);
            this.keyWordLabel.Name = "keyWordLabel";
            this.keyWordLabel.Size = new System.Drawing.Size(158, 19);
            this.keyWordLabel.TabIndex = 1;
            this.keyWordLabel.Text = "Key Words (One Per Line)";
            this.keyWordLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // keyWordTextBox
            // 
            this.keyWordTextBox.Location = new System.Drawing.Point(23, 82);
            this.keyWordTextBox.MaxLength = 32767;
            this.keyWordTextBox.Multiline = true;
            this.keyWordTextBox.Name = "keyWordTextBox";
            this.keyWordTextBox.PasswordChar = '\0';
            this.keyWordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.keyWordTextBox.SelectedText = "";
            this.keyWordTextBox.Size = new System.Drawing.Size(455, 419);
            this.keyWordTextBox.TabIndex = 4;
            this.keyWordTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.keyWordTextBox.UseSelectable = true;
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(513, 82);
            this.userNameTextBox.MaxLength = 32767;
            this.userNameTextBox.Multiline = true;
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.PasswordChar = '\0';
            this.userNameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.userNameTextBox.SelectedText = "";
            this.userNameTextBox.Size = new System.Drawing.Size(455, 419);
            this.userNameTextBox.TabIndex = 6;
            this.userNameTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.userNameTextBox.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(660, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(160, 19);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Usernames (One Per Line)";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // acceptKeyWords
            // 
            this.acceptKeyWords.Highlight = true;
            this.acceptKeyWords.Location = new System.Drawing.Point(407, 507);
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
            this.denyKeyWords.Location = new System.Drawing.Point(445, 507);
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
            this.denyUsernames.Location = new System.Drawing.Point(935, 507);
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
            this.acceptUsernames.Location = new System.Drawing.Point(897, 507);
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
            this.metroLabel2.Location = new System.Drawing.Point(110, 544);
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
            this.followAllButton.Location = new System.Drawing.Point(513, 507);
            this.followAllButton.Name = "followAllButton";
            this.followAllButton.Size = new System.Drawing.Size(80, 32);
            this.followAllButton.Style = MetroFramework.MetroColorStyle.Silver;
            this.followAllButton.TabIndex = 12;
            this.followAllButton.Text = "Follow All";
            this.followAllButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.followAllButton.UseSelectable = true;
            this.followAllButton.Click += new System.EventHandler(this.followAllButton_Click);
            // 
            // KeyWordManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 592);
            this.Controls.Add(this.followAllButton);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.denyUsernames);
            this.Controls.Add(this.acceptUsernames);
            this.Controls.Add(this.denyKeyWords);
            this.Controls.Add(this.acceptKeyWords);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.keyWordTextBox);
            this.Controls.Add(this.keyWordLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(990, 592);
            this.MinimumSize = new System.Drawing.Size(990, 592);
            this.Name = "KeyWordManager";
            this.Resizable = false;
            this.Text = "Key Word Manager";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.KeyWordManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel keyWordLabel;
        private MetroFramework.Controls.MetroTextBox keyWordTextBox;
        private MetroFramework.Controls.MetroTextBox userNameTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton acceptKeyWords;
        private MetroFramework.Controls.MetroButton denyKeyWords;
        private MetroFramework.Controls.MetroButton denyUsernames;
        private MetroFramework.Controls.MetroButton acceptUsernames;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton followAllButton;
    }
}