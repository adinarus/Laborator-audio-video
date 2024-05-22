using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Reflection.Emit;
using Emgu.CV.Reg;

namespace VideoLibrary
{
    public class VideoProcessor
    {

        private VideoCapture capture;

        private BackgroundSubtractorMOG2 fgDetector;

        private bool isReadingFrame;
        private int totalFrame;
        private int frameNo;
        private double fps;

        public double Fps { get { return fps; } }
        public int TotalFrame { get { return totalFrame; } }
        public int FrameNo { get { return frameNo; } set { frameNo = value; } }
        public VideoCapture Capture { get { return capture; } }

        public VideoProcessor(string filePath)
        {
            capture = new VideoCapture(filePath);
            totalFrame = (int)capture.Get(CapProp.FrameCount);
            fps = capture.Get(CapProp.Fps);
            frameNo = 0;
        }

        public Mat ReadNextFrame()
        {
            if (frameNo < totalFrame)
            {
                frameNo++;
                return capture.QueryFrame();
            }
            else
            {
                return null;
            }
        }

        public void Reset()
        {
            frameNo = 0;
            capture.Set(CapProp.PosFrames, 0);
        }


        public void StartPlayback(Action<Image<Bgr, byte>> frameProcessingAction, Action<int, int> frameUpdateAction)
        {
            isReadingFrame = true;
            ReadAllFrames(frameProcessingAction, frameUpdateAction);
        }

        public void StopPlayback()
        {
            isReadingFrame = false;
        }
        private async void ReadAllFrames(Action<Image<Bgr, byte>> frameProcessingAction, Action<int, int> frameUpdateAction)
        {
            Mat m = new Mat();
            while (isReadingFrame && frameNo < totalFrame)
            {
                frameNo += 1;
                var mat = capture.QueryFrame();

                if (mat != null)
                {
                    Image<Bgr, byte> frame = mat.ToImage<Bgr, byte>();

                    frameProcessingAction?.Invoke(frame);
                }

                frameUpdateAction?.Invoke(frameNo, totalFrame);

                await Task.Delay((int)(1000 / fps));
            }
        }

        public void ProcessBgFrames(Image<Bgr, byte> newBackgroundImage, Action<Image<Bgr, byte>> frameProcessingAction)
        {
            Mat frame = capture.QueryFrame();
            Image<Bgr, byte> frameImage = frame.ToImage<Bgr, Byte>();
            Mat foregroundMask = new Mat();

            fgDetector.Apply(frameImage.Mat, foregroundMask);
            var foregroundMaskImage = foregroundMask.ToImage<Gray, byte>();
            foregroundMaskImage = foregroundMaskImage.Not();

            var copyOfNewBackgroundImage = newBackgroundImage.Resize(foregroundMaskImage.Width, foregroundMaskImage.Height, Inter.Lanczos4);
            copyOfNewBackgroundImage = copyOfNewBackgroundImage.Copy(foregroundMaskImage);

            foregroundMaskImage = foregroundMaskImage.Not();
            frameImage = frameImage.Copy(foregroundMaskImage);
            frameImage = frameImage.Or(copyOfNewBackgroundImage);

            frameProcessingAction?.Invoke(frameImage);

        }
        public void ApplyBackgroundSubtraction()
        {

            fgDetector = new BackgroundSubtractorMOG2();

        }
        public static bool SaveVideo(string sourcePath, string logoPath, string destinationPath)
        {
        
            using (VideoCapture capture = new VideoCapture(sourcePath))
            {
                if (!capture.IsOpened)
                {
                    return false;
                }

                int Fourcc = Convert.ToInt32(capture.Get(CapProp.FourCC));
                int Width = Convert.ToInt32(capture.Get(CapProp.FrameWidth));
                int Height = Convert.ToInt32(capture.Get(CapProp.FrameHeight));
                var Fps = capture.Get(CapProp.Fps);
                var TotalFrame = capture.Get(CapProp.FrameCount);

                using (VideoWriter writer = new VideoWriter(destinationPath, Fourcc, Fps, new Size(Width, Height), true))
                {
                    Image<Bgr, byte> logo = new Image<Bgr, byte>(logoPath);
                    Mat m = new Mat();

                    var FrameNo = 1;
                    while (FrameNo <= TotalFrame)
                    {
                        capture.Read(m);

                        Image<Bgr, byte> img = m.ToImage<Bgr, byte>();

                        if (Width - logo.Width - 30 >= 0 && 10 + logo.Height <= Height)
                        {
                            img.ROI = new Rectangle(Width - logo.Width - 30, 10, logo.Width, logo.Height);
                            logo.CopyTo(img);
                            img.ROI = Rectangle.Empty;
                        }

                        writer.Write(img.Mat);
                        FrameNo++;
                    }
                }
            }
            return true;
            
        }

