using System;
using System.Collections.Generic;
using TrackingWebApi.Models;

namespace TrackingWebApi.Services.Interfaces
{
    public interface IGpsTimeHelper
    {
        TimeSpan GetElapsedTime(List<Locations> locations);
    }
}
