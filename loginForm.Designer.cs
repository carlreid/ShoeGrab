namespace ShoeGrab
{
    partial class loginForm
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
            this.loginLabel = new MetroFramework.Controls.MetroLabel();
            this.usernameLabel = new MetroFramework.Controls.MetroLabel();
            this.passwordLabel = new MetroFramework.Controls.MetroLabel();
            this.emailTextBox = new MetroFramework.Controls.MetroTextBox();
            this.passwordTextBox = new MetroFramework.Controls.MetroTextBox();
            this.loginButton = new MetroFramework.Controls.MetroButton();
            this.registerButton = new MetroFramework.Controls.MetroButton();
            this.forgotButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.loginLabel.Location = new System.Drawing.Point(338, 153);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(277, 25);
            this.loginLabel.TabIndex = 0;
            this.loginLabel.Text = "Please login to your account below";
            this.loginLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.usernameLabel.Location = new System.Drawing.Point(294, 200);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(57, 25);
            this.usernameLabel.TabIndex = 1;
            this.usernameLabel.Text = "Email:";
            this.usernameLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.passwordLabel.Location = new System.Drawing.Point(265, 235);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(86, 25);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password:";
            this.passwordLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailTextBox.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.emailTextBox.Location = new System.Drawing.Point(357, 196);
            this.emailTextBox.MaxLength = 32767;
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.PasswordChar = '\0';
            this.emailTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.emailTextBox.SelectedText = "";
            this.emailTextBox.Size = new System.Drawing.Size(311, 33);
            this.emailTextBox.TabIndex = 0;
            this.emailTextBox.Text = "your@ema.il";
            this.emailTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.emailTextBox.UseSelectable = true;
            this.emailTextBox.Click += new System.EventHandler(this.emailTextBox_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordTextBox.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.passwordTextBox.Location = new System.Drawing.Point(357, 235);
            this.passwordTextBox.MaxLength = 32767;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '•';
            this.passwordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordTextBox.SelectedText = "";
            this.passwordTextBox.Size = new System.Drawing.Size(311, 33);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.Text = "Password";
            this.passwordTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.passwordTextBox.UseSelectable = true;
            this.passwordTextBox.Click += new System.EventHandler(this.passwordTextBox_Click);
            // 
            // loginButton
            // 
            this.loginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loginButton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.loginButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.loginButton.Highlight = true;
            this.loginButton.Location = new System.Drawing.Point(581, 274);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(87, 37);
            this.loginButton.Style = MetroFramework.MetroColorStyle.Green;
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Login";
            this.loginButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.loginButton.UseSelectable = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // registerButton
            // 
            this.registerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.registerButton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.registerButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.registerButton.Highlight = true;
            this.registerButton.Location = new System.Drawing.Point(116, 456);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(87, 37);
            this.registerButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.registerButton.TabIndex = 4;
            this.registerButton.Text = "Register";
            this.registerButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.registerButton.UseSelectable = true;
            // 
            // forgotButton
            // 
            this.forgotButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.forgotButton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.forgotButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.forgotButton.Highlight = true;
            this.forgotButton.Location = new System.Drawing.Point(23, 456);
            this.forgotButton.Name = "forgotButton";
            this.forgotButton.Size = new System.Drawing.Size(87, 37);
            this.forgotButton.Style = MetroFramework.MetroColorStyle.Yellow;
            this.forgotButton.TabIndex = 3;
            this.forgotButton.Text = "Forgot";
            this.forgotButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.forgotButton.UseSelectable = true;
            // 
            // loginForm
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 516);
            this.Controls.Add(this.forgotButton);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.loginLabel);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(976, 516);
            this.MinimumSize = new System.Drawing.Size(976, 516);
            this.Name = "loginForm";
            this.Resizable = false;
            this.Text = "Hello ";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.loginForm_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.formPreviewKey);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel loginLabel;
        private MetroFramework.Controls.MetroLabel usernameLabel;
        private MetroFramework.Controls.MetroLabel passwordLabel;
        private MetroFramework.Controls.MetroTextBox emailTextBox;
        private MetroFramework.Controls.MetroTextBox passwordTextBox;
        private MetroFramework.Controls.MetroButton loginButton;
        private MetroFramework.Controls.MetroButton registerButton;
        private MetroFramework.Controls.MetroButton forgotButton;
    }
}