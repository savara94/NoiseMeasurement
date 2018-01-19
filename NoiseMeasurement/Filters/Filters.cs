using AForge.Math;
using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseMeasurement.Filters
{
    public class Filters
    {
        public short[] input;
        public double[] normalized_input;
        public Complex32[] frequencyDomain;
        public short[] AWeightedOutput;
        public short[] CWeightedOutput;
        public Complex32[] AWeightedFreq;
        public Complex32[] CWeightedFreq;

        private delegate float Filter(float freq);

        private void GenerateFilterOutputs(Complex32[] frequencies, short[] timeDomainSamples, Filter filter)
        {
            for (int i = 1; i < AWeightedFreq.Length; i++)
            {
                float scale = filter(i);
                frequencies[i] = new Complex32(scale * frequencyDomain[i].Real, scale * frequencyDomain[i].Imaginary);
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

        private void ApplyAWeightedFilter()
        {
            AWeightedFreq = new Complex32[frequencyDomain.Length];
            AWeightedOutput = new short[frequencyDomain.Length];
            GenerateFilterOutputs(AWeightedFreq, AWeightedOutput, AWeight);
        }

        private float AWeight(float freq)
        {
            return (12194 * 12194 * freq * freq * freq * freq) /
                (
                    (freq * freq + 20.6f * 20.6f) * 
                    (float)Math.Sqrt((freq * freq + 107.2 * 107.2) * (freq * freq + 737.9 * 737.9)) * 
                    (freq * freq + 12194 * 12194)
                );
        }

        private float CWeight(float freq)
        {
            if (freq < 10)
            {
                return 0;
            }

            if (freq < 125.0)
            {
                return (-0.0001209f * freq * freq + 0.02417f * freq - 0.1332f);
            }

            if (freq <= 2000)
            {
                return 1;
            }
            
            if (freq < 22050 )
            {
                return (849.0f / 1447610000000 * freq * freq - 1404729.0f / 28952200000 * freq + 15846869.0f / 14476100);
            }

            return 0;
        }

        public void ApplyCWeightedFilter()
        {
            CWeightedFreq = new Complex32[frequencyDomain.Length];
            CWeightedOutput = new short[frequencyDomain.Length];
            GenerateFilterOutputs(CWeightedFreq, CWeightedOutput, CWeight);
        }

        public static Complex32[] GetFrequencyDomain(short[] input)
        {
            Complex32[] complexSamples = new Complex32[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                complexSamples[i] = new Complex32(input[i], 0.0f);
            }

            MathNet.Numerics.IntegralTransforms.Fourier.Forward(complexSamples, MathNet.Numerics.IntegralTransforms.FourierOptions.Default);

            return complexSamples;
        }

        public Filters(short[] input)
        {
            this.input = input;
            normalized_input = new double[input.Length];
            for(int i = 0; i < normalized_input.Length; i++)
            {
                normalized_input[i] = input[i] / short.MaxValue;
            }
            frequencyDomain = GetFrequencyDomain(input);

            ApplyAWeightedFilter();
            ApplyCWeightedFilter();
        }
    }
}
