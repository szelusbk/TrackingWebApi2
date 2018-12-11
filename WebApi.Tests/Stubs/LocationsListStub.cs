using System;
using System.Collections.Generic;
using TrackingWebApi.Models;

namespace TrackingWebApi.Tests.Stubs
{
    public static class LocationsListStub
    {
        public static List<Locations> GetLocationsList()
        {
            List<Locations> locations = new List<Locations>();

            locations.Add(new Locations()
            {
                Imei = "1",
                Latitude = 52.2533505555556,
                Longitude = 21.0019877777778,
                Date = new DateTime(2018, 10, 11, 17, 9, 32)
            });

            locations.Add(new Locations()
            {
                Imei = "1",
                Latitude = 52.2579916666667,
                Longitude = 20.9959244444444,
                Date = new DateTime(2018, 10, 11, 17, 17, 12)
            });

            locations.Add(new Locations()
            {
                Imei = "1",
                Latitude = 52.2689733333333,
                Longitude = 20.9857422222222,
                Date = new DateTime(2018, 10, 11, 17, 23, 11),
                Battery = "50%"
            });

            locations.Add(new Locations()
            {
                Imei = "2",
                Latitude = 52.2689733333333,
                Longitude = 20.9857422222222,
                Date = new DateTime(2018, 10, 11, 17, 23, 11),
                Battery = "20%"
            });

            return locations;
        }
    }
}
