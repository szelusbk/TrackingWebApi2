using NUnit.Framework;
using System.Threading.Tasks;
using WebApiTest.APIs;

namespace WebApi.Tests
{
    [TestFixture]
    public class DistanceMatrixTests
    {
        [Test]
        public async Task CalculateDistanceAsync_GetRouteInKm_ReturnsCorectRouteValue()
        {
            string result = await DistanceMatrix.CalculateDistanceAsync("52.25394,21.0024", "52.23054,20.98867");

            StringAssert.AreEqualIgnoringCase("3,911", result);
        }
    }
}
