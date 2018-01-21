using AForge.Math;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MathNet.Numerics;
using NAudio.Wave;
using NoiseMeasurement.Calibration;
using NoiseMeasurement.DB;
using NoiseMeasurement.SoundProviders;
using System;
using System.Device.Location;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NoiseMeasurement
{
    public partial class MainForm : Form
    {
        private int TIMEDOMAIN_MAXPOINTS = 10000;

        private WaveOut waveOut;
        private Recording.Recording recording;
        private CalibrationParams CalibrationParams;

        private short[] wavSamples;
        private int wavSampleRate;
        private int vuMeterCntr;
        private short[] toBePlayed;

        private Filters.Filters filters;
        private Averaging.TimeAveraging timeAveraging;
        private PointLatLng deviceGeoLocation;
        private DBUpdater dbUpdater;
        private bool IsDeviceSelected;
        private PointLatLng SelectedDeviceLocation;
        private DateTime timestampForDbUpdate;
        private GMapOverlay markersOverlay;

        private void InitializeWaveOut()
        {
            waveOut = new WaveOut();
            waveOut.PlaybackStopped += WaveOut_PlaybackStopped;
        }

        private void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            btnPlay.Enabled = true;
            btnPause.Enabled = false;
        }

        private void DeinitializeWaveOut()
        {
            waveOut.Stop();
            waveOut.Dispose();
            waveOut = null;
        }

        public MainForm()
        {
            InitializeComponent();
            InitializeWaveOut();
            double lat, lng;
            GetLatLong(out lat, out lng);
            if (lat == -1 && lng == -1)
            {
                gMap.Enabled = false;
                return;
            }
            deviceGeoLocation = new PointLatLng(lat, lng);
            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);
            dbUpdater = new DBUpdater(deviceGeoLocation);
            InitializeGMap();
            recording = new Recording.Recording(4);
            timeAveraging = new Averaging.TimeAveraging(lblLavgValue, lblTWAValue, lblDoseValue);
            comboBoxTimeWeight.SelectedIndex = 0;
            recording.OnDataAvaliable += UpdateTimeDomain;
            recording.OnDataAvaliable += UpdateVUMeter;
            recording.OnDataAvaliable += timeAveraging.GatherNewData;

            CalibrationParams = new CalibrationParams
            {
                Sample = (short)Properties.Settings.Default["calibration_sample"],
                Noise = (double)Properties.Settings.Default["calibration_noise"]
            };

            freqDomain.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            freqDomain.ChartAreas[0].CursorX.AutoScroll = true;
            freqDomain.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

            octaveFreqDomain.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            octaveFreqDomain.ChartAreas[0].CursorX.AutoScroll = true;
            octaveFreqDomain.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

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

            lblLeqValue.Invoke((MethodInvoker)delegate
            {
                lblLeqValue.Text = ((int)(measured_noise)).ToString() + " dB";
            });

            dbUpdater.InsertReading(measured_noise);
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
                if (reader.WaveFormat.SampleRate != 44100)
                {
                    MessageBox.Show("Only 44.1kHz sample rate is allowed!", "Unsupported file",
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

            filters = new Filters.Filters(wavSamples);
            FillComboboxFreq(false);
            UpdateFreqDomain(filters.frequencyDomain);
            toBePlayed = filters.input;
        }

        #endregion

        private void UpdateFreqDomain(Complex32[] freq)
        {
            freqDomain.Invoke((MethodInvoker)delegate
            {
                freqDomain.Series["Amplitudes"].Points.Clear();
                for (int i = 0; i < 22050; i++)
                {
                    var freqSample = freq[i].Magnitude;
                    freqDomain.Series["Amplitudes"].Points.AddY(freqSample);
                }
            });
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                var btn = sender as RadioButton;
                if (!btn.Checked)
                {
                    return;
                }

                if (ReferenceEquals(btn, radioNone))
                {
                    UpdateFreqDomain(filters.frequencyDomain);
                    toBePlayed = filters.input;
                }
                else if (ReferenceEquals(btn, radioAfilter))
                {
                    UpdateFreqDomain(filters.AWeightedFreq);
                    toBePlayed = filters.AWeightedOutput;
                }
                else if (ReferenceEquals(btn, radioCfilter))
                {
                    UpdateFreqDomain(filters.CWeightedFreq);
                    toBePlayed = filters.CWeightedOutput;

                }
                else if (ReferenceEquals(btn, radioBtnOctave))
                {
                    FillComboboxFreq(false);
                }
                else if (ReferenceEquals(btn, radioBtnThirdOctave))
                {
                    FillComboboxFreq(true);
                }
            }
            else
            {
                return;
            }
        }

        private void UpdateOctaveFreqDomain(Complex32[] freq)
        {
            octaveFreqDomain.Invoke((MethodInvoker)delegate
            {
                octaveFreqDomain.Series["Octave"].Points.Clear();
                for (int i = 0; i < 22050; i++)
                {
                    var freqSample = freq[i].Magnitude;
                    octaveFreqDomain.Series["Octave"].Points.AddY(freqSample);
                }
            });
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            waveOut.Init(new SampledSoundProvider(toBePlayed));
            waveOut.Play();
            btnPlay.Enabled = false;
            btnPause.Enabled = true;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            DeinitializeWaveOut();
            btnPause.Enabled = false;
            btnPlay.Enabled = true;
            InitializeWaveOut();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeinitializeWaveOut();
        }

        private void FillComboboxFreq(bool thirdOctave)
        {
            comboBoxFreq.Items.Clear();
            float[] frequencies = thirdOctave ? Filters.Filters.ThirdOctaveBandCenterFrequencies : Filters.Filters.OctaveBandCenterFrequencies;

            foreach (var freq in frequencies)
            {
                comboBoxFreq.Items.Add(freq + " Hz");
            }

            comboBoxFreq.SelectedIndex = 0;
        }

        private void comboBoxFreq_SelectedIndexChanged(object sender, EventArgs e)
        {
            Complex32[][] freq = radioBtnThirdOctave.Checked ? filters.ThirdOctaveBandFreqs : filters.OctaveBandFreqs;
            var band = comboBoxFreq.SelectedIndex;
            toBePlayed = radioBtnThirdOctave.Checked ? filters.ThirdOctaveBandOutput[band] : filters.OctaveBandOutput[band];
            UpdateOctaveFreqDomain(freq[band]);
        }

        private void comboBoxTimeWeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            timeAveraging.TimeWeightIndex = comboBoxTimeWeight.SelectedIndex;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InitializeGMap()
        {
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMap.DragButton = MouseButtons.Left;
            gMap.Position = deviceGeoLocation;
            GetDevicesLocations();
        }

        private void GetDevicesLocations()
        {
            var locations = dbUpdater.GetDeviceLocations();
            foreach (var location in locations)
            {
                markersOverlay = new GMapOverlay("markers");
                GMarkerGoogle marker = new GMarkerGoogle(deviceGeoLocation, GMarkerGoogleType.red);
                marker.ToolTipText = "Click to show device readings.";
                markersOverlay.Markers.Add(marker);
                gMap.Overlays.Add(markersOverlay);
            }
        }

        private void GetLatLong(out double lat, out double lng)
        {
            string url = "http://ip-api.com/xml";
            WebRequest request = WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (var sr = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    XDocument xmlDoc = new XDocument();
                    try
                    {
                        xmlDoc = XDocument.Parse(sr.ReadToEnd());
                        string status = xmlDoc.Root.Element("status").Value;
                        Console.WriteLine("Response status: {0}", status);
                        if (status == "success")
                        {
                            lat = double.Parse(xmlDoc.Root.Element("lat").Value);
                            lng = double.Parse(xmlDoc.Root.Element("lon").Value);
                            return;
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            catch (WebException)
            {

            }

            lat = -1;
            lng = -1;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!IsDeviceSelected)
            {
                timestampForDbUpdate = DateTime.MinValue;
                return;
            }
            var readings = dbUpdater.GetNewReadings(SelectedDeviceLocation, timestampForDbUpdate);

            sensorReadings.Invoke((MethodInvoker)delegate
            {
                var points = sensorReadings.Series["Readings"].Points;
                foreach (var reading in readings)
                {
                   if (points.Count == 10000)
                    {
                        points.RemoveAt(0);
                    }
                   points.AddY(reading);
                }
            });

            timestampForDbUpdate = DateTime.Now;
        }

        private void gMap_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var marker in markersOverlay.Markers)
            {
                if (marker.IsMouseOver)
                {
                    IsDeviceSelected = true;
                    SelectedDeviceLocation = marker.Position;
                    sensorReadings.Series["Readings"].Points.Clear();
                    timestampForDbUpdate = DateTime.MinValue;
                    break;
                }
            }
        }
    }
}
