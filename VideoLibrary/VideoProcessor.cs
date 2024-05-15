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
       

        public VideoProcessor(string filePath)
        {
            capture = new VideoCapture(filePath);
            totalFrame = (int)capture.Get(CapProp.FrameCount);
            fps = capture.Get(CapProp.Fps);
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

    }
}
