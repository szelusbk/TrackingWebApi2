using System;
using System.Collections.Generic;
using GeoCoordinatePortable;
using TrackingWebApi.Services.Interfaces;
using TrackingWebApi.Models;

namespace TrackingWebApi.Services
{
    public class GpsDistanceHelper : IGpsDistanceHelper
    {
        public double CalculateDistance(List<Locations> locations)
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
