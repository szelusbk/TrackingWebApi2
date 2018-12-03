using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.APIs;
using WebApiTest.Models;
using GeoCoordinatePortable;

namespace TrackingWebApi.GpsMethods
{
    public static class GpsTimeHelper
    {
        public static TimeSpan GetElapsedTime(List<Locations> locations)
        {
            DateTime startDate = GetStartDate(locations);
            DateTime endDate = GetEndDate(locations);
            TimeSpan elapsedTime = endDate - startDate;

            return elapsedTime;
        }

        private static DateTime GetStartDate(List<Locations> locations)
        {
            locations = locations.OrderBy(x => x.Date).ToList();
            DateTime startDate = GetFirstDate(locations);
            return startDate;
        }

        private static DateTime GetEndDate(List<Locations> locations)
        {
            locations = locations.OrderByDescending(x => x.Date).ToList();
            DateTime endDate = GetFirstDate(locations);
            return endDate;
        }

        private static DateTime GetFirstDate(List<Locations> locations)
        {
            DateTime date = new DateTime();
            Locations previousLocation = new Locations();
            double minimumDistance = 80;

            foreach (var loc in locations)
            {
                if (previousLocation.Date != null)
                {
                    GeoCoordinate prevCoord = new GeoCoordinate((double)previousLocation.Latitude, (double)previousLocation.Longitude);
                    GeoCoordinate Coord = new GeoCoordinate((double)loc.Latitude, (double)loc.Longitude);

                    double distance = Coord.GetDistanceTo(prevCoord); //distance im meters

                    if (distance > minimumDistance)
                    {
                        date = (DateTime)previousLocation.Date;
                        break;
                    }
                }
                previousLocation = loc;
            }
            return date;
        }
    }
}
