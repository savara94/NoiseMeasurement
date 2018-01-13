﻿using NAudio.Wave;
using NoiseMeasurement.Calibration;
using System;
using System.Windows.Forms;

namespace NoiseMeasurement
{
    public partial class MainForm : Form
    {
        private int TIMEDOMAIN_MAXPOINTS = 10000;
        private Recording.Recording recording;
        private CalibrationParams CalibrationParams;

        private short[] wavSamples;
        private int wavSampleRate;
        private int vuMeterCntr;

        public MainForm()
        {
            InitializeComponent();

            recording = new Recording.Recording(4);
            recording.OnDataAvaliable += UpdateTimeDomain;
            recording.OnDataAvaliable += UpdateVUMeter;

            CalibrationParams = new CalibrationParams
            {
                Sample = (short)Properties.Settings.Default["calibration_sample"],
                Noise = (double)Properties.Settings.Default["calibration_noise"]
            };

            timeDomain.ChartAreas[0].AxisY.Maximum = short.MaxValue;
            timeDomain.ChartAreas[0].AxisY.Minimum = short.MinValue;

            recording.IsRecording = true;
        }

        private void UpdateTimeDomain(short[] buffer)
        {
            timeDomain.Invoke((MethodInvoker)delegate
            {
                var points = timeDomain.Series["Samples"].Points;

                while (points.Count > TIMEDOMAIN_MAXPOINTS)
                {
                    points.RemoveAt(0);
                }

                foreach (var samp in buffer)
                {
                    points.AddY(samp);
                }
            });
        }

        private void UpdateVUMeter(short[] buffer)
        {
            vuMeterCntr++;

            double rms = 0;
            foreach (var sample in buffer)
            {
                rms += sample * sample;
            }
            rms = Math.Sqrt(rms / buffer.Length);

            short calibrated_sample = CalibrationParams.Sample;
            double calibrated_noise = CalibrationParams.Noise;
            short measured_sample = (short)rms;

            double measured_noise = calibrated_noise + 10.0 * Math.Log10((double)measured_sample / calibrated_sample);
            vuMeter.Level = (int)measured_noise;

            lblNoise.Invoke((MethodInvoker)delegate
            {
               lblNoise.Text = ((int)(measured_noise)).ToString();
            });
        }

        #region Calibration

        private void calibrateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalibrationForm calibrationForm = new CalibrationForm(16, CalibrationParams.Sample,
                CalibrationParams.Noise, recording);

            calibrationForm.ShowDialog();

            if (calibrationForm.CalibrationParams != null)
            {
                CalibrationParams = calibrationForm.CalibrationParams;
                Properties.Settings.Default["calibration_sample"] = CalibrationParams.Sample;
                Properties.Settings.Default["calibration_noise"] = CalibrationParams.Noise;
                Properties.Settings.Default.Save();
            }
        }

        #endregion

        #region WAV_read
        private bool ReadWAVFile(string path)
        {
            using (WaveFileReader reader = new WaveFileReader(path))
            {
                if (reader.WaveFormat.BitsPerSample != 16)
                {
                    MessageBox.Show("Only 16 bits per sample is allowed!", "Unsupported file",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                wavSampleRate = reader.WaveFormat.SampleRate;
                bool stereo = false;

                switch (reader.WaveFormat.Channels)
                {
                    case 1:
                        break;
                    case 2:
                        stereo = true;
                        break;
                    default:
                        MessageBox.Show("Only mono or stereo is allowed!", "Unsupported file",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                }

                byte[] buffer = new byte[reader.Length];
                int read = reader.Read(buffer, 0, buffer.Length);
                short[] bufferSamples = new short[read / 2];
                Buffer.BlockCopy(buffer, 0, bufferSamples, 0, read);

                if (stereo)
                {
                    wavSamples = new short[bufferSamples.Length / 2];
                    // Pick only left channel
                    for (int i = 0; i < bufferSamples.Length; i += 2)
                    {
                        wavSamples[i / 2] = bufferSamples[i];
                    }
                }
                else
                {
                    wavSamples = bufferSamples;
                }
            }

            return true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Wav Files Only(*.wav) | *.wav";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (!ReadWAVFile(openFileDialog.FileName))
            {
                return;
            }
        }

        #endregion

    }
}