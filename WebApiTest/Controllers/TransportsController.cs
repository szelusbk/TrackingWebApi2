using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiTest.Models;
using WebApiTest.GpsMethods;

namespace WebApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportsController
    {
        [HttpGet]
        public List<TransportsInfo> Get()
        {
            return TransportsService.GetTransportsInfoList();
        }

        [HttpGet("{orderNo}")]
        public TransportsInfo Get(int orderNo)
        {
            return TransportsService.GetTransportInfo(orderNo); ;
        }
    }
}
