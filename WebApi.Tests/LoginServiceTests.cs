using NUnit.Framework;
using TrackingWebApi.Models;
using TrackingWebApi.Services;
using TrackingWebApi.Tests.Stubs;

namespace TrackingWebApi.Tests
{
    [TestFixture]
    public class LoginServiceTests
    {
        private LoginService GetLoginService()
        {
            IGpsContext gpsContext = new GpsContextStub().GetContext();
            LoginService loginService = new LoginService(gpsContext);
            return loginService;
        }

        [Test]
        public void GetHash_PassLoginString_ReturnsCorrectHash()
        {
            //Arrange
            string login = "login";
            LoginService loginService = GetLoginService();

            //Act
            string hashedPass = loginService.GetHash(login);

            //Assert
            StringAssert.IsMatch("Hz123Wz", hashedPass);
        }
    }
}
