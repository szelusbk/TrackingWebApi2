using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingWebApi.APIs;
using TrackingWebApi.Models;
using TrackingWebApi.Services.Interfaces;

namespace TrackingWebApi.Services
{
    public class GpsService : IGpsService
    {
        private readonly IGpsDistanceHelper gpsDistanceHelper;
        private readonly IGpsTimeHelper gpsTimeHelper;
        private readonly IDistanceMatrix distanceMatrix;
        private readonly IGpsContext context;

        public GpsService(IGpsDistanceHelper gpsDistanceHelper, IGpsTimeHelper gpsTimeHelper, IDistanceMatrix distanceMatrix, IGpsContext context)
        {
            this.gpsDistanceHelper = gpsDistanceHelper;
            this.gpsTimeHelper = gpsTimeHelper;
            this.distanceMatrix = distanceMatrix;
            this.context = context;
        }

        public async Task<RouteInfo> GetRouteInfo(List<Locations> locations, Trackers Tracker)
        {
            RouteInfo routeInfo = new RouteInfo();

            if (locations.Count > 0)
            {
                Locations lastLocation = locations.OrderBy(x => x.Date).Last();
                Locations firstLocation = locations.OrderBy(x => x.Date).First();
                routeInfo.Imei = Tracker.Imei;
                routeInfo.GpsName = Tracker.Name;
                routeInfo.GpsStatus = Tracker.Status;
                routeInfo.Battery = lastLocation.Battery ?? "No available info";
                routeInfo.LastDate = lastLocation.Date.Value.ToString();
                routeInfo.LastLatitude = lastLocation.Latitude.ToString().Replace(",", ".");
                routeInfo.LastLongitude = lastLocation.Longitude.ToString().Replace(",", ".");

                TimeSpan diff = gpsTimeHelper.GetElapsedTime(locations);
                routeInfo.ElapsedTime = diff.Days.ToString() + " days, " + diff.Hours + " hours, " + diff.Minutes + " minutes";

                routeInfo.GoogleDistance = await distanceMatrix.CalculateDistanceAsync(firstLocation.Latitude.ToString().Replace(",", ".") + "," + firstLocation.Longitude.ToString().Replace(",", "."), routeInfo.LastLatitude + "," + routeInfo.LastLongitude);
                routeInfo.Distance = gpsDistanceHelper.CalculateDistance(locations).ToString();

                foreach (var loc in locations)
                {
                    LatLng latLng = new LatLng { Latitude = loc.Latitude.ToString().Replace(",", "."), Longitude = loc.Longitude.ToString().Replace(",", ".") };
                    routeInfo.LatLngList.Add(latLng);
                }
            }

            return routeInfo;
        }

        public async Task<RouteInfo> GetRouteInfo(DateTime dateFrom, DateTime dateTo, string imei)
        {
            List<Locations> chosenLocations = new List<Locations>();
            Trackers tracker = new Trackers();

            tracker = context.Trackers.Where(x => x.Imei == imei).FirstOrDefault();
            var locations = context.Locations.Where(x => x.Date >= dateFrom && x.Date <= dateTo && x.Latitude != null && x.Longitude != null && x.Imei == imei).OrderByDescending(x => x.Date).ToList<Locations>();

            if (dateFrom.Hour == 0 && dateFrom.Minute == 0 && dateTo.Hour == 0 && dateTo.Minute == 0)
                chosenLocations = locations;
            else
                chosenLocations = locations.Where(x => x.Date <= dateTo && x.Date >= dateFrom).OrderByDescending(x => x.Date).ToList<Locations>();

            RouteInfo routeInfo = await GetRouteInfo(chosenLocations, tracker);
            return routeInfo;
        }

        public async Task<List<RouteInfo>> GetRouteInfoList(DateTime dateFrom, DateTime dateTo)
        {
            List<RouteInfo> routeInfoList = new List<RouteInfo>();

            foreach (var tracker in context.Trackers.OrderBy(x => x.Name))
            {
                List<Locations> locations = new List<Locations>();
                var loc = context.Locations.Where(x => x.Date >= dateFrom && x.Latitude != null && x.Longitude != null && x.Imei == tracker.Imei).OrderByDescending(x => x.Date);

                if (dateFrom != dateTo)
                    loc = loc.Where(x => x.Date <= dateTo).OrderByDescending(x => x.Date);

                if (dateFrom.Hour == 0 && dateFrom.Minute == 0 && dateTo.Hour == 0 && dateTo.Minute == 0)
                    locations = loc.ToList();
                else
                    locations = loc.Where(x => x.Date <= dateTo && x.Date >= dateFrom).OrderByDescending(x => x.Date).ToList();

                if (locations.Count > 0)
                {
                    RouteInfo routeInfo = await GetRouteInfo(locations, tracker);
                    routeInfoList.Add(routeInfo);
                }
            }

            return routeInfoList;
        }
    }
}
