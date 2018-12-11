using System.Collections.Generic;
using TrackingWebApi.Models;

namespace TrackingWebApi.Tests.Stubs
{
    public static class TrackersListStub
    {
        public static List<Trackers> GetTrackersList()
        {
            List<Trackers> trackers = new List<Trackers>()
            {
                new Trackers()
                {
                    Imei = "1",
                    Name = "Name",
                    Status = "123",
                    Battery = "50%"
                },
                new Trackers()
                {
                    Imei = "2",
                    Name = "Name2",
                    Status = "345",
                    Battery = "50%"
                },
            };

            return trackers;
        }

        public static Trackers GetTracker()
        {
            Trackers tracker = new Trackers()
            {
                Imei = "1",
                Name = "Name",
                Status = "123",
                Battery = "20%"
            };
            return tracker;
        }
    }
}
