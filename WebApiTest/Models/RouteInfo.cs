using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.APIs;

namespace WebApiTest.Models
{
    public class RouteInfo
    {
        public string GpsName { get; set; } = "";
        public string GpsStatus { get; set; } = "";
        public string Imei { get; set; } = "";
        public string LastDate { get; set; } = "";
        public string Battery { get; set; } = "";
        public string ElapsedTime { get; set; } = "";
        public string Distance { get; set; } = "";
        public string LastLatitude { get; set; } = "";
        public string LastLongitude { get; set; } = "";
        public List<LatLng> LatLngList { get; set; } = new List<LatLng>();
    }

    public class LatLng
    {
        public string Latitude { get; set; } = "";
        public string Longitude { get; set; } = "";

        public override string ToString()
        {
            return Latitude + ", " + Longitude;
        }
    }
}
