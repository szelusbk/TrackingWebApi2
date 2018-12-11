using System.Collections.Generic;
using NUnit.Framework;
using TrackingWebApi.Services;
using TrackingWebApi.Tests.Stubs;
using TrackingWebApi.Models;

namespace TrackingWebApi.Tests
{
    [TestFixture]
    public class GpsDistanceHelperTests
    {
        [Test]
        public void CalculateDistance_GetDistanceInKmFromLocations_ReturnsCorrectDistance()
        {
            //Arrange
            List<Locations> locations = LocationsListStub.GetLocationsList();
            GpsDistanceHelper gpsDistanceHelper = new GpsDistanceHelper();
            double expectedDistance = 2.07;

            //Act
            double distance = gpsDistanceHelper.CalculateDistance(locations);

            //Assert
            Assert.AreEqual(expectedDistance, distance);
        }
    }
}
