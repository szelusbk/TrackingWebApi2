using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackingWebApi.Models
{
    [Table("Transports")]
    public class Transports
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("date_from")]
        public DateTime DateFrom { get; set; }
        [Column("date_to")]
        public DateTime DateTo { get; set; }
        [Column("customer_name")]
        public string CustomerName { get; set; }
        [Column("vehicle_type")]
        public string VehicleType { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("proj_no")]
        public string ProjectNo { get; set; }
        [Column("addr_latitude")]
        public string AddressLatitude { get; set; }
        [Column("addr_longitude")]
        public string AddressLongitude { get; set; }

        [ForeignKey("imei")]
        public virtual Trackers Tracker { get; set; }
    }
}
