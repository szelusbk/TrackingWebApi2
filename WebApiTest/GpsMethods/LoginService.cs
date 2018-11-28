using System.Linq;
using WebApiTest.Models;

namespace WebApiTest.GpsMethods
{
    public static class LoginService
    {
        public static string GetHash(string login)
        {
            string hash = "";
            using (var context = new GPSContext())
            {
                hash = context.Users.Where(x => x.Login == login).FirstOrDefault()?.Password ?? "";
            }

            return hash;
        }
    }
}
