using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Models
{
    [Table("Locations")]
    public class Locations
    {
        [Key]
        public int id { get; set; }
        public string location { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string imei { get; set; }
        public Nullable<double> latitude { get; set; }
        public Nullable<double> longitude { get; set; }
        public string hex { get; set; }
        public Nullable<bool> gps { get; set; }
        public Nullable<bool> gps_differential { get; set; }
        public string battery { get; set; }

        public override string ToString()
        {
            return id.ToString() + " " + location + " " + date.ToString() + " " + imei + " " + hex;
        }
    }
}
