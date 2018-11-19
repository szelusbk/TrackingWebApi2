using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Models
{
    public class TransportsInfo
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string CustomerName { get; set; }
        public string VehicleType { get; set; }
        public string Address { get; set; }
        public string ProjectNo { get; set; }
        public string Imei { get; set; }
        public string TrackerName { get; set; }
    }
}
