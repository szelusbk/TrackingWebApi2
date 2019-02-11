using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TrackingWebApi.Models;
using TrackingWebApi.Models.Db;
using TrackingWebApi.Services;
using TrackingWebApi.Tests.Stubs;

namespace TrackingWebApi.Tests
{
    [TestFixture]
    public class OrdersServiceTests
    {
        private OrdersService GetOrdersService()
        {
            IGpsContext context = new GpsContextStub().GetContext();
            OrdersService ordersService = new OrdersService(context);
            return ordersService;
        }

        private List<Orders> GetExpectedOrdersList()
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

        [Test]
        public void GetOrdersList_CallMethod_GetCorrectListOfOrders()
        {
            //Arrange
            OrdersService ordersService = GetOrdersService();
            List<Orders> expectedOrdersList = GetExpectedOrdersList();

            //Act
            List<Orders> ordersList = ordersService.GetOrdersList();

            //Asset
            Assert.AreEqual(expectedOrdersList, ordersList);
        }
    }
}
