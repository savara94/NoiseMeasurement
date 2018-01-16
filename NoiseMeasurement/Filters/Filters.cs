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
        public double[] frequencyDomain;
        public short[] AWeightedOutput;
        public short[] CWeightedOutput;
        public short[] AWeightedFreq;
        public short[] CWeightedFreq;

        public static short[] ApplyAWeightedFilter(short[] input)
        {
            return null;
        }

        public static short[] ApplyCWeightedFilter(short[] input)
        {
            return null;
        }

        private static int Find2NGreaterThan(int n)
        {
            int x = 1;
            while(x < n)
            {
                x *= 2;
            }

            return x;
        }

        public static double[] GetFrequencyDomain(short[] input)
        {
            Complex32[] complexSamples = new Complex32[input.Length];
            double[] tmp = new double[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                complexSamples[i] = new Complex32(input[i], 0.0f);
            }

            MathNet.Numerics.IntegralTransforms.Fourier.Forward(complexSamples);
            for(int i = 0; i < complexSamples.Length; i++)
            {
                var sample = complexSamples[i];
                tmp[i] = sample.Magnitude;
            }

            return tmp;
        }

        public Filters(short[] input)
        {
            this.input = input;
            this.frequencyDomain = GetFrequencyDomain(input);
        }
    }
}
