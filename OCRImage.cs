using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

using Tesseract;
using System.Text.RegularExpressions;
using System.Diagnostics;
namespace ShoeGrab
{
    public partial class OCRImage : MetroFramework.Forms.MetroForm
    {
        public string userText = "";

        public OCRImage(string imageURL)
        {
            InitializeComponent();
            this.TopMost = true;
            imageDisplayBox.ImageLocation = imageURL;
        }

        private void acceptHashTag_Click(object sender, EventArgs e)
        {
            userText = userHashTag.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
