using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTest.GpsMethods;
using WebApiTest.Models;

namespace WebApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GpsController : ControllerBase
    {
        [HttpGet]
        public async Task<List<RouteInfo>> Get()
        {
            List<RouteInfo> routeInfos = new List<RouteInfo>();
            routeInfos = await GpsService.GetRouteInfoList(DateTime.Today, DateTime.Today);

            return routeInfos;
        }

        [HttpGet("{dateFrom}/{dateTo}")]
        public async Task<List<RouteInfo>> Get(DateTime dateFrom, DateTime dateTo)
        {
            List<RouteInfo> routeInfos = new List<RouteInfo>();
            routeInfos = await GpsService.GetRouteInfoList(dateFrom, dateTo);

            return routeInfos;
        }

        [HttpGet("{dateFrom}/{dateTo}/{imei}")]
        public async Task<RouteInfo> Get(DateTime dateFrom, DateTime dateTo, string imei)
        {
            List<Locations> chosenLocations = new List<Locations>();
            Trackers tracker = new Trackers();
            using (var context = new GPSContext())
            {
                tracker = context.Trackers.Where(x => x.imei == imei).FirstOrDefault();
                var locations = context.Locations.Where(x => x.date >= dateFrom && x.date <= dateTo && x.latitude != null && x.longitude != null && x.imei == imei).OrderByDescending(x => x.date).ToList<Locations>();

                if (dateFrom.Hour == 0 && dateFrom.Minute == 0 && dateTo.Hour == 0 && dateTo.Minute == 0)
                    chosenLocations = locations;
                else
                    chosenLocations = locations.Where(x => x.date <= dateTo && x.date >= dateFrom).OrderByDescending(x => x.date).ToList<Locations>();
            }

            RouteInfo routeInfo = await GpsService.GetRouteInfo(chosenLocations, tracker);
            return routeInfo;
        }

        [HttpGet("{login}")]
        public string GetHash(string login)
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
