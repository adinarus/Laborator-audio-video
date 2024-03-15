using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Structure;
using Emgu.CV;
using System.Windows.Forms;
using Emgu.CV.UI;

namespace ImageLibrary
{

    public class ImageProcessor
    {
        private Image<Bgr, Byte> OriginalImage;

        public Image<Bgr, Byte> ProcessedImage { get; private set; }

        public void LoadImage(string filePath)
        {
            OriginalImage = new Image<Bgr, byte>(filePath);
            ProcessedImage = OriginalImage.Clone();
        }

        public void ApplyGammaCorrection(double gamma)
        {
            if (OriginalImage != null)
            {
                ProcessedImage._GammaCorrect(gamma);
            }
        }

        public void ApplyContrastBrightness(double alpha, double beta)
        {
            if (OriginalImage != null)
            {
                ProcessedImage = ProcessedImage.Mul(alpha) + beta;
            }
        }

        public void ApplyFilter(int r, int g, int b)
        {
            if (OriginalImage != null)
            {

                Image<Bgr, Byte> outputImage = new Image<Bgr, byte>(OriginalImage.Size);

                OriginalImage.CopyTo(outputImage);

                var data = outputImage.Data;

                for (int i = 0; i < outputImage.Width; i++)
                {
                    for (int j = 0; j < outputImage.Height; j++)
                    {
                        if (b == 0) data[j, i, 0] = 0;
                        if (g == 0) data[j, i, 1] = 0;
                        if (r == 0) data[j, i, 2] = 0;
                    }
                }

                ProcessedImage = outputImage;
            }

        }
        public void ResetImage()
        {
            if (OriginalImage != null)
            {
                ProcessedImage = OriginalImage.Clone();
            }
        }
    }
}
