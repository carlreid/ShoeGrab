using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tesseract;

namespace ShoeGrab
{
    public class OCRSolver
    {

        public OCRSolver()
        {

        }

        public string CleanAndOCRImage(string imageURL)
        {
            Bitmap cleanedResult = getCleanedImage(imageURL);
            string hashTag = getHashTag(cleanedResult);
            if (hashTag.Length <= 0)
            {
                //No hashtag! Try again with a larger output image.
                cleanedResult = getCleanedImage(imageURL, true);
                hashTag = getHashTag(cleanedResult);
                if (hashTag.Length <= 0)
                {
                    //Still no result, last resort ask the user.
                    hashTag = "";
                }
            }
            return hashTag;
        }

        public Bitmap getCleanedImage(string imageURL, bool keepLarge = false)
        {
            //Download image from URL into a Bitmap
            Bitmap downloadedImage = LoadPicture(imageURL);
           
            //Load in the initial image as a grayscale
            Image<Gray, byte> im = new Image<Gray, byte>(downloadedImage);
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
            eroded = eroded.Dilate(1); //ADDED
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
            //pictureBox1.Image = im.Bitmap;
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            return im.Bitmap;
        }

        public string getHashTag(Bitmap image)
        {
            //Create the OCR engine instance
            TesseractEngine engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
            //We know that the hastags only include #[A-Z] --- TODO: Some of them have numbers although OCR seems to struggle distinguishing from 5 and S for example. (https://twitter.com/NikeChicago/media/grid)
            //engine.SetVariable("tessedit_char_whitelist", "#ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
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

        private Bitmap LoadPicture(string url)
        {
            HttpWebRequest wreq;
            HttpWebResponse wresp;
            Stream mystream;
            Bitmap bmp;

            bmp = null;
            mystream = null;
            wresp = null;
            try
            {
                wreq = (HttpWebRequest)WebRequest.Create(url);
                wreq.AllowWriteStreamBuffering = true;

                wresp = (HttpWebResponse)wreq.GetResponse();

                if ((mystream = wresp.GetResponseStream()) != null)
                    bmp = new Bitmap(mystream);
            }
            finally
            {
                if (mystream != null)
                    mystream.Close();

                if (wresp != null)
                    wresp.Close();
            }
            return (bmp);
        }
    }
}
