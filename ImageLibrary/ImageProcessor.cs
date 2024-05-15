using System;
using Emgu.CV.Structure;
using Emgu.CV;
using System.Drawing;

namespace ImageLibrary
{

    public class ImageProcessor
    {
        private Image<Bgr, Byte> OriginalImage;

        public Image<Bgr, Byte> ProcessedImage { get; private set; }

        public Image<Bgr, Byte> GetImage()
        {
            return ProcessedImage;
        }
        public Image<Bgr, Byte> GetNewCopyImage()
        {
            return OriginalImage.Clone();
        }
        public void LoadImage(string filePath)
        {
            OriginalImage = new Image<Bgr, byte>(filePath);
            ProcessedImage = OriginalImage.Clone();
        }

        public void ApplyGammaCorrection(Image<Bgr, Byte> img, double gamma)
        {
            img._GammaCorrect(gamma);
            
        }

        public Image<Bgr, Byte> ApplyContrastBrightness(Image<Bgr, Byte> img, double alpha, double beta)
        {

            img = img.Mul(alpha) + beta;

            return img;
        }

        public void ApplyFilter(Image<Bgr, Byte> img, int r, int g, int b)
        {
            if (img != null)
            {

                var data = img.Data;

                for (int i = 0; i < ProcessedImage.Width; i++)
                {
                    for (int j = 0; j < ProcessedImage.Height; j++)
                    {
                        if (b == 0) data[j, i, 0] = 0;
                        if (g == 0) data[j, i, 1] = 0;
                        if (r == 0) data[j, i, 2] = 0;
                    }
                }
     
            }
            
        }
        public void ResetImage()
        {
            if (OriginalImage != null)
            {
                ProcessedImage = OriginalImage.Clone();
            }
        }

        public Image<Bgr, Byte> ResizeImage(Image<Bgr, Byte> img, int width, int height)
        {
            return img.Resize(width, height, Emgu.CV.CvEnum.Inter.Linear);
        }

        public Image<Bgr, Byte> ScaleImage(Image<Bgr, Byte> img, float scale)
        {
            return img.Resize(scale, Emgu.CV.CvEnum.Inter.Cubic);
            
        }

        public Image<Bgr, Byte> RotateImage(Image<Bgr, Byte> img, int angle)
        {
            var bgColor = Color.FromArgb(255, 255, 255);
            Bgr bgr = new Bgr(bgColor);
            var rotatedImg = img.Rotate(angle, bgr, true);
            rotatedImg.ROI = Rectangle.Empty;
            return rotatedImg;
        }
    }
}
