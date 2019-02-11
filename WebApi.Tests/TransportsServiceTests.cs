using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TrackingWebApi.Models;
using TrackingWebApi.Services;
using TrackingWebApi.Tests.Stubs;

namespace TrackingWebApi.Tests
{
    [TestFixture]
    public class TransportsServiceTests
    {
        private TransportsService GetTransportService()
        {
            IGpsContext context = new GpsContextStub().GetContext();
            TransportsService transportsService = new TransportsService(context);
            return transportsService;
        }

        private TransportsInfo GetExpectedTransportsInfo()
        {
            Trackers tracker = TrackersListStub.GetTracker();
            TransportsInfo expectedTransportsInfo = new TransportsInfo()
            {
                ProjectNo = "1812",
                Address = "Address",
                AddressLatitude = "1",
                AddressLongitude = "2",
                OrderNo = 1,
                CustomerName = "Customer",
                DateFrom = new DateTime(2018, 12, 10, 12, 10, 0),
                DateTo = new DateTime(2018, 12, 15, 12, 10, 0),
                VehicleType = "vehicle",
                Imei = tracker.Imei,
                TrackerName = tracker.Name
            };

            return expectedTransportsInfo;
        }

        private List<TransportsInfo> GetExpectedTransportsInfoList()
        {
            Trackers tracker = TrackersListStub.GetTracker();
            List<TransportsInfo> expectedTransportsInfoList = new List<TransportsInfo>()
            {
                GetExpectedTransportsInfo(),
                new TransportsInfo()
                {
                    ProjectNo = "2222",
                    Address = "Address2",
                    AddressLatitude = "11",
                    AddressLongitude = "22",
                    OrderNo = 2,
                    CustomerName = "CustomerXX",
                    DateFrom = new DateTime(2018, 5, 1, 9, 10, 0),
                    DateTo = new DateTime(2018, 5, 10, 9, 10, 0),
                    VehicleType = "vehicle2",
                    Imei = tracker.Imei,
                    TrackerName = tracker.Name
                }
            };

            return expectedTransportsInfoList;
        }

        [Test]
        public void GetTransportInfo_PassTransportObject_GetCorrectTransportInfoObject()
        {
            //Arrange
            Transports transport = TransportListStub.GetTransport();
            TransportsService transportsService = GetTransportService();
            TransportsInfo expectedTransportsInfo = GetExpectedTransportsInfo();

            //Act
            TransportsInfo transportInfo = transportsService.GetTransportInfo(transport);

            //Assert
            Assert.AreEqual(expectedTransportsInfo, transportInfo);
        }

        [Test]
        public void GetTransportsInfoList_PassListOfTransports_GetCorrectListOfTransportInfo()
        {
            //Arrange
            List<Transports> transports = TransportListStub.GetTransportList();
            TransportsService transportsService = GetTransportService();
            List<TransportsInfo> expectedTransportsInfoList = GetExpectedTransportsInfoList();

            //Act
            List<TransportsInfo> transportInfoList = transportsService.GetTransportsInfoList(transports);

            //Assert
            for (int i = 0; i < expectedTransportsInfoList.Count; i++)
            {
                Assert.AreEqual(expectedTransportsInfoList[i], transportInfoList[i]);
            }
        }

        [Test]
        public void GetTransportsInfoList_CallMethod_GetMax1000ListOfTransportInfo()
        {
            //Arrange
            TransportsService transportsService = GetTransportService();
            List<TransportsInfo> expectedTransportsInfoList = GetExpectedTransportsInfoList().OrderByDescending(x => x.DateFrom).ToList();

            //Act
            List<TransportsInfo> transportInfoList = transportsService.GetTransportsInfoList();

            //Assert
            for (int i = 0; i < expectedTransportsInfoList.Count; i++)
            {
                Assert.AreEqual(expectedTransportsInfoList[i], transportInfoList[i]);
            }
            Assert.That(transportInfoList.Count <= 1000);
        }

        [Test]
        public void GetTransportInfo_PassOrderNumber_GetCorrectTransportInfo()
        {
            //Arrange
            Transports transport = TransportListStub.GetTransport();
            TransportsService transportsService = GetTransportService();
            TransportsInfo expectedTransportsInfo = GetExpectedTransportsInfo();

            //Act
            TransportsInfo transportInfo = transportsService.GetTransportInfo(1);

            //Assert
            Assert.AreEqual(expectedTransportsInfo, transportInfo);
        }
    }
}
