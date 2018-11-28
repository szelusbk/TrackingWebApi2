using System;

namespace WebApiTest.Models
{
    public class TransportsInfo
    {
        public int OrderNo { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string CustomerName { get; set; }
        public string VehicleType { get; set; }
        public string Address { get; set; }
        public string ProjectNo { get; set; }
        public string Imei { get; set; }
        public string TrackerName { get; set; }
        public string AddressLatitude { get; set; }
        public string AddressLongitude { get; set; }
    }
}
