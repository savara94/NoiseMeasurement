using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseMeasurement.Calibration
{
    class SineWaveProvider16 : WaveProvider16
    {
        private int sample;
        private short amplitude;
        private short frequency;

        public SineWaveProvider16(short amplitude, short frequency)
        {
            this.amplitude = amplitude;
            this.frequency = frequency;
        }

        public override int Read(short[] buffer, int offset, int sampleCount)
        {
            int sampleRate = WaveFormat.SampleRate;
            for (int n = 0; n < sampleCount; n++)
            {
                buffer[n + offset] = (short)(amplitude * Math.Sin((2 * Math.PI * sample * frequency) / sampleRate));
                sample++;
                if (sample >= sampleRate) sample = 0;
            }
            return sampleCount;
        }
    }
}