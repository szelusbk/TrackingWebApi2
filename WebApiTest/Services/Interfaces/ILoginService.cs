using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackingWebApi.Services.Interfaces
{
    public interface ILoginService
    {
        string GetHash(string login);
    }
}
