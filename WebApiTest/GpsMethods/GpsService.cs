using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.APIs;
using WebApiTest.Models;

namespace WebApiTest.GpsMethods
{
    public static class GpsService
    {
        public static async Task<RouteInfo> GetRouteInfo(List<Locations> locations, Trackers Tracker)
        {
            RouteInfo routeInfo = new RouteInfo();

            if (locations.Count > 0)
            {
                Locations lastLocation = locations.OrderBy(x => x.date).Last();
                Locations firstLocation = locations.OrderBy(x => x.date).First();
                routeInfo.Imei = lastLocation.imei;
                routeInfo.GpsName = Tracker.name;
                routeInfo.GpsStatus = Tracker.status;
                routeInfo.Battery = Tracker.battery ?? "No available info";
                routeInfo.LastDate = lastLocation.date.Value.ToString();
                routeInfo.LastLatitude = lastLocation.latitude.ToString().Replace(",", ".");
                routeInfo.LastLongitude = lastLocation.longitude.ToString().Replace(",", ".");

                TimeSpan diff = lastLocation.date.Value - firstLocation.date.Value;
                routeInfo.ElapsedTime = diff.Days.ToString() + " days, " + diff.Hours + " hours, " + diff.Minutes + " minutes";

                DistanceMatrix distanceMatrix = new DistanceMatrix(firstLocation.latitude.ToString().Replace(",", ".") + "," + firstLocation.longitude.ToString().Replace(",", "."), routeInfo.LastLatitude + "," + routeInfo.LastLongitude);
                routeInfo.Distance = await distanceMatrix.CalculateDistanceAsync();

                foreach (var loc in locations)
                {
                    LatLng latLng = new LatLng { Latitude = loc.latitude.ToString().Replace(",", "."), Longitude = loc.longitude.ToString().Replace(",", ".") };
                    routeInfo.LatLngList.Add(latLng);
                }
            }

            return routeInfo;
        }

        public static async Task<List<RouteInfo>> GetRouteInfoList(DateTime dateFrom, DateTime dateTo)
        {
            List<RouteInfo> routeInfoList = new List<RouteInfo>();

            using(var context = new GPSContext())
            {
                foreach(var tracker in context.Trackers)
                {
                    List<Locations> locations = new List<Locations>();
                    var loc = context.Locations.Where(x => x.date >= dateFrom && x.latitude != null && x.longitude != null && x.imei == tracker.imei).OrderByDescending(x => x.date);

                    if (dateFrom != dateTo)
                        loc = loc.Where(x => x.date <= dateTo).OrderByDescending(x => x.date);

                        if (dateFrom.Hour == 0 && dateFrom.Minute == 0 && dateTo.Hour == 0 && dateTo.Minute == 0)
                            locations = loc.ToList<Locations>();
                        else
                            locations = loc.Where(x => x.date <= dateTo && x.date >= dateFrom).OrderByDescending(x => x.date).ToList<Locations>();

                        if (locations.Count > 0)
                        {
                            RouteInfo routeInfo = await GpsService.GetRouteInfo(locations, tracker);
                            routeInfoList.Add(routeInfo);
                        }
                }
            }
            return routeInfoList;
        }
    }
}
