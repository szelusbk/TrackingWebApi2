using System;
using System.Collections.Generic;
using NUnit.Framework;
using TrackingWebApi.Models;
using TrackingWebApi.Services;
using TrackingWebApi.Tests.Stubs;
using Moq;
using TrackingWebApi.APIs;
using System.Threading.Tasks;
using TrackingWebApi.Services.Interfaces;
using System.Linq;

namespace TrackingWebApi.Tests
{
    [TestFixture]
    public class GpsServiceTests
    {
        private GpsService GetGpsService()
        {
            Mock<IGpsDistanceHelper> gpsDistanceMock = new Mock<IGpsDistanceHelper>();
            gpsDistanceMock.Setup(x => x.CalculateDistance(It.IsAny<List<Locations>>())).Returns(200);

            Mock<IGpsTimeHelper> gpsTimeMock = new Mock<IGpsTimeHelper>();
            gpsTimeMock.Setup(x => x.GetElapsedTime(It.IsAny<List<Locations>>())).Returns(new TimeSpan(1,10,20));

            Mock<IDistanceMatrix> distanceMatrixMock = new Mock<IDistanceMatrix>();
            distanceMatrixMock.Setup(x => x.CalculateDistanceAsync(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult("210"));

            IGpsContext gpsContext = new GpsContextStub().GetContext();
            GpsService gpsService = new GpsService(gpsDistanceMock.Object, gpsTimeMock.Object, distanceMatrixMock.Object, gpsContext);
            return gpsService;
        }

        private RouteInfo GetExpectedRouteInfo()
        {
            RouteInfo expectedRouteInfo = new RouteInfo()
            {
                Imei = "1",
                GpsName = "Name",
                GpsStatus = "123",
                Battery = "50%",
                Distance = "200",
                GoogleDistance = "210",
                ElapsedTime = "0 days, 1 hours, 10 minutes",
                LastDate = new DateTime(2018, 10, 11, 17, 23, 11).ToString(),
                LastLatitude = "52.2689733333333",
                LastLongitude = "20.9857422222222",
                LatLngList = new List<LatLng>()
                {
                    new LatLng() { Latitude = "52.2533505555556", Longitude = "21.0019877777778" },
                    new LatLng() { Latitude = "52.2579916666667", Longitude = "20.9959244444444" },
                    new LatLng() { Latitude = "52.2689733333333", Longitude = "20.9857422222222" },
                }
            };
            return expectedRouteInfo;
        }

        private List<RouteInfo> GetExpectedRouteInfoList()
        {
            List<RouteInfo> expectedRouteInfoList = new List<RouteInfo>()
            {
                GetExpectedRouteInfo(),
                new RouteInfo()
                {
                    Imei = "2",
                    GpsName = "Name2",
                    GpsStatus = "345",
                    Battery = "20%",
                    Distance = "200",
                    GoogleDistance = "210",
                    ElapsedTime = "0 days, 1 hours, 10 minutes",
                    LastDate = new DateTime(2018, 10, 11, 17, 23, 11).ToString(),
                    LastLatitude = "52.2689733333333",
                    LastLongitude = "20.9857422222222",
                    LatLngList = new List<LatLng>()
                    {
                        new LatLng() { Latitude = "52.2689733333333", Longitude = "20.9857422222222" },
                    }
                },
            };

            return expectedRouteInfoList;
        }

        [Test]
        public async Task GetRouteInfo_PassGpsLocations_GetCorrectRouteInfoObject()
        {
            //Arrange
            Trackers tracker = TrackersListStub.GetTracker();
            List<Locations> locations = LocationsListStub.GetLocationsList().Where(x => x.Imei == tracker.Imei).ToList();
            GpsService gpsService = GetGpsService();
            RouteInfo expectedRouteInfo = GetExpectedRouteInfo();

            //Act
            RouteInfo routeInfo = await gpsService.GetRouteInfo(locations, tracker);

            //Assert
            Assert.AreEqual(expectedRouteInfo, routeInfo);
        }

        [Test]
        public async Task GetRouteInfo_PassDateRangeAndImeiParams_GetCorrectRouteInfoObject()
        {
            //Arrange
            GpsService gpsService = GetGpsService();
            DateTime dateFrom = new DateTime(2018, 10, 11, 17, 9, 32);
            DateTime dateTo = new DateTime(2018, 10, 11, 17, 23, 11);
            string imei = "1";
            RouteInfo expectedRouteInfo = GetExpectedRouteInfo();

            //Act
            RouteInfo routeInfo = await gpsService.GetRouteInfo(dateFrom, dateTo, imei);

            //Assert
            Assert.AreEqual(expectedRouteInfo, routeInfo);
        }

        [Test]
        public async Task GetRouteInfoList_PassDateRange_GetCorrectRouteInfoList()
        {
            //Arrange
            GpsService gpsService = GetGpsService();
            DateTime dateFrom = new DateTime(2018, 10, 11, 17, 9, 32);
            DateTime dateTo = new DateTime(2018, 10, 11, 17, 23, 11);
            List<RouteInfo> expectedRouteInfoList = GetExpectedRouteInfoList();

            //Act
            List<RouteInfo> routeInfoList = await gpsService.GetRouteInfoList(dateFrom, dateTo);

            //Assert
            for (int i = 0; i < expectedRouteInfoList.Count; i++)
            {
                Assert.AreEqual(expectedRouteInfoList[i], routeInfoList[i]);
            }
        }
    }
}
