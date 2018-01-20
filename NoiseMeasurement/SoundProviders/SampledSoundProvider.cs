using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseMeasurement.SoundProviders
{
    class SampledSoundProvider : WaveProvider16
    {
        private int sample;
        private short[] samples;

        public SampledSoundProvider(short[] samples)
        {
            this.samples = samples;
        }

        public override int Read(short[] buffer, int offset, int sampleCount)
        {
            if (sample >= samples.Length)
            {
                return 0;
            }

            int sampleRate = WaveFormat.SampleRate;
            int n = 0;
            for (n = 0; n < sampleCount; n++)
            {
                buffer[n + offset] = samples[sample];
                sample++;
                if (sample >= samples.Length) break;
            }

            return n;
        }
    }
}
