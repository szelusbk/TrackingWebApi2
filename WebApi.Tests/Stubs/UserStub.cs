using TrackingWebApi.Models;

namespace TrackingWebApi.Tests.Stubs
{
    public static class UserStub
    {
        public static Users GetUser()
        {
            Users user = new Users()
            {
                Login = "login",
                Password = "Hz123Wz"
            };

            return user;
        }
    }
}
