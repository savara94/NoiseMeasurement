using NoiseMeasurement.Calibration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoiseMeasurement.Averaging
{
    public class TimeAveraging
    {
        private DateTime timestamp;
        private Label labelLavg;
        private Label labelTwa;
        private Label labelDose;
        private double Dose;

        private double[] timeWeightings =
        {
            1, 0.125f, 0.035f
        };

        private double[] currentValues =
        {
            0, 0, 0
        };

        private double[] previousValues =
        {
            0, 0, 0
        };

        public TimeAveraging(Label lavg, Label twa, Label dose)
        {
            timestamp = DateTime.Now;
            labelLavg = lavg;
            labelTwa = twa;
            labelDose = dose;
        }

        public CalibrationParams CalibrationParams { get; private set; }

        public int TimeWeightIndex { get; set;}

        public void GatherNewData(short[] buffer)
        {
            double alfa = 0;

            foreach(var sample in buffer)
            {
                for(int i = 0; i < currentValues.Length; i++)
                {
                    alfa = GetAlfa(timeWeightings[i]);
                    currentValues[i] = (1 - alfa) * Math.Abs(sample) + alfa * previousValues[i];
                    previousValues[i] = currentValues[i];
                }
            }

            DateTime currentTime = DateTime.Now;
            CalibrationParams = new CalibrationParams
            {
                Sample = (short)Properties.Settings.Default["calibration_sample"],
                Noise = (double)Properties.Settings.Default["calibration_noise"]
            };
            double calibrated_sample = CalibrationParams.Sample;
            double calibrated_noise = CalibrationParams.Noise;

            double lavg = calibrated_noise + 10.0 * Math.Log10((double)currentValues[TimeWeightIndex] / calibrated_sample);
            double Tn = 8.0 / Math.Pow(2, (lavg - 90) / 5.0);
            var time_diff = currentTime - timestamp;
            Dose += 100 * time_diff.TotalSeconds / Tn;
            timestamp = currentTime;
            double TWA = 16.61 * Math.Log10(Dose / 100) + 90;

            UpdateLabel(labelDose, Math.Round(Dose, 5) + " %");
            UpdateLabel(labelLavg, Math.Round(lavg, 5) + " dB");
            UpdateLabel(labelTwa, Math.Round(TWA, 5) + " dB/day");
        }

        private double GetAlfa(double timeWeight)
        {
            double fs = 44100;
            return Math.Exp(-1.0 / (fs * timeWeight));
        }

        private void UpdateLabel(Label label, string text)
        {
            label.Invoke((MethodInvoker)delegate
           {
               label.Text = text;
           });
        }
    }
}
