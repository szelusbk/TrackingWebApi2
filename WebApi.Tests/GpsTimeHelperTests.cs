using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using WebApiTest.Models;
using TrackingWebApi.Tests.Stubs;
using TrackingWebApi.GpsMethods;

namespace TrackingWebApi.Tests
{
    [TestFixture]
    public class GpsTimeHelperTests
    {

        [Test]
        public void GetElapsedTime_DetermineElapsedTimeBasedOnLocations_ReturnsCorrectDateTime()
        {
            //Arrange
            LocationsList list = new LocationsList();
            List<Locations> locations = list.Locations;
            TimeSpan expectedTime = new TimeSpan(0,13,39);

            //Act
            TimeSpan elapsedTime = GpsTimeHelper.GetElapsedTime(locations);

            //Assert
            Assert.AreEqual(expectedTime, elapsedTime);
        }
    }
}
