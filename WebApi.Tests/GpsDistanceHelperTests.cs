using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TrackingWebApi.GpsMethods;
using TrackingWebApi.Tests.Stubs;
using WebApiTest.Models;

namespace TrackingWebApi.Tests
{
    [TestFixture]
    public class GpsDistanceHelperTests
    {
        [Test]
        public void CalculateDistance_GetDistanceInKmFromLocations_ReturnsCorrectDistance()
        {
            //Arrange
            LocationsList list = new LocationsList();
            List<Locations> locations = list.Locations;
            double expectedDistance = 2.07;

            //Act
            double distance = GpsDistanceHelper.CalculateDistance(locations);

            //Assert
            Assert.AreEqual(expectedDistance, distance);
        }
    }
}
