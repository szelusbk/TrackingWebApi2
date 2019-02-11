using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackingWebApi.Models;

namespace TrackingWebApi.Services.Interfaces
{
    public interface IGpsService
    {
        Task<RouteInfo> GetRouteInfo(List<Locations> locations, Trackers Tracker);
        Task<RouteInfo> GetRouteInfo(DateTime dateFrom, DateTime dateTo, string imei);
        Task<List<RouteInfo>> GetRouteInfoList(DateTime dateFrom, DateTime dateTo);
    }
}
