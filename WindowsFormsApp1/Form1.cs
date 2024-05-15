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
using VideoLibrary;
using Emgu.CV.CvEnum;
using System.Security.Cryptography;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private ImageProcessor ImageProcessor;
        //private VideoProcessor VideoProcessor;
        private VideoProcessor VideoProcessor;

        Rectangle rect; 
        Point StartROI; 
        bool MouseDown;

        int TotalFrame, FrameNo;
        double Fps;
        bool IsReadingFrame;
        bool isBgSubstracted = false;
        private bool isVideoPlaying = false;
        VideoCapture capture;
        

        private static VideoCapture videoCapture;
        private Image<Bgr, Byte> newBackgroundImage = new Image<Bgr, Byte>("C:\\Users\\Adi\\Desktop\\freddy.jpg");
        private static IBackgroundSubtractor fgDetector;


        public Form1()
        {
            InitializeComponent();
            ImageProcessor  = new ImageProcessor();
            
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
            


            if (ImageProcessor.GetImage() != null)
            {
                
                if (!ImageProcessor.GetImage().IsROISet)
                {
                    ImageProcessor.ApplyGammaCorrection(ImageProcessor.GetImage(), gamma);
                    pictureBox1.Image = ImageProcessor.GetImage().ToBitmap();
                }
                else
                {
                    var img2 = ImageProcessor.GetImage().Copy();
                    ImageProcessor.GetImage().SetValue(new Bgr(1,1,1));
                    ImageProcessor.ApplyGammaCorrection(img2, gamma);
                    ImageProcessor.GetImage()._Mul(img2);
                    ImageProcessor.GetImage().ROI = Rectangle.Empty;
                    pictureBox1.Image = ImageProcessor.GetImage().ToBitmap();
                }
            }
            else
            {
                MessageBox.Show("You need to upload a picture first");
            }
        }

        private void button_contrast_brightness_Click(object sender, EventArgs e)
        {
            if (ImageProcessor.GetImage() != null)
            {
                double alpha = (double)numericUpDownAlpha.Value;
                double beta = (double)numericUpDownBeta.Value;
                if (!ImageProcessor.GetImage().IsROISet)
                {
                    var result = ImageProcessor.ApplyContrastBrightness(ImageProcessor.GetImage(), alpha, beta);
                    pictureBox1.Image = result.ToBitmap();
                }

                else
                {
                    var ImageROI = ImageProcessor.GetImage().Copy();
                    ImageProcessor.GetImage().SetValue(new Bgr(1, 1, 1));
                    var result = ImageProcessor.ApplyContrastBrightness(ImageROI, alpha, beta);
                    ImageProcessor.GetImage()._Mul(result);

                    ImageProcessor.GetImage().ROI = Rectangle.Empty;
                    pictureBox1.Image = ImageProcessor.GetImage().ToBitmap();
                }
            }
            else
            {
                MessageBox.Show("You need to upload a picture first");
            }
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

            if (!ImageProcessor.GetImage().IsROISet)
            {
                ImageProcessor.ApplyFilter(ImageProcessor.GetImage(), r, g, b);
                pictureBox1.Image = ImageProcessor.GetImage().ToBitmap();
            }
            else
            {

                var img2 = ImageProcessor.GetImage().Copy();
                ImageProcessor.GetImage().SetValue(new Bgr(1, 1, 1));
                ImageProcessor.ApplyFilter(img2, r, g, b);
                ImageProcessor.GetImage()._Mul(img2);

                ImageProcessor.GetImage().ROI = Rectangle.Empty;
                pictureBox1.Image = ImageProcessor.GetImage().ToBitmap();
            }

            
        }
  
        private void buttonScale_Click(object sender, EventArgs e)
        {
            var scale = (float)numericUpDownResize.Value;
            pictureBox1.Image = ImageProcessor.GetImage().ToBitmap();

            if (!ImageProcessor.GetImage().IsROISet)
            {
                var img = ImageProcessor.ScaleImage(ImageProcessor.GetImage(), scale);
                pictureBox1.Image = img.ToBitmap();

            }
            else
            {
                var img2 = ImageProcessor.GetImage().Copy();
                ImageProcessor.GetImage().SetValue(new Bgr(1, 1, 1));
                var img = ImageProcessor.ScaleImage(img2, scale);
                ImageProcessor.GetImage().ROI = Rectangle.Empty;
                pictureBox1.Image = img.ToBitmap();
            }
        }

        private void buttonResizeWidthHeight_Click(object sender, EventArgs e)
        {
            var width = (int)numericUpDownWidth.Value;
            var height = (int)numericUpDownHeight.Value;

            if (!ImageProcessor.GetImage().IsROISet)
            {
                var img = ImageProcessor.ResizeImage(ImageProcessor.GetImage(), width, height);
                pictureBox1.Image = img.ToBitmap();
                
            }
            else
            {
                var img2 = ImageProcessor.GetImage().Copy();
                ImageProcessor.GetImage().SetValue(new Bgr(1, 1, 1));
                var img = ImageProcessor.ResizeImage(img2, width, height);
                
                //ImageProcessor.GetImage()._Mul(img);

                ImageProcessor.GetImage().ROI = Rectangle.Empty;
                pictureBox1.Image = img.ToBitmap();
            }
            
            
        }

        private void buttonRotate_Click(object sender, EventArgs e)
        {
            var angle = (int)numericUpDownRotate.Value;
            if (!ImageProcessor.GetImage().IsROISet)
            {
                var img = ImageProcessor.RotateImage(ImageProcessor.GetImage(), angle);
                pictureBox1.Image = img.ToBitmap();

            }
            else
            {
                var img2 = ImageProcessor.GetImage().Copy();
                ImageProcessor.GetImage().SetValue(new Bgr(1, 1, 1));
                var img = ImageProcessor.RotateImage(img2, angle);
                ImageProcessor.GetImage()._Mul(img);

                ImageProcessor.GetImage().ROI = Rectangle.Empty;
                pictureBox1.Image = ImageProcessor.GetImage().ToBitmap();
            }

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

            ImageProcessor.GetImage().ROI = rect;
            var imgROI = ImageProcessor.GetImage().Copy();
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
        private void UpdateFrameLabel(int currentFrame, int totalFrame)
        {
            label3.Text = $"{currentFrame}/{totalFrame}";
        }

        private void buttonVideoUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                VideoProcessor = new VideoProcessor(ofd.FileName);
                Mat m = new Mat();
                isVideoPlaying = true;
                isBgSubstracted = false;
                buttonPlayVideo.Text = "Pause";
                VideoProcessor.StartPlayback(DisplayFrame, UpdateFrameLabel);
            }

        }
       

        private void buttonPlayVideo_Click(object sender, EventArgs e)
        {
            if (isVideoPlaying)
            {
                VideoProcessor.StopPlayback();
                isVideoPlaying = false;
                buttonPlayVideo.Text = "Play";
                
            }
            else
            {
                isBgSubstracted = false;
                VideoProcessor.StartPlayback(DisplayFrame, UpdateFrameLabel);
                isVideoPlaying = true;
                buttonPlayVideo.Text = "Pause";
            }
        }

        async Task BlendImagesAsync()
        {
            string[] FileNames = Directory.GetFiles(@"C:\Users\Adi\Desktop\materiale an3\sem2\audiovideo\images", "*.jpg");
            List<Image<Bgr, byte>> listImages = new List<Image<Bgr, byte>>();
            foreach (var file in FileNames)
            {
                listImages.Add(new Image<Bgr, byte>(file));
            }
            for (int i = 0; i < listImages.Count - 1; i++)
            {
                for (double alpha = 0.0; alpha <= 1.0; alpha += 0.01)
                {
                    pictureBox1.Image = listImages[i + 1].AddWeighted(listImages[i], alpha, 1 - alpha, 0).AsBitmap();
                    await Task.Delay(25);
                }
            }
        }
        private void buttonBlending_Click(object sender, EventArgs e)
        {
            BlendImagesAsync();

        }

        private void DisplayFrame(Image<Bgr, byte> frame)
        {
            pictureBox1.Image = frame.ToBitmap();

        }
        private void ProcessFrames(object sender, EventArgs e)
        {
            VideoProcessor.ProcessBgFrames(newBackgroundImage, DisplayFrame);
        }
        
        private void buttonBgSubstract_Click(object sender, EventArgs e)
        {
            try
            {
                VideoProcessor.ApplyBackgroundSubtraction();
                Application.Idle += ProcessFrames;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}