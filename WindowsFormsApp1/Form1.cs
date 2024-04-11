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
using Emgu.CV.CvEnum;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private ImageProcessor ImageProcessor;
        Rectangle rect; 
        Point StartROI; 
        bool MouseDown;

        int TotalFrame, FrameNo;
        double Fps;
        bool IsReadingFrame;
        VideoCapture capture;

        private static VideoCapture cameraCapture;
        private Image<Bgr, Byte> newBackgroundImage;
        private static IBackgroundSubtractor fgDetector;


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

        private void buttonScale_Click(object sender, EventArgs e)
        {
            var scale = (float)numericUpDownResize.Value;
            ImageProcessor.ScaleImage(scale);
            pictureBox1.Image = ImageProcessor.ProcessedImage.ToBitmap();
        }

        private void buttonResizeWidthHeight_Click(object sender, EventArgs e)
        {
            var width = (int)numericUpDownWidth.Value;
            var height = (int)numericUpDownHeight.Value;
            ImageProcessor.ResizeImage(width, height);
            pictureBox1.Image = ImageProcessor.ProcessedImage.ToBitmap();
        }

        private void buttonRotate_Click(object sender, EventArgs e)
        {
            var angle = (int)numericUpDownRotate.Value;
            ImageProcessor.RotateImage(angle);
            pictureBox1.Image = ImageProcessor.ProcessedImage.ToBitmap();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                return;
            }

            int width = Math.Max(StartROI.X, e.X) - Math.Min(StartROI.X, e.X);
            int height = Math.Max(StartROI.Y, e.Y) - Math.Min(StartROI.Y, e.Y);
            rect = new Rectangle(Math.Min(StartROI.X, e.X),
                Math.Min(StartROI.Y, e.Y),
                width,
                height);
            Refresh();

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDown = false;
            if (pictureBox1.Image == null || rect == Rectangle.Empty)
            { return; }

            var img = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>();
            img.ROI = rect;
            var imgROI = img.Copy();

            pictureBox2.Image = imgROI.ToBitmap();

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown = true;
            StartROI = e.Location;

        }

     

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (MouseDown)
            {
                using (Pen pen = new Pen(Color.Red, 1))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }
        private void buttonVideoUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                capture = new VideoCapture(ofd.FileName);
                Mat m = new Mat();
                capture.Read(m);
                pictureBox1.Image = m.ToBitmap();

                TotalFrame = (int)capture.Get(CapProp.FrameCount);
                Fps = capture.Get(CapProp.Fps);
                FrameNo = 1;
                //numericUpDown1.Value = FrameNo;
                //numericUpDown1.Minimum = 0;
                //numericUpDown1.Maximum = TotalFrame;

            }

        }

        private void buttonPlayVideo_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                return;
            }
            IsReadingFrame = true;
            ReadAllFrames();
        }

        private async void ReadAllFrames()
        {

            Mat m = new Mat();
            while (IsReadingFrame == true && FrameNo < TotalFrame)
            {
                FrameNo += 1;
                var mat = capture.QueryFrame();
                pictureBox1.Image = mat.ToBitmap();
                await Task.Delay(1000 / Convert.ToInt16(Fps));
                label3.Text = FrameNo.ToString() + "/" + TotalFrame.ToString();
            }
        }

    }



}