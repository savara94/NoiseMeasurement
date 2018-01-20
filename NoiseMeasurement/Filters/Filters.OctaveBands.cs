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
        public static readonly float[] OctaveBandCenterFrequencies = 
        {
            31, 63, 125, 250, 500, 1000, 2000, 4000, 8000, 16000
        };
        public static readonly float[] ThirdOctaveBandCenterFrequencies =
        {
            16, 20, 25, 31.5f, 40, 50, 63, 80, 100, 125, 160, 200,
            250, 315, 400, 500, 630, 800, 1000, 1250, 1600, 2000,
            2500, 3150, 4000, 5000, 6300, 8000, 10000, 12500, 16000, 20000
        };

        private int currentFrequencyIndex;

        private void GetUpperAndLowerFreqs(double centralFreq, bool thirdOctave, out double upper, out double lower)
        {
            if (!thirdOctave)
            {
                double fd = Math.Sqrt(2);
                lower = centralFreq / fd;
                upper = centralFreq * fd;
            }
            else
            {
                double fd = Math.Pow(2, 1.0 / 6);
                lower = centralFreq / fd;
                upper = centralFreq * fd;
            }
        }

        private void ApplyOctaveBandFilter(int band, bool thirdOctave)
        {
            float[] centerFrequencyPool = thirdOctave ? ThirdOctaveBandCenterFrequencies : OctaveBandCenterFrequencies;
            Complex32[][] freqsArray = thirdOctave ? ThirdOctaveBandFreqs : OctaveBandFreqs;
            short[][] samplesArray = thirdOctave ? ThirdOctaveBandOutput : OctaveBandOutput;
            filter filter = thirdOctave ? new filter(ThirdOctaveBandScalerFilter) :  new filter(OctaveBandScalerFilter);

            freqsArray[band] = new Complex32[frequencyDomain.Length];
            samplesArray[band] = new short[input.Length];
            currentFrequencyIndex = band;

            GenerateFilterOutputs(freqsArray[band], samplesArray[band], filter);
        }

        private float OctaveBandScaler(float freq, double upper, double lower)
        {
            double tenpctlower = 9.0 / 10 * lower;
            double tenpctupper = 11.0 / 10 * upper;

            if (freq < tenpctlower)
            {
                return 0;
            }

            if (freq < lower)
            {
                double A, h, k;
                Point2D ordPoint, maxPoint;
                ordPoint = new Point2D(tenpctlower, 0.00003162277); // -90dB
                maxPoint = new Point2D(lower, 1); // 0dB

                GetParabolaEquation(ordPoint, maxPoint, out A, out h, out k);
                return (float)ParabolaValue(A, h, k, freq);
            }

            if (freq <= upper)
            {
                return 1;
            }

            if (freq < tenpctupper)
            {
                double A, h, k;
                Point2D ordPoint, maxPoint;
                ordPoint = new Point2D(tenpctupper, 0.00003162277); // -90dB
                maxPoint = new Point2D(upper, 1); // 0dB

                GetParabolaEquation(ordPoint, maxPoint, out A, out h, out k);
                return (float)ParabolaValue(A, h, k, freq);
            }

            return 0;
        }

        private float OctaveBandScalerFilter(float freq)
        {
            double lower;
            double upper;

            GetUpperAndLowerFreqs(OctaveBandCenterFrequencies[currentFrequencyIndex], false, out upper, out lower);

            return OctaveBandScaler(freq, upper, lower);
        }

        private float ThirdOctaveBandScalerFilter(float freq)
        {
            double lower;
            double upper;
            
            GetUpperAndLowerFreqs(ThirdOctaveBandCenterFrequencies[currentFrequencyIndex], true, out upper, out lower);

            return OctaveBandScaler(freq, upper, lower);
        }
    }
}
