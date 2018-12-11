using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackingWebApi.APIs
{
    public interface IDistanceMatrix
    {
        Task<string> CalculateDistanceAsync(string origins, string destinations);
    }
}
