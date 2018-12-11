using System;
using System.Collections.Generic;
using TrackingWebApi.Models;

namespace TrackingWebApi.Tests.Stubs
{
    public static class TransportListStub
    {
        public static List<Transports> GetTransportList()
        {
            List<Transports> transports = new List<Transports>()
            {
                new Transports()
                {
                    ProjectNo = "1812",
                    Address = "Address",
                    AddressLatitude = "1",
                    AddressLongitude = "2",
                    Id = 1,
                    CustomerName = "Customer",
                    DateFrom = new DateTime(2018, 12, 10, 12, 10, 0),
                    DateTo = new DateTime(2018, 12, 15, 12, 10, 0),
                    VehicleType = "vehicle",
                    Tracker = TrackersListStub.GetTracker()
                },
                new Transports()
                {
                    ProjectNo = "2222",
                    Address = "Address2",
                    AddressLatitude = "11",
                    AddressLongitude = "22",
                    Id = 2,
                    CustomerName = "CustomerXX",
                    DateFrom = new DateTime(2018, 5, 1, 9, 10, 0),
                    DateTo = new DateTime(2018, 5, 10, 9, 10, 0),
                    VehicleType = "vehicle2",
                    Tracker = TrackersListStub.GetTracker()
                },

            };

            return transports;
        }

        public static Transports GetTransport()
        {
            Transports transport = new Transports()
            {
                ProjectNo = "1812",
                Address = "Address",
                AddressLatitude = "1",
                AddressLongitude = "2",
                Id = 1,
                CustomerName = "Customer",
                DateFrom = new DateTime(2018, 12, 10, 12, 10, 0),
                DateTo = new DateTime(2018, 12, 15, 12, 10, 0),
                VehicleType = "vehicle",
                Tracker = TrackersListStub.GetTracker()
            };

            return transport;
        }
    }
}
