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

        public DBUpdater(PointLatLng location)
        {
            double lat = location.Lat;
            double lng = location.Lng;
            string wkt = $"POINT({lat} {lng})";
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

        public void InsertReading(double decibels)
        {
            NoiseMeterContext context;
            GeoLocation location = FindLocation(thisDeviceLocation, out context);
            DeviceReadings readings = new DeviceReadings()
            {
                GeoLocationID = location.GeoLocationID,
                Noise = decibels,
                Timestamp = DateTime.Now
            };

            location.DeviceReadings.Add(readings);

            var entity = context.GeoLocations.Find(location.GeoLocationID);
            context.Entry(entity).CurrentValues.SetValues(location);
            context.DeviceReadings.Add(readings);
            context.SaveChanges();
            context.Dispose();
        }

        private GeoLocation FindLocation(PointLatLng deviceLocation, out NoiseMeterContext context)
        {
            List<GeoLocation> list;
            context = new NoiseMeterContext();
            list = context.GeoLocations.ToList();
            double lat = deviceLocation.Lat;
            double lng = deviceLocation.Lng;
            string wkt = $"POINT({lat} {lng})";

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
            NoiseMeterContext context;
            var geolocation = FindLocation(deviceLocation, out context);

            List<double> readings = (from value in geolocation.DeviceReadings
                                     where value.Timestamp > filter
                                     select value.Noise).ToList();

            context.Dispose();

            return readings;
        }

        private void MakeNewDeviceLocation(DbGeography gpsLocation)
        {
            var currentGeoLocation = new GeoLocation()
            {
                Location = gpsLocation,
            };

            using (var context = new NoiseMeterContext())
            {
                context.GeoLocations.Add(currentGeoLocation);
                context.SaveChanges();
            }
        }
    }
}
