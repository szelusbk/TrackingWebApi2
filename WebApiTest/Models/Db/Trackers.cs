using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiTest.Models
{
    [Table("Trackers")]
    public class Trackers
    {
        [Key]
        [Column("imei")]
        public string Imei { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("status")]
        public string Status { get; set; }
        [Column("battery")]
        public string Battery { get; set; }

        public virtual List<Locations> Locations { get; set; } = new List<Locations>();
    }
}
