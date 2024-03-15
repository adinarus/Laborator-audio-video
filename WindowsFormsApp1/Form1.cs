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
using ImageLibrary;

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

            if (checkBoxRed.Checked) 
            {
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

}