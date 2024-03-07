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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Image<Bgr, Byte> My_Image;
        public Form1()
        {
            InitializeComponent();
        }


        private void button_image_upload_Click(object sender, EventArgs e)
        {
            LoadImage();
            
        }

        private void LoadImage()
        {
            OpenFileDialog Openfile = new OpenFileDialog();
            if (Openfile.ShowDialog() == DialogResult.OK)
            {
                My_Image = new Image<Bgr, byte>(Openfile.FileName);
                pictureBox1.Image = My_Image.ToBitmap();
            }
        }

        private void button_histogram_Click(object sender, EventArgs e)
        {
            ShowHistogram();
        }

        private void ShowHistogram()
        {
            if (My_Image != null)
            {
                HistogramViewer v = new HistogramViewer();
                v.HistogramCtrl.GenerateHistograms(My_Image, 255);
                v.Show();
            }
            else
            {
                MessageBox.Show("Please load an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button_image_modify_Click(object sender, EventArgs e)
        {
            decimal alpha;
            decimal beta;
            alpha = numericUpDownAlpha.Value;
            beta = numericUpDownBeta.Value;

            var outputImage = My_Image.Mul((float)alpha) + (float)beta;

            pictureBox1.Image = outputImage.ToBitmap();
             
        }
    }
}
