using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseMeasurement.DB.Context
{
    class NoiseMeterContext : DbContext
    {
        public NoiseMeterContext() : base("MyConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<NoiseMeterContext>());
        }

        public DbSet<DeviceReadings> DeviceReadings { get; set; }
        public DbSet<GeoLocation> GeoLocations { get; set; }
    }
}
