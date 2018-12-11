using System;
using System.Collections.Generic;
using System.Linq;
using TrackingWebApi.Models;
using GeoCoordinatePortable;
using TrackingWebApi.Services.Interfaces;

namespace TrackingWebApi.Services
{
    public class GpsTimeHelper: IGpsTimeHelper
    {
        public TimeSpan GetElapsedTime(List<Locations> locations)
        {
            DateTime startDate = GetStartDate(locations);
            DateTime endDate = GetEndDate(locations);
            TimeSpan elapsedTime = endDate - startDate;

            return elapsedTime;
        }

        private DateTime GetStartDate(List<Locations> locations)
        {
            locations = locations.OrderBy(x => x.Date).ToList();
            DateTime startDate = GetFirstDate(locations);
            return startDate;
        }

        private DateTime GetEndDate(List<Locations> locations)
        {
            locations = locations.OrderByDescending(x => x.Date).ToList();
            DateTime endDate = GetFirstDate(locations);
            return endDate;
        }

        private DateTime GetFirstDate(List<Locations> locations)
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
