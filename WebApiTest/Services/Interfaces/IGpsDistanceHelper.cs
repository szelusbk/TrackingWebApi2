using System.Collections.Generic;
using TrackingWebApi.Models;

namespace TrackingWebApi.Services.Interfaces
{
    public interface IGpsDistanceHelper
    {
        double CalculateDistance(List<Locations> locations);
    }
}
