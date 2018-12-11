using System;
using System.Collections.Generic;
using NUnit.Framework;
using TrackingWebApi.Models;
using TrackingWebApi.Tests.Stubs;
using TrackingWebApi.Services;

namespace TrackingWebApi.Tests
{
    [TestFixture]
    public class GpsTimeHelperTests
    {
        [Test]
        public void GetElapsedTime_DetermineElapsedTimeBasedOnLocations_ReturnsCorrectDateTime()
        {
            //Arrange
            List<Locations> locations = LocationsListStub.GetLocationsList();
            GpsTimeHelper gpsTimeHelper = new GpsTimeHelper();
            TimeSpan expectedTime = new TimeSpan(0,13,39);

            //Act
            TimeSpan elapsedTime = gpsTimeHelper.GetElapsedTime(locations);

            //Assert
            Assert.AreEqual(expectedTime, elapsedTime);
        }
    }
}
