using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            List<TransportsInfo> transportInfos = new List<TransportsInfo>();

            using(var context = new GPSContext())
            {
                var transports = context.Transports.Take(1000).ToList();
                transportInfos = TransportsService.GetTransportsInfoList(transports);
            }

            return transportInfos;
        }
    }
}
