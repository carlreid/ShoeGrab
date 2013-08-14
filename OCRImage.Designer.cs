namespace ShoeGrab
{
    partial class OCRImage
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
            this.imageDisplayBox = new System.Windows.Forms.PictureBox();
            this.userHashTag = new MetroFramework.Controls.MetroTextBox();
            this.acceptHashTag = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.imageDisplayBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imageDisplayBox
            // 
            this.imageDisplayBox.Location = new System.Drawing.Point(23, 63);
            this.imageDisplayBox.Name = "imageDisplayBox";
            this.imageDisplayBox.Size = new System.Drawing.Size(375, 375);
            this.imageDisplayBox.TabIndex = 1;
            this.imageDisplayBox.TabStop = false;
            // 
            // userHashTag
            // 
            this.userHashTag.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.userHashTag.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.userHashTag.Location = new System.Drawing.Point(23, 453);
            this.userHashTag.MaxLength = 32767;
            this.userHashTag.Name = "userHashTag";
            this.userHashTag.PasswordChar = '\0';
            this.userHashTag.PromptText = "#hashtag";
            this.userHashTag.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.userHashTag.SelectedText = "";
            this.userHashTag.Size = new System.Drawing.Size(335, 32);
            this.userHashTag.Style = MetroFramework.MetroColorStyle.Red;
            this.userHashTag.TabIndex = 2;
            this.userHashTag.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.userHashTag.UseSelectable = true;
            // 
            // acceptHashTag
            // 
            this.acceptHashTag.Highlight = true;
            this.acceptHashTag.Location = new System.Drawing.Point(366, 453);
            this.acceptHashTag.Name = "acceptHashTag";
            this.acceptHashTag.Size = new System.Drawing.Size(32, 32);
            this.acceptHashTag.Style = MetroFramework.MetroColorStyle.Green;
            this.acceptHashTag.TabIndex = 14;
            this.acceptHashTag.Text = "✓";
            this.acceptHashTag.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.acceptHashTag.UseSelectable = true;
            this.acceptHashTag.Click += new System.EventHandler(this.acceptHashTag_Click);
            // 
            // OCRImage
            // 
            this.AcceptButton = this.acceptHashTag;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 513);
            this.Controls.Add(this.acceptHashTag);
            this.Controls.Add(this.userHashTag);
            this.Controls.Add(this.imageDisplayBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(424, 513);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(424, 513);
            this.Name = "OCRImage";
            this.Resizable = false;
            this.Text = "Enter Circled #hashtag";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.imageDisplayBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imageDisplayBox;
        private MetroFramework.Controls.MetroTextBox userHashTag;
        private MetroFramework.Controls.MetroButton acceptHashTag;
    }
}