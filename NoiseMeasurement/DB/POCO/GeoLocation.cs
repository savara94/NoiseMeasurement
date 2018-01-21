using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseMeasurement.DB
{
    public class GeoLocation
    {
        public int GeoLocationID { get; set; }
        public DbGeography Location {get; set;}
        public virtual ICollection<DeviceReadings> DeviceReadings { get; set; }
    }
}
