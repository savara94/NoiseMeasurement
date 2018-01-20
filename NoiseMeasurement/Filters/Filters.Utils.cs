using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseMeasurement.Filters
{
    public struct Point2D
    {
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }
    };

    public partial class Filters
    {
        public static void GetParabolaEquation(Point2D ordinary, Point2D max, out double A, out double h, out double k)
        {
            double x1 = ordinary.X;
            double x2 = max.X;

            double y1 = ordinary.Y;
            double y2 = max.Y;

            k = y2;
            h = x2;
            var denominator = x1 - h;
            A = (y1 - k) / (denominator * denominator);
        }

        public static double ParabolaValue(double A, double h, double k, double x)
        {
            var pwr = (x - h);
            return A * pwr * pwr + k;
        }
    }
}
