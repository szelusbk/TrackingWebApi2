using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TrackingWebApi.Models;

namespace TrackingWebApi.Tests.Stubs
{
    public class GpsContextStub
    {
        private static GpsContext context;

        public GpsContext GetContext(bool newInstance = false)
        {
            if(context == null || newInstance == true)
            {
                var options = new DbContextOptionsBuilder<GpsContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

                GpsContext gpsContext = new GpsContext(options);
                gpsContext.Database.EnsureDeleted(); //Make sure that data will be deleted

                List<Locations> locations = LocationsListStub.GetLocationsList();
                gpsContext.Locations.AddRange(locations);

                List<Trackers> trackers = TrackersListStub.GetTrackersList();
                gpsContext.Trackers.AddRange(trackers);

                List<Transports> transports = TransportListStub.GetTransportList();
                gpsContext.Transports.AddRange(transports);

                Users user = UserStub.GetUser();
                gpsContext.Users.Add(user);

                gpsContext.SaveChanges();
                context = gpsContext;
            }

            return context;
        }
    }
}
