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
        public short[] AWeightedOutput;
        public short[] CWeightedOutput;
        public short[][] OctaveBandOutput;
        public short[][] ThirdOctaveBandOutput;

        public Complex32[] frequencyDomain;
        public Complex32[][] OctaveBandFreqs;
        public Complex32[][] ThirdOctaveBandFreqs;
        public Complex32[] AWeightedFreq;
        public Complex32[] CWeightedFreq;

        private delegate float filter(float freq);

        private void GenerateFilterOutputs(Complex32[] frequencies, short[] timeDomainSamples, filter filter)
        {
            for (int i = 1; i < AWeightedFreq.Length; i++)
            {
                float scale = filter(i);
                frequencies[i] = new Complex32(scale* frequencyDomain[i].Real, scale * frequencyDomain[i].Imaginary);
            }

            Complex32[] inverseinput = new Complex32[frequencies.Length];
            for (int i = 0; i < inverseinput.Length; i++)
            {
                inverseinput[i] = new Complex32(frequencies[i].Real, frequencies[i].Imaginary);
            }

            MathNet.Numerics.IntegralTransforms.Fourier.Inverse(inverseinput, MathNet.Numerics.IntegralTransforms.FourierOptions.Default);
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

        public Filters(short[] input)
        {
            this.input = input;
            ThirdOctaveBandFreqs = new Complex32[ThirdOctaveBandCenterFrequencies.Length][];
            ThirdOctaveBandOutput = new short[ThirdOctaveBandCenterFrequencies.Length][];

            OctaveBandFreqs = new Complex32[ThirdOctaveBandCenterFrequencies.Length][];
            OctaveBandOutput = new short[ThirdOctaveBandCenterFrequencies.Length][];

            frequencyDomain = GetFrequencyDomain(input);
            ExecuteFilters();
        }
    }
}
