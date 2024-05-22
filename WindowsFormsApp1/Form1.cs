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

        private bool isImageUploaded = false;
        private bool isVideoPlaying = false;
        private Image<Bgr, Byte> newBackgroundImage = new Image<Bgr, Byte>("C:\\Users\\Adi\\Desktop\\freddy.jpg");


        public Form1()
        {
            InitializeComponent();
            ImageProcessor  = new ImageProcessor();
            
        }

        private bool IsROISet()
        {
            bool isROISet = ImageProcessor.GetImage().IsROISet;
            return isROISet;
        }

        private void button_image_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                ImageProcessor.LoadImage(openFile.FileName);
                pictureBoxFull.Image = ImageProcessor.ProcessedImage.ToBitmap();
                isImageUploaded = true;
                ImageProcessor.GetImage().ROI = Rectangle.Empty;
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            

            ImageProcessor.ResetImage();

            ImageProcessor.ProcessedImage.ROI = Rectangle.Empty;

            pictureBoxFull.Image = ImageProcessor.ProcessedImage.ToBitmap();

            pictureBoxROI.Image = null;
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
            if (isImageUploaded)
            {
                double gamma = (double)numericUpDownGamma.Value;
                
                if (!IsROISet())
                {
                    var EditedImage = ImageProcessor.ApplyGammaCorrection(ImageProcessor.GetImage(), gamma);
                    pictureBoxFull.Image = EditedImage.ToBitmap();
                }
                else
                {
                    var ImageROI = ImageProcessor.GetImage().Copy();
                    ImageProcessor.GetImage().SetValue(new Bgr(1, 1, 1));
                    ImageProcessor.ApplyGammaCorrection(ImageROI, gamma);
                    ImageProcessor.GetImage()._Mul(ImageROI);
                    pictureBoxROI.Image = ImageProcessor.GetImage().ToBitmap();
                }
                
            }
            
            
        }
        private void buttonConvertGrayscale_Click(object sender, EventArgs e)
        {
            //var grayImage = ImageProcessor.ConvertToGrayscale();

            //// Convert the grayscale image back to Bgr format
            //Image<Bgr, byte> grayAsBgr = grayImage.Convert<Bgr, byte>();

            //// Display the grayscale image in pictureBox2
            //pictureBox2.Image = grayAsBgr.AsBitmap();

            //// Modify a pixel value in the grayscale image (if needed)
            //grayImage[0, 0] = new Gray(200);
        }

        private void button_contrast_brightness_Click(object sender, EventArgs e)
        {
            if (isImageUploaded)
            {
                double alpha = (double)numericUpDownAlpha.Value;
                double beta = (double)numericUpDownBeta.Value;
                if (!IsROISet())
                {
                    var result = ImageProcessor.ChangeBrightnessAndContrast(ImageProcessor.GetImage(), alpha, beta);
                    pictureBoxFull.Image = result.ToBitmap();
                }

                else
                {
                    var ImageROI = ImageProcessor.GetImage().Copy();
                    ImageProcessor.GetImage().SetValue(new Bgr(1, 1, 1));
                    var EditedImage = ImageProcessor.ChangeBrightnessAndContrast(ImageROI, alpha, beta);
                    ImageProcessor.GetImage()._Mul(EditedImage);
                    pictureBoxROI.Image = ImageProcessor.GetImage().ToBitmap();
                    ImageProcessor.GetImage().ROI = Rectangle.Empty;

            
                }
            }
            
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

            if (!IsROISet())
            {
                ImageProcessor.ApplyFilter(ImageProcessor.GetImage(), r, g, b);
                pictureBoxFull.Image = ImageProcessor.GetImage().ToBitmap();
            }
            else
            {

                var ImageROI = ImageProcessor.GetImage().Copy();
                ImageProcessor.GetImage().SetValue(new Bgr(1, 1, 1));
                ImageProcessor.ApplyFilter(ImageROI, r, g, b);
                ImageProcessor.GetImage()._Mul(ImageROI);
                pictureBoxROI.Image = ImageProcessor.GetImage().ToBitmap();
                
             
            }

            ImageProcessor.GetImage().ROI = Rectangle.Empty;
        }
  
        private void buttonScale_Click(object sender, EventArgs e)
        {
            var scale = (float)numericUpDownResize.Value;
            pictureBoxFull.Image = ImageProcessor.GetImage().ToBitmap();

            if (!IsROISet())
            {
                var img = ImageProcessor.ScaleImage(ImageProcessor.GetImage(), scale);
                pictureBoxFull.Image = img.ToBitmap();

            }
            else
            {
                var ImageROI = ImageProcessor.GetImage().Copy();
                ImageProcessor.GetImage().SetValue(new Bgr(1, 1, 1));
                var img = ImageProcessor.ScaleImage(ImageROI, scale);
                ImageProcessor.GetImage().ROI = Rectangle.Empty;
                pictureBoxFull.Image = img.ToBitmap();
            }
        }

        private void buttonResizeWidthHeight_Click(object sender, EventArgs e)
        {
            var width = (int)numericUpDownWidth.Value;
            var height = (int)numericUpDownHeight.Value;

            if (!IsROISet())
            {
                var img = ImageProcessor.ResizeImage(ImageProcessor.GetImage(), width, height);
                pictureBoxFull.Image = img.ToBitmap();
                
            }
            else
            {
                var img2 = ImageProcessor.GetImage().Copy();
                ImageProcessor.GetImage().SetValue(new Bgr(1, 1, 1));
                var img = ImageProcessor.ResizeImage(img2, width, height);
                
                //ImageProcessor.GetImage()._Mul(img);

                ImageProcessor.GetImage().ROI = Rectangle.Empty;
                pictureBoxFull.Image = img.ToBitmap();
            }
            
            
        }

        private void buttonRotate_Click(object sender, EventArgs e)
        {
            var angle = (int)numericUpDownRotate.Value;
            if (!IsROISet())
            {
                var img = ImageProcessor.RotateImage(ImageProcessor.GetImage(), angle);
                pictureBoxFull.Image = img.ToBitmap();

            }
            else
            {
                var img2 = ImageProcessor.GetImage().Copy();
                ImageProcessor.GetImage().SetValue(new Bgr(1, 1, 1));
                var img = ImageProcessor.RotateImage(img2, angle);
                ImageProcessor.GetImage()._Mul(img);

                ImageProcessor.GetImage().ROI = Rectangle.Empty;
                pictureBoxFull.Image = ImageProcessor.GetImage().ToBitmap();
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBoxFull.Image == null)
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
            if (pictureBoxFull.Image == null || rect == Rectangle.Empty)
            { return; }

            ImageProcessor.GetImage().ROI = rect;
            var imgROI = ImageProcessor.GetImage().Copy();
            pictureBoxROI.Image = imgROI.ToBitmap();

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
            labelMessage.Visible = true;
            labelMessage.Text = $"Frames: {currentFrame}/{totalFrame}";
        }

        private void buttonVideoUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                VideoProcessor = new VideoProcessor(ofd.FileName);
                Mat m = new Mat();
                isVideoPlaying = true;
                buttonPlayVideo.Text = "Pause";
                VideoProcessor.StartPlayback(DisplayImage, UpdateFrameLabel);
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
                VideoProcessor.StartPlayback(DisplayImage, UpdateFrameLabel);
                isVideoPlaying = true;
                buttonPlayVideo.Text = "Pause";
            }
        }

        async Task BlendImages(string directoryPath)
        {
            string[] FileNames = Directory.GetFiles(directoryPath, "*.jpg");
            List<Image<Bgr, byte>> listImages = new List<Image<Bgr, byte>>();
            foreach (var file in FileNames)
            {
                listImages.Add(new Image<Bgr, byte>(file));
            }
            for (int i = 0; i < listImages.Count - 1; i++)
            {
                for (double alpha = 0.0; alpha <= 1.0; alpha += 0.01)
                {
                    pictureBoxFull.Image = listImages[i + 1].AddWeighted(listImages[i], alpha, 1 - alpha, 0).AsBitmap();
                    await Task.Delay(25);
                }
            }
        }
        private void buttonBlending_Click(object sender, EventArgs e)
        {
            BlendImages(@"C:\Users\Adi\Desktop\materiale an3\sem2\audiovideo\images");
        }

        private void DisplayImage(Image<Bgr, byte> frame)
        {
            pictureBoxFull.Image = frame.ToBitmap();

        }
        private void ProcessFrames(object sender, EventArgs e)
        {
            VideoProcessor.ProcessBgFrames(newBackgroundImage, DisplayImage);
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

        private void buttonSaveVideo_Click(object sender, EventArgs e)
        {
            string logoPath = @"C:\Users\Adi\Desktop\materiale an3\sem2\audiovideo\videoLogo.jpg";
            string sourcePath = @"C:\Users\Adi\Desktop\materiale an3\sem2\audiovideo\DragonDancing.mp4";
            string destinationPath = @"C:\Users\Adi\Desktop\materiale an3\sem2\audiovideo\DragonDancingCopy.mp4";

            bool result = VideoProcessor.SaveFirstFrameAsImage(sourcePath, logoPath);

            if (!result)
            {
                labelMessage.Text = "Error occurred during video saving";
                labelMessage.Visible = true;
                return;
            }

            bool success = VideoProcessor.SaveVideo(sourcePath, logoPath, destinationPath);

            if (success)
            {
                labelMessage.Text = "Finished writing video";
                labelMessage.Visible = true;
            }
            else
            {
                labelMessage.Text = "Error occurred during video saving";
                labelMessage.Visible = true;
            }
        }
        private void buttonTransition_Click(object sender, EventArgs e)
        {
            string path1 = @"C:\Users\Adi\Desktop\materiale an3\sem2\audiovideo\DragonDancing.mp4";
            string path2 = @"C:\Users\Adi\Desktop\materiale an3\sem2\audiovideo\bongocat2.mp4";
            string outputPath = @"C:\Users\Adi\Desktop\materiale an3\sem2\audiovideo\output.mp4";


            switch (comboBoxTransition.SelectedIndex)
            {
                case 0:
                    VideoProcessor.ApplyAbruptTransition(path1, path2, outputPath);
                    labelMessage.Text = "Finished writing video with abrupt transition";
                    break;
                case 1:
                    VideoProcessor.ApplyCrossDissolveTransition(path1, path2, outputPath);
                    labelMessage.Text = "Finished writing video with cross-dissolve transition";
                    break;
                case 2:
                    //VideoProcessor.ApplyFadeToBlackTransition(path1, path2, outputPath);
                    labelMessage.Text = "Please select another type, work in progress";
                    break;
                default:
                    labelMessage.Text = "Please select transition type";
                    break;
            }

            labelMessage.Visible = true;

        }


    }
}