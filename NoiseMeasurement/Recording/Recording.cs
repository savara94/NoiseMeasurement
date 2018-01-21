using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseMeasurement.Recording
{
    public class Recording
    {
        public delegate void OnDataAvailableHandler(short[] buffer);
        public event OnDataAvailableHandler OnDataAvaliable;

        private bool isRecording;
        private WaveInEvent waveIn;
        private int moduo;

        public bool IsRecording
        {
            get => isRecording;
            set
            {
                isRecording = value;
                if (value)
                {
                    waveIn.StartRecording();
                }
                else
                {
                    waveIn.StopRecording();
                }
            }
        }

        public Recording(int moduo)
        {
            waveIn = new WaveInEvent();
            this.IsRecording = false;
            this.moduo = moduo;

            waveIn.DataAvailable += OnAudioDataAvailable;
        }

        private void OnAudioDataAvailable(object sender, WaveInEventArgs args)
        {
            if (isRecording)
            {
                var buffer = args.Buffer;
                int numSamples = args.BytesRecorded / 2;
                int samplesToGive = numSamples / moduo;
                short[] samplesToGiveBuffer = new short[samplesToGive];

                int cntr = 0;

                for (int i = 0; i < args.BytesRecorded; i += moduo * 2)
                {
                    short sample = (short)((buffer[i + 1] << 8) | buffer[i]);
                    samplesToGiveBuffer[cntr++] = sample;
                }

                OnDataAvaliable?.Invoke(samplesToGiveBuffer);
            }
        }
    }
}
