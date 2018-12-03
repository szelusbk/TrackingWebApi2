using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using WebApiTest.Models;

namespace TrackingWebApi.GpsMethods
{
    public static class GpsDistanceHelper
    {
        public static double CalculateDistance(List<Locations> locations)
        {
            GeoCoordinate previousCoord = null;
            GeoCoordinate currentCoord = null;

            double distance = 0;

            foreach (var loc in locations)
            {
                currentCoord = new GeoCoordinate((double)loc.Latitude, (double)loc.Longitude);

                if (previousCoord != null)
                {
                    distance += previousCoord.GetDistanceTo(currentCoord);
                }

                previousCoord = currentCoord;
            }

            return Math.Round(distance/1000,2);
        }
    }
}
