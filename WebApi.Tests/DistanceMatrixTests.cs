using NUnit.Framework;
using System.Threading.Tasks;
using TrackingWebApi.APIs;

namespace TrackingWebApi.Tests
{
    [TestFixture]
    public class DistanceMatrixTests
    {
        [Test]
        public async Task CalculateDistanceAsync_GetRouteInKm_ReturnsCorectRouteValue()
        {
            //Arrange
            DistanceMatrix distanceMatrix = new DistanceMatrix();

            //Act
            string result = await distanceMatrix.CalculateDistanceAsync("52.25394,21.0024", "52.23054,20.98867");

            //Assert
            StringAssert.AreEqualIgnoringCase("3,911", result);
        }
    }
}
