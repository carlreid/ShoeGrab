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
            this.useBuiltInRadio = new MetroFramework.Controls.MetroRadioButton();
            this.useDefaultRadio = new MetroFramework.Controls.MetroRadioButton();
            this.useCustomBrowser = new MetroFramework.Controls.MetroRadioButton();
            this.helpLabel = new MetroFramework.Controls.MetroLabel();
            this.browserSettingsGroup.SuspendLayout();
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
            this.browserSettingsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browserSettingsGroup.Controls.Add(this.useCustomBrowser);
            this.browserSettingsGroup.Controls.Add(this.browserExeLabel);
            this.browserSettingsGroup.Controls.Add(this.useDefaultRadio);
            this.browserSettingsGroup.Controls.Add(this.browserPathTextBox);
            this.browserSettingsGroup.Controls.Add(this.useBuiltInRadio);
            this.browserSettingsGroup.Location = new System.Drawing.Point(23, 63);
            this.browserSettingsGroup.Name = "browserSettingsGroup";
            this.browserSettingsGroup.Size = new System.Drawing.Size(464, 96);
            this.browserSettingsGroup.TabIndex = 5;
            this.browserSettingsGroup.TabStop = false;
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
            // helpLabel
            // 
            this.helpLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.helpLabel.AutoSize = true;
            this.helpLabel.Location = new System.Drawing.Point(111, 175);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(300, 19);
            this.helpLabel.TabIndex = 6;
            this.helpLabel.Text = "All changes are saved when you close this window.";
            this.helpLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // SettingsTweaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 216);
            this.Controls.Add(this.helpLabel);
            this.Controls.Add(this.browserSettingsGroup);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(518, 216);
            this.MinimumSize = new System.Drawing.Size(518, 216);
            this.Name = "SettingsTweaker";
            this.Resizable = false;
            this.Text = "Settings";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClosing);
            this.browserSettingsGroup.ResumeLayout(false);
            this.browserSettingsGroup.PerformLayout();
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
    }
}