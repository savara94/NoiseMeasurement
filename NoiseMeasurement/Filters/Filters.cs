using AForge.Math;
using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseMeasurement.Filters
{
    public partial class Filters
    {
        public short[] input;
        private short[] AWeightedOutput;
        private short[] CWeightedOutput;
        private short[][] OctaveBandOutput;
        private short[][] ThirdOctaveBandOutput;

        public Complex32[] FrequencyDomain;
        private short max_sample;
        private short min_sample;
        private Complex32[][] OctaveBandFreqs;
        private Complex32[][] ThirdOctaveBandFreqs;
        private Complex32[] AWeightedFreq;
        private Complex32[] CWeightedFreq;

        private delegate float filter(float freq);

        public short[] AWeightFilterOutput
        {
            get
            {
                if (AWeightedOutput == null)
                {
                    ApplyAWeightedFilter();
                }

                return AWeightedOutput;
            }
        }

        public short[] CWeightFilterOutput
        {
            get
            {
                if (CWeightedOutput == null)
                {
                    ApplyCWeightedFilter();
                }

                return CWeightedOutput;
            }
        }

        public Complex32[] AWeightFilterFrequency
        {
            get
            {
                if (AWeightedFreq == null)
                {
                    ApplyAWeightedFilter();
                }

                return AWeightedFreq;
            }
        }

        public Complex32[] CWeightFilterFrequency
        {
            get
            {
                if (CWeightedFreq == null)
                {
                    ApplyCWeightedFilter();
                }

                return CWeightedFreq;
            }
        }

        public short[] GetOctaveFilterOutput(int band, bool thirdOctave)
        {
            short[][] ptr = thirdOctave ? ThirdOctaveBandOutput : OctaveBandOutput;
            if (ptr[band] == null)
            {
                ApplyOctaveBandFilter(band, thirdOctave);
            }

            return ptr[band];
        }

        public Complex32[] GetOctaveFilterFrequency(int band, bool thirdOctave)
        {
            Complex32[][] ptr = thirdOctave ? ThirdOctaveBandFreqs : OctaveBandFreqs;
            if (ptr[band] == null)
            {
                ApplyOctaveBandFilter(band, thirdOctave);
            }

            return ptr[band];
        }

        public Filters(short[] input)
        {
            this.input = input;
            max_sample = short.MinValue;

            foreach(var sample in input)
            {
                if (sample > max_sample)
                {
                    max_sample = sample;
                }
            }
            ThirdOctaveBandFreqs = new Complex32[ThirdOctaveBandCenterFrequencies.Length][];
            ThirdOctaveBandOutput = new short[ThirdOctaveBandCenterFrequencies.Length][];

            OctaveBandFreqs = new Complex32[ThirdOctaveBandCenterFrequencies.Length][];
            OctaveBandOutput = new short[ThirdOctaveBandCenterFrequencies.Length][];

            FrequencyDomain = GetFrequencyDomain(input);
        }

        private void GenerateFilterOutputs(Complex32[] frequencies, short[] timeDomainSamples, filter filter)
        {
            
            for (int i = 1; i < frequencies.Length; i++)
            {
                float scale = filter(i);
                frequencies[i] = new Complex32(scale* FrequencyDomain[i].Real, scale * FrequencyDomain[i].Imaginary);
            }

            Complex32[] inverseinput = new Complex32[frequencies.Length];
            for (int i = 0; i < inverseinput.Length; i++)
            {
                inverseinput[i] = new Complex32(frequencies[i].Real, frequencies[i].Imaginary);
            }

            MathNet.Numerics.IntegralTransforms.Fourier.Inverse(inverseinput, MathNet.Numerics.IntegralTransforms.FourierOptions.Default);
            short max_sample_filtered = short.MinValue;

            for (int i = 0; i < timeDomainSamples.Length; i++)
            {
                float sample = inverseinput[i].Real;
                if (sample < short.MinValue)
                {
                    timeDomainSamples[i] = short.MinValue;
                }
                else
                if (sample > short.MaxValue)
                {
                    timeDomainSamples[i] = short.MaxValue;
                }
                else
                {
                    timeDomainSamples[i] = (short)sample;
                }

                if (timeDomainSamples[i] > max_sample_filtered)
                {
                    max_sample_filtered = timeDomainSamples[i];
                }
            }

            float scale_factor = 1.0f * max_sample / max_sample_filtered;

            for(int i = 0; i < timeDomainSamples.Length; i++)
            {
                timeDomainSamples[i] = (short)(timeDomainSamples[i] * scale_factor);
            }
        }

        public Complex32[] GetFrequencyDomain(short[] input)
        {
            Complex32[] complexSamples = new Complex32[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                complexSamples[i] = new Complex32(input[i], 0.0f);
            }

            MathNet.Numerics.IntegralTransforms.Fourier.Forward(complexSamples, MathNet.Numerics.IntegralTransforms.FourierOptions.Default);

            return complexSamples;
        }

        private void ExecuteFilters()
        {
            ApplyAWeightedFilter();
            ApplyCWeightedFilter();

            for(int i = 0; i < OctaveBandCenterFrequencies.Length; i++)
            {
                ApplyOctaveBandFilter(i, false);
            }

            for(int i = 0; i < ThirdOctaveBandCenterFrequencies.Length; i++)
            {
                ApplyOctaveBandFilter(i, true);
            }
        }
    }
}
