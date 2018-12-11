using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TrackingWebApi.Models
{
    [Table("Locations")]
    public class Locations
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("location")]
        public string Location { get; set; }
        [Column("date")]
        public DateTime? Date { get; set; }
        [Column("imei")]
        public string Imei { get; set; }
        [Column("latitude")]
        public double? Latitude { get; set; }
        [Column("longitude")]
        public double? Longitude { get; set; }
        [Column("hex")]
        public string Hex { get; set; }
        [Column("gps")]
        public bool? Gps { get; set; }
        [Column("gps_differential")]
        public bool? GpsDifferential { get; set; }
        [Column("battery")]
        public string Battery { get; set; }

        public override string ToString()
        {
            return Id.ToString() + " " + Location + " " + Date.ToString() + " " + Imei + " " + Hex;
        }
    }
}
