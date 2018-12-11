using System.Linq;
using TrackingWebApi.Models;
using TrackingWebApi.Services.Interfaces;

namespace TrackingWebApi.Services
{
    public class LoginService : ILoginService
    {
        private readonly IGpsContext context;

        public LoginService(IGpsContext context)
        {
            this.context = context;
        }

        public string GetHash(string login)
        {
            string hash = "";
            hash = context.Users.Where(x => x.Login == login).FirstOrDefault()?.Password ?? "";

            return hash;
        }
    }
}
