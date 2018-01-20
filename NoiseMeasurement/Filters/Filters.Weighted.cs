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
        private void ApplyAWeightedFilter()
        {
            AWeightedFreq = new Complex32[frequencyDomain.Length];
            AWeightedOutput = new short[frequencyDomain.Length];
            GenerateFilterOutputs(AWeightedFreq, AWeightedOutput, AWeight);
        }

        private float AWeight(float freq)
        {
            if (freq <= 16000)
            {
                return (12194 * 12194 * freq * freq * freq * freq) /
                (
                    (freq * freq + 20.6f * 20.6f) *
                    (float)Math.Sqrt((freq * freq + 107.2 * 107.2) * (freq * freq + 737.9 * 737.9)) *
                    (freq * freq + 12194 * 12194)
                );
            }

            return 0;
        }

        private float CWeight(float freq)
        {
            if (freq < 10)
            {
                return 0;
            }

            if (freq < 100)
            {
                double A, h, k;
                Point2D ordPoint, maxPoint;

                ordPoint = new Point2D(10, 0.17); // -15db
                maxPoint = new Point2D(100, 1); // 0db

                GetParabolaEquation(ordPoint, maxPoint, out A, out h, out k);

                return (float)ParabolaValue(A, h, k, freq);
            }

            if (freq <= 8000)
            {
                return 1;
            }

            if (freq < 16000)
            {
                double A, h, k;
                Point2D ordPoint, maxPoint;

                maxPoint = new Point2D(8000, 1); // 0db
                ordPoint = new Point2D(16000, 0.31); // -10db

                GetParabolaEquation(ordPoint, maxPoint, out A, out h, out k);
                return (float)ParabolaValue(A, h, k, freq);
            }

            return 0;
        }

        public void ApplyCWeightedFilter()
        {
            CWeightedFreq = new Complex32[frequencyDomain.Length];
            CWeightedOutput = new short[frequencyDomain.Length];
            GenerateFilterOutputs(CWeightedFreq, CWeightedOutput, CWeight);
        }
    }
}
