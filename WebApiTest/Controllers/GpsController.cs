using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackingWebApi.Models;
using TrackingWebApi.Services.Interfaces;

namespace TrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GpsController : ControllerBase
    {
        private readonly IGpsService gpsService;
        private readonly ILoginService loginService;

        public GpsController(IGpsService gpsService, ILoginService loginService)
        {
            this.gpsService = gpsService;
            this.loginService = loginService;
        }

        [HttpGet]
        public async Task<List<RouteInfo>> Get()
        {
            List<RouteInfo> routeInfos = await gpsService.GetRouteInfoList(DateTime.Today, DateTime.Today);
            return routeInfos;
        }

        [HttpGet("{dateFrom}/{dateTo}")]
        public async Task<List<RouteInfo>> Get(DateTime dateFrom, DateTime dateTo)
        {
            List<RouteInfo> routeInfos = await gpsService.GetRouteInfoList(dateFrom, dateTo);
            return routeInfos;
        }

        [HttpGet("{dateFrom}/{dateTo}/{imei}")]
        public async Task<RouteInfo> Get(DateTime dateFrom, DateTime dateTo, string imei)
        {
            RouteInfo routeInfo = await gpsService.GetRouteInfo(dateFrom, dateTo, imei);
            return routeInfo;
        }

        [HttpGet("{login}")]
        public string GetHash(string login)
        {
            return loginService.GetHash(login);
        }
    }
}
