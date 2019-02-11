using Microsoft.EntityFrameworkCore;
using TrackingWebApi.Models.Db;

namespace TrackingWebApi.Models
{
    public interface IGpsContext
    {
        DbSet<Locations> Locations { get; set; }
        DbSet<Trackers> Trackers { get; set; }
        DbSet<Transports> Transports { get; set; }
        DbSet<Users> Users { get; set; }
        DbSet<Orders> Orders { get; set; }
    }
}
