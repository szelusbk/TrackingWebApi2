using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TrackingWebApi.Models;
using TrackingWebApi.Services.Interfaces;

namespace TrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportsController
    {
        private readonly ITransportsService transportsService;

        public TransportsController(ITransportsService transportsService)
        {
            this.transportsService = transportsService;
        }

        [HttpGet]
        public List<TransportsInfo> Get()
        {
            return transportsService.GetTransportsInfoList();
        }

        [HttpGet("{orderNo}")]
        public TransportsInfo Get(int orderNo)
        {
            return transportsService.GetTransportInfo(orderNo);
        }
    }
}
