using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            List<RouteInfo> routeInfos = await GpsService.GetRouteInfoList(DateTime.Today, DateTime.Today);
            return routeInfos;
        }

        [HttpGet("{dateFrom}/{dateTo}")]
        public async Task<List<RouteInfo>> Get(DateTime dateFrom, DateTime dateTo)
        {
            List<RouteInfo> routeInfos = await GpsService.GetRouteInfoList(dateFrom, dateTo);
            return routeInfos;
        }

        [HttpGet("{dateFrom}/{dateTo}/{imei}")]
        public async Task<RouteInfo> Get(DateTime dateFrom, DateTime dateTo, string imei)
        {
            RouteInfo routeInfo = await GpsService.GetRouteInfo(dateFrom, dateTo, imei);
            return routeInfo;
        }

        [HttpGet("{login}")]
        public string GetHash(string login)
        {
            return LoginService.GetHash(login);
        }
    }
}
