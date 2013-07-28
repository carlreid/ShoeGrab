﻿using System;
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
    public partial class OCRImage : Form
    {
        public OCRImage()
        {
            InitializeComponent();
        }

        int testImageCycle = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = testImageCycle.ToString();
            textBox1.Text = @"C:\Users\Carl\SkyDrive\Scripts and Programs\ShoeGrab\image" + testImageCycle.ToString() +".jpg";
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Bitmap cleanedImage = getCleanedImage("URLWILLGOHERE-MAKE SURE TO CHANGE FROM TEXTBOX1.TEXT!");
            string hashTag = getHashTag(cleanedImage);
            if (hashTag.Length <= 0)
            {
                //No hashtag! Try again with a larger output image.
                cleanedImage = getCleanedImage("URLWILLGOHERE-MAKE SURE TO CHANGE FROM TEXTBOX1.TEXT!", true);
                hashTag = getHashTag(cleanedImage);
                if (hashTag.Length <= 0)
                {
                    //Still no result, last resort ask the user.
                }
            }
            label1.Text = hashTag;
            stopWatch.Stop();
            label1.Text += " in (" + stopWatch.Elapsed.Milliseconds + "ms)";
            testImageCycle++;
        }

        Bitmap getCleanedImage(string imageURL, bool keepLarge = false)
        {
            //Load in the initial image as a grayscale
            Image<Gray, byte> im = new Image<Gray, byte>(textBox1.Text);
            //Resize the image so we can get rid of all the artifacts and stuff later.
            im = im.Resize(3, INTER.CV_INTER_CUBIC);
            //Not really sure what this does, do it anyway.
            im = im.ThresholdAdaptive(new Gray(255), Emgu.CV.CvEnum.ADAPTIVE_THRESHOLD_TYPE.CV_ADAPTIVE_THRESH_GAUSSIAN_C, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY_INV, 45, new Gray(0));
            //Emgu.CV.CvInvoke.cvShowImage("im (1)", im);

            //Create a new image used for clean ups.
            Image<Gray, byte> cleanUp = im.ThresholdBinaryInv(new Gray(0), new Gray(255));
            //Fill up any holes and invert the image
            cleanUp = FillHolesSimpleCCOMP(im, 0, 1200);
            cleanUp = cleanUp.ThresholdBinaryInv(new Gray(0), new Gray(255));

            //Bitwise AND these together to perform the clean up.
            im = im & cleanUp;
            //Emgu.CV.CvInvoke.cvShowImage("im & cleanUp (2)", im);

            //Begin eroding the image to get rid of further junk while maining circle border
            Image<Gray, byte> eroded = im.Copy();
            eroded = eroded.Erode(1);
            //Create a structure element of type ellipse to fill in any holes caused by the erode (within characters)
            StructuringElementEx element = new StructuringElementEx(7, 7, 0, 0, CV_ELEMENT_SHAPE.CV_SHAPE_ELLIPSE);
            eroded = eroded.MorphologyEx(element, CV_MORPH_OP.CV_MOP_CLOSE, 1);
            //Emgu.CV.CvInvoke.cvShowImage("eroded (3)", eroded);

            //Create a new image to find the border area.
            Image<Gray, byte> bordered = im.CopyBlank();
            CvInvoke.cvCopyMakeBorder(eroded.Ptr, bordered.Ptr, new Point(0, 0), BORDER_TYPE.CONSTANT, new MCvScalar(0));
            //Invert the colours
            bordered = bordered.ThresholdBinaryInv(new Gray(0), new Gray(255));
            //Fill in holes which are in the specified area - Could be problamatic for shorter/longer words but SHOULD be okay.
            bordered = FillHolesSimpleCCOMP(bordered, 15000, 100000);
            //Sometimes the border is attached to a character causing the character to be lost, so dilate to close the gap and refill anything with any area.
            bordered = bordered.Dilate(2);
            bordered = FillHolesSimpleCCOMP(bordered, 0);
            //Emgu.CV.CvInvoke.cvShowImage("bordered (4)", bordered);

            //Bitwise AND the bordered image and image together to crop anything not in the border.
            im = im & bordered;
            //Erode the image some more to split any of the border that may have been introduced again due to a previous dilate.
            im = im.Erode(1);
            //Fill anything with a small area in hope to get rid of any pieces of the border/other stuff.
            cleanUp = FillHolesSimpleCCOMP(im, 0, 500);
            //Invert the image
            cleanUp = cleanUp.ThresholdBinaryInv(new Gray(0), new Gray(255));
            //Bitwise AND the cleanup and image together to get rid of the cleanup stuff.
            im = im & cleanUp;
            //Emgu.CV.CvInvoke.cvShowImage("im & bordered + hole fill(5)", im);

            //Creater a larger ellipse element to fill in some of the holes that were introduced before eroding
            element = new StructuringElementEx(9, 9, 0, 0, CV_ELEMENT_SHAPE.CV_SHAPE_ELLIPSE);
            im = im.MorphologyEx(element, CV_MORPH_OP.CV_MOP_CLOSE, 1);
            //Another erode to get rid of some of the stuff attached to the characters
            im = im.Erode(1);
            //Try fill in anything that has become detatched
            cleanUp = FillHolesSimpleCCOMP(im, 0, 500);
            //Invert the image
            cleanUp = cleanUp.ThresholdBinaryInv(new Gray(0), new Gray(255));
            //Bitwise AND them together to remove the clean up bits
            im = im & cleanUp;
            //Emgu.CV.CvInvoke.cvShowImage("clean up(6)", im);

            //Perform these to cleap up the picture some more
            im = im.Erode(1);
            im = im.SmoothGaussian(1);
            im = im.Dilate(1);

            //Fill any small elements, invert and clean again.
            cleanUp = FillHolesSimpleCCOMP(im, 0, 300);
            cleanUp = cleanUp.ThresholdBinaryInv(new Gray(0), new Gray(255));
            im = im & cleanUp;

            //Dilate the image, to give the letters some more thickness
            im = im.Dilate(1);
            //Perform a final cleanup to get rid of anything that may have been introduced by the dilate.
            cleanUp = FillHolesSimpleCCOMP(im, 0, 500);
            cleanUp = cleanUp.ThresholdBinaryInv(new Gray(0), new Gray(255));
            im = im & cleanUp;
            //Emgu.CV.CvInvoke.cvShowImage("im & bordered + hole fill(6)", im);

            //Final beef up, not needed.
            //im.Dilate(1);

            //OCR Seems to prefer it when the size is reduced before reading.
            //#COLDWORLD @ 4 = #COLDWORID (example)
            if (!keepLarge)
            {
                im = im.Resize(0.25, INTER.CV_INTER_CUBIC);
            }

            //Debug, use to display final image.
            pictureBox1.Image = im.Bitmap;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            return im.Bitmap;
        }

        string getHashTag(Bitmap image)
        {
            //Create the OCR engine instance
            TesseractEngine engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
            //We know that the hastags only include #[A-Z]
            engine.SetVariable("tessedit_char_whitelist", "#ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            //Call the engine and get the page result
            Page result = engine.Process(image);

            //Store OCR Result and begin cleanup if needed
            string OCRResult = result.GetText().Replace(" ", "");   //OCR can be a bit dumb and add spaces so just remove them.
            string finalHashtag = "";
            //Create a regex to look for hashtags. This can find '#HELLOWORLD' and ADOM'#THISWORD'
            Regex r = new Regex(@"#\w+");

            //Check for a match.
            Match m = r.Match(OCRResult);
            if (m.Length > 0)
            {
                //Found a match, good, must be it.
                finalHashtag = m.Value;
            }
            else
            {
                //No match? Means OCR didn't find hashtag (can be lost with all the erodes/dilates from image)
                //Create a regex to look for letters A->Z
                Regex findLetter = new Regex(@"[A-Z]");
                //Find first match: Let's hope there's only one word!
                Match matchedCase = findLetter.Match(OCRResult);
                //Insert a hashtag before it.
                OCRResult.Insert(matchedCase.Index, "#");
                //Rerun the hashtag match
                Match hashTag = r.Match(OCRResult);
                if (m.Length > 0)
                {
                    //Great, the insert worked.
                    finalHashtag = m.Value;
                }
                else
                {
                    //No insert, no hashtag, something went wrong?
                    //Currently just handle with a console out, maybe change/ask the user.
                    Console.WriteLine("Unable to find a match at all!");
                }
            }

            ////Debug
            //Console.WriteLine("Confidence: " + result.GetMeanConfidence() + " | " + OCRResult);
            //Console.WriteLine("Outcome: " + finalHashtag);

            //Dispose of the OCR Engine
            result.Dispose();
            engine.Dispose();

            return finalHashtag;
        }


        //http://stackoverflow.com/questions/7204350/fill-the-holes-in-emgu-cv
        private Image<Gray, byte> FillHoles(Image<Gray, byte> image, int minArea = 0, int maxArea = Int32.MaxValue, Gray? color = null)
        {
            var resultImage = image.CopyBlank();
            Gray gray;
            if (color.HasValue)
            {
                gray = (Gray)color;
            }
            else
            {
                gray = new Gray(255);
            }
            using (var mem = new MemStorage())
            {
                for (var contour = image.FindContours(CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE, RETR_TYPE.CV_RETR_EXTERNAL, mem); contour != null; contour = contour.HNext)
                {
                    // 
                    if ((contour.Area > minArea) && (contour.Area < maxArea))
                    {
                        resultImage.Draw(contour, gray, -1);
                    }
                }
            }

            return resultImage;
        }

        private Image<Gray, byte> FillHolesSimpleCCOMP(Image<Gray, byte> image, int minArea = 0, int maxArea = Int32.MaxValue, Gray? color = null)
        {
            var resultImage = image.CopyBlank();
            Gray gray;
            if (color.HasValue)
            {
                gray = (Gray)color;
            }
            else
            {
                gray = new Gray(255);
            }
            using (var mem = new MemStorage())
            {
                for (var contour = image.FindContours(CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, RETR_TYPE.CV_RETR_CCOMP, mem); contour != null; contour = contour.HNext)
                {
                    // 
                    if ((contour.Area > minArea) && (contour.Area < maxArea))
                    {
                        resultImage.Draw(contour, gray, -1);
                    }
                }
            }

            return resultImage;
        }

        ////http://tech.pro/tutorial/660/csharp-tutorial-convert-a-color-image-to-grayscale
        //public static Bitmap MakeGrayscale3(Bitmap original)
        //{
        //    //create a blank bitmap the same size as original
        //    Bitmap newBitmap = new Bitmap(original.Width, original.Height);

        //    //get a graphics object from the new image
        //    Graphics g = Graphics.FromImage(newBitmap);

        //    //create the grayscale ColorMatrix
        //    ColorMatrix colorMatrix = new ColorMatrix(
        //    new float[][] 
        //      {
        //         new float[] {.3f, .3f, .3f, 0, 0},
        //         new float[] {.59f, .59f, .59f, 0, 0},
        //         new float[] {.11f, .11f, .11f, 0, 0},
        //         new float[] {0, 0, 0, 1, 0},
        //         new float[] {0, 0, 0, 0, 1}
        //      });

        //    //create some image attributes
        //    ImageAttributes attributes = new ImageAttributes();

        //    //set the color matrix attribute
        //    attributes.SetColorMatrix(colorMatrix);

        //    //draw the original image on the new image
        //    //using the grayscale color matrix
        //    g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
        //       0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

        //    //dispose the Graphics object
        //    g.Dispose();
        //    return newBitmap;
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = (Int32.Parse(button2.Text) + 1).ToString();
        }

    }
}
