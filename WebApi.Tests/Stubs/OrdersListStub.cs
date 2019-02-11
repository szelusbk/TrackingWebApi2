using System;
using System.Collections.Generic;
using TrackingWebApi.Models.Db;

namespace TrackingWebApi.Tests.Stubs
{
    public static class OrdersListStub
    {
        public static List<Orders> GetOrdersList()
        {
            List<Orders> orders = new List<Orders>()
            {
                new Orders()
                {
                    Id = 1,
                    Address = "address1",
                    CustomerName = "customer1",
                    ProjectNo = "1S",
                    Status = "Planned",
                    Distance = "100",
                    DateFrom = new DateTime(2019,1,1),
                    DateTo = new DateTime(2019,1,2),
                    Leader = "rc",
                    VehicleType = "truck"
                },
                new Orders()
                {
                    Id = 2,
                    Address = "address2",
                    CustomerName = "customer2",
                    ProjectNo = "2S",
                    Status = "Delivered",
                    Distance = "200",
                    DateFrom = new DateTime(2019,2,1),
                    DateTo = new DateTime(2019,2,2),
                    Leader = "mba",
                    VehicleType = "truck"
                }
            };

            return orders;
        }
    }
}