        public static bool SaveFirstFrameAsImage(string videoPath, string imagePath)
        {
           
            using (VideoCapture capture = new VideoCapture(videoPath))
            {
                if (!capture.IsOpened)
                {
                    return false;
                }

                Mat firstFrame = new Mat();
                if (!capture.Read(firstFrame) || firstFrame.IsEmpty)
                {
                    return false;
                }

                Image<Bgr, byte> firstFrameImage = firstFrame.ToImage<Bgr, byte>();
                firstFrameImage.Save(imagePath);
                return true;
            }
            
     
        }

        public static async void ApplyAbruptTransition(string videoPath1, string videoPath2, string outputPath)
        {
            try
            {
                var processor1 = new VideoProcessor(videoPath1);
                var processor2 = new VideoProcessor(videoPath2);

                int width = Convert.ToInt32(processor1.Capture.Get(CapProp.FrameWidth));
                int height = Convert.ToInt32(processor1.Capture.Get(CapProp.FrameHeight));
                int fourcc = Convert.ToInt32(processor1.Capture.Get(CapProp.FourCC));
                double fps = processor1.Fps;

                using (VideoWriter writer = new VideoWriter(outputPath, fourcc, fps, new Size(width, height), true))
                {
                    if (processor1 != null && processor2 != null)
                    {
                        WriteFrames(processor1, writer, processor1.TotalFrame);

                        WriteFrames(processor2, writer, processor2.TotalFrame);
                    }
                    else
                    {
                        MessageBox.Show("Error: One or both video files could not be opened.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async Task ApplyCrossDissolveTransition(string videoPath1, string videoPath2, string outputPath, int transitionFrames = 50)
        {
            var processor1 = new VideoProcessor(videoPath1);
            var processor2 = new VideoProcessor(videoPath2);

            int width = Convert.ToInt32(processor1.Capture.Get(CapProp.FrameWidth));
            int height = Convert.ToInt32(processor1.Capture.Get(CapProp.FrameHeight));
            int fourcc = Convert.ToInt32(processor1.Capture.Get(CapProp.FourCC));
            double fps = processor1.Fps;

            using (VideoWriter writer = new VideoWriter(outputPath, fourcc, fps, new Size(width, height), true))
            {
                WriteFrames(processor1, writer, processor1.TotalFrame - transitionFrames);

                await CrossDissolveFrames(processor1, processor2, writer, transitionFrames);

                WriteFrames(processor2, writer, processor2.TotalFrame, transitionFrames);
            }
        }

        private static void WriteFrames(VideoProcessor processor, VideoWriter writer, int maxFrames, int startFrame = 0)
        {
            Mat frame;
            processor.FrameNo = startFrame;
            processor.Reset();
            for (int i = 0; i < maxFrames; i++)
            {
                frame = processor.ReadNextFrame();
                if (frame != null && !frame.IsEmpty)
                {
                    writer.Write(frame);
                }
            }
        
        }

        private static async Task CrossDissolveFrames(VideoProcessor processor1, VideoProcessor processor2, VideoWriter writer, int transitionFrames)
        {
            List<Image<Bgr, byte>> frames1 = new List<Image<Bgr, byte>>();
            List<Image<Bgr, byte>> frames2 = new List<Image<Bgr, byte>>();

            processor1.FrameNo = processor1.TotalFrame - transitionFrames;
            processor1.Reset();
            for (int i = 0; i < transitionFrames; i++)
            {
                Mat frame = processor1.ReadNextFrame();
                if (frame != null && !frame.IsEmpty)
                {
                    frames1.Add(frame.ToImage<Bgr, byte>());
                }
            }

            processor2.Reset();
            for (int i = 0; i < transitionFrames; i++)
            {
                Mat frame = processor2.ReadNextFrame();
                if (frame != null && !frame.IsEmpty)
                {
                    frames2.Add(frame.ToImage<Bgr, byte>());
                }
            }

            for (int i = 0; i < transitionFrames; i++)
            {
                double alpha = (double)i / (transitionFrames - 1);
                Image<Bgr, byte> blendedFrame = frames1[i].AddWeighted(frames2[i], 1 - alpha, alpha, 0);
                writer.Write(blendedFrame.Mat);
                await Task.Delay(1000 / (int)processor1.Fps); 
            }
        }
    }
}
