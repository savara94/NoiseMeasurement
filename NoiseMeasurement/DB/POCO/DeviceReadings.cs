using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseMeasurement.DB
{
    public class DeviceReadings
    {
        public int DeviceReadingsID { get; set; }
        public DateTime Timestamp { get; set; }
        public double Noise { get; set; }
        public int GeoLocationID { get; set; }
        public GeoLocation GeoLocation { get; set; }
    }
}
