using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.UI;
using static System.Windows.Forms.AxHost;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private ImageProcessor ImageProcessor;

        public Form1()
        {
            InitializeComponent();
            ImageProcessor = new ImageProcessor();
        }

        private void button_image_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                ImageProcessor.LoadImage(openFile.FileName);
                pictureBox1.Image = ImageProcessor.ProcessedImage.ToBitmap();
            }
        }

        private void button_histogram_Click(object sender, EventArgs e)
        {
            ShowHistogram();
        }

        private void ShowHistogram()
        {
            if (ImageProcessor.ProcessedImage != null)
            {
                HistogramViewer v = new HistogramViewer();
                v.HistogramCtrl.GenerateHistograms(ImageProcessor.ProcessedImage, 255);
                v.Show();
            }
            else
            {
                MessageBox.Show("Please load an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_gamma_Click(object sender, EventArgs e)
        {
            double gamma = (double)numericUpDownGamma.Value;
            ImageProcessor.ApplyGammaCorrection(gamma);
            pictureBox1.Image = ImageProcessor.ProcessedImage.ToBitmap();
        }

        private void button_contrast_brightness_Click(object sender, EventArgs e)
        {
            double alpha = (double)numericUpDownAlpha.Value;
            double beta = (double)numericUpDownBeta.Value;
            ImageProcessor.ApplyContrastBrightness(alpha, beta);
            pictureBox1.Image = ImageProcessor.ProcessedImage.ToBitmap();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ImageProcessor.ResetImage();
            pictureBox1.Image = ImageProcessor.ProcessedImage.ToBitmap();
        }

        private void buttonFiltering_Click(object sender, EventArgs e)
        {


            int r = 0, g = 0, b = 0;
            if (checkBoxRed.Checked) {
                r = 1;
            }
            if (checkBoxGreen.Checked)
            {
                g = 1;
            }
            if (checkBoxBlue.Checked)
            {
                b = 1;
            }

            ImageProcessor.ApplyFilter(r,g,b);
           
            pictureBox1.Image = ImageProcessor.ProcessedImage.ToBitmap();
        }

        private void buttonFilterRed_Click(object sender, EventArgs e)
        {
            ImageProcessor.ApplyFilter(1, 0, 0);
            pictureBox1.Image = ImageProcessor.ProcessedImage.ToBitmap();
        }

        private void buttonFilterGreen_Click(object sender, EventArgs e)
        {
            ImageProcessor.ApplyFilter(0, 1, 0);
            pictureBox1.Image = ImageProcessor.ProcessedImage.ToBitmap();
        }

        private void buttonFilterBlue_Click(object sender, EventArgs e)
        {
            ImageProcessor.ApplyFilter(0, 0, 1);
            pictureBox1.Image = ImageProcessor.ProcessedImage.ToBitmap();
        }
    }

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

        public void ApplyRedFilter()
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

                        data[j, i, 0] = 0;
                        data[j, i, 1] = 0;
                     

                    }
                }
               
                ProcessedImage = outputImage;
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