using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
        }

        private void buttonSelectAudio_Click(object sender, EventArgs e)
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(@"C:\Users\Adi\Desktop\materiale an3\sem2\audiovideo\never_gonna_give_you_up.mp3");
                outputDevice.Init(audioFile);
            }
            outputDevice.Play();

        }

        private void buttonAudioStop_Click(object sender, EventArgs e)
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
            }
        }

        private void buttonPitch_Click(object sender, EventArgs e)
        {
            var inPath = @"C:\Users\Adi\Desktop\materiale an3\sem2\audiovideo\never_gonna_give_you_up.mp3";
            var semitone = Math.Pow(2, 1.0 / 12);
            var upOneTone = semitone * semitone;
            var downOneTone = 1.0 / upOneTone;
            using (var reader = new MediaFoundationReader(inPath))
            {
                var pitch = new SmbPitchShiftingSampleProvider(reader.ToSampleProvider());
                using (var device = new WaveOutEvent())
                {
                    pitch.PitchFactor = (float)upOneTone; // or downOneTone
                                                          // just playing the first 5 seconds of the file
                    device.Init(pitch.Take(TimeSpan.FromSeconds(5)));
                    device.Play();
                    while (device.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(500);
                    }
                }
            }

        }
    }
}
