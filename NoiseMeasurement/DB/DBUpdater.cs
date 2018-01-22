using GMap.NET;
using NoiseMeasurement.DB.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoiseMeasurement.DB
{
    public class DBUpdater
    {
        private PointLatLng thisDeviceLocation;
        private PointLatLng monitoredDeviceLocation;
        private GeoLocation thisGeolocation;
        private GeoLocation monitoredGeolocation;

        public DBUpdater(PointLatLng location)
        {
            double lat = location.Lat;
            double lng = location.Lng;
            string wkt = $"POINT({lng} {lat})";
            DbGeography gpslocation = DbGeography.FromText(wkt);
            List<GeoLocation> geoLocationSuggestions;
            thisDeviceLocation = location;
            using (var noiseMeterContext = new NoiseMeterContext())
            {
                geoLocationSuggestions = (from geo in noiseMeterContext.GeoLocations.ToList()
                                          where geo.Location.Distance(gpslocation) < 100
                                          orderby geo.Location.Distance(gpslocation)
                                          select geo).ToList();
            }

            if (geoLocationSuggestions.Count == 0)
            {
                // New needs to be inserted
                MakeNewDeviceLocation(gpslocation);
            }
            else
            {
                thisGeolocation = geoLocationSuggestions[0];
            }
        }

        public List<PointLatLng> GetDeviceLocations()
        {
            List<PointLatLng> points = new List<PointLatLng>();
            List<GeoLocation> list;
            using (var context = new NoiseMeterContext())
            {
                list = context.GeoLocations.ToList();
            }

            foreach (var location in list)
            {
                var pt = new PointLatLng((double)location.Location.Latitude, (double)location.Location.Longitude);
                points.Add(pt);
            }

            return points;
        }

        public async void InsertReading(double decibels)
        {
            DeviceReadings readings = new DeviceReadings()
            {
                GeoLocationID = thisGeolocation.GeoLocationID,
                Noise = decibels,
                Timestamp = DateTime.Now
            };

            using (var context = new NoiseMeterContext())
            {
                context.DeviceReadings.Add(readings);
                await context.SaveChangesAsync();
            }
        }

        private GeoLocation FindLocation(PointLatLng deviceLocation)
        {
            List<GeoLocation> list;
            using (var context = new NoiseMeterContext())
            {
                list = context.GeoLocations.ToList();
            }

            double lat = deviceLocation.Lat;
            double lng = deviceLocation.Lng;
            string wkt = $"POINT({lng} {lat})";

            DbGeography selectedLocation = DbGeography.FromText(wkt);
            List<GeoLocation> wantedLocation = (from location in list
                                                where location.Location.SpatialEquals(selectedLocation)
                                                select location).ToList();
            if (wantedLocation.Count > 1)
            {
                //throw new Exception("This should not happen!");
                Console.WriteLine(wantedLocation.Count);
            }

            if (wantedLocation.Count == 0)
            {
                return null;
            }

            return wantedLocation[0];
        }

        public List<double> GetNewReadings(PointLatLng deviceLocation, DateTime filter)
        {
            try
            {
                if (!deviceLocation.Equals(monitoredDeviceLocation))
                {
                    monitoredDeviceLocation = deviceLocation;
                    monitoredGeolocation = FindLocation(monitoredDeviceLocation);
                }
                List<double> readings;
                using (var context = new NoiseMeterContext())
                {
                    readings = (from reading in context.DeviceReadings
                                where reading.GeoLocationID == monitoredGeolocation.GeoLocationID && reading.Timestamp > filter
                                select reading.Noise).ToList();
                }

                return readings;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private void MakeNewDeviceLocation(DbGeography gpsLocation)
        {
            thisGeolocation = new GeoLocation()
            {
                Location = gpsLocation,
            };

            using (var context = new NoiseMeterContext())
            {
                context.GeoLocations.Add(thisGeolocation);
                context.SaveChanges();
            }
        }
    }
}
