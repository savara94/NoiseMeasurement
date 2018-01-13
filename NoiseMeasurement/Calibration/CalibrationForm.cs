using NAudio.Wave;
using NoiseMeasurement.Calibration;
using NoiseMeasurement.Recording;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoiseMeasurement
{
    public partial class CalibrationForm : Form
    {
        public static readonly double MAX_SOUND_LEVEL = 160;
        private Recording.Recording recording;
        private WaveOut waveOut;
        private int bits;
        private List<double> rmsSamples;
        public CalibrationParams CalibrationParams { get; set; }

        private void InitializeWaveOut()
        {
            short amp = short.Parse(textBoxAmp.Text);
            var sineWaveProvider = new SineWaveProvider16(amp, 500);    
            sineWaveProvider.SetWaveFormat(16000, 1); // 16kHz mono
            waveOut = new WaveOut();
            waveOut.Init(sineWaveProvider);
        }

        private void DeinitializeWaveOut()
        {
            waveOut.Stop();
            waveOut.Dispose();
            waveOut = null;
        }

        public CalibrationForm(int bits, short sample, double noise, Recording.Recording recording)
        {
            InitializeComponent();
            InitializeWaveOut();

            this.bits = bits;
            this.recording = recording;

            switch(bits)
            {
                case 16:
                    textBoxMaxAmp.Text = short.MaxValue.ToString();
                    break;
                default:
                    throw new NotSupportedException();
            }

            textBoxAmp.Text = sample.ToString();
            textBoxDecibel.Text = noise.ToString();
            rmsSamples = new List<double>();
        }

        private void GetAverageSample(short[] buffer)
        {
            double sum = 0;
            foreach(var sample in buffer)
            {
                sum += sample * sample;
            }

            double rms = (short)Math.Sqrt(sum / buffer.Length);
            Console.WriteLine("rms: " + rms);
            rmsSamples.Add(rms);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            waveOut.Play();
            recording.OnDataAvaliable += GetAverageSample;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            recording.OnDataAvaliable -= GetAverageSample;
            waveOut.Pause();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Free()
        {
            recording.OnDataAvaliable -= GetAverageSample;
            DeinitializeWaveOut();
        }

        private void textBoxAmp_TextChanged(object sender, EventArgs e)
        {
            waveOut.Pause();
            try
            {
                short amp = short.Parse(textBoxAmp.Text);
                if (amp < 0 || amp > short.MaxValue)
                {
                    return;
                }
                InitializeWaveOut();
            }
            catch(Exception)
            {
                return;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                double decibel = double.Parse(textBoxDecibel.Text);
                if (decibel < 0 || decibel > MAX_SOUND_LEVEL)
                {
                    return;
                }

                double avgSample = 0;

                foreach(var sample in rmsSamples)
                {
                    avgSample += sample;
                }

                avgSample = avgSample / rmsSamples.Count;

                CalibrationParams = new CalibrationParams();
                CalibrationParams.Noise = decibel;
                CalibrationParams.Sample = (short)avgSample;

                Close();
            }
            catch(Exception)
            {
                return;
            }
        }

        private void CalibrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Free();
        }
    }
}
