using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Models
{
    [Table("Trackers")]
    public class Trackers
    {
        [Key]
        public string imei { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string battery { get; set; }

        public virtual List<Locations> Locations { get; set; } = new List<Locations>();
    }
}
