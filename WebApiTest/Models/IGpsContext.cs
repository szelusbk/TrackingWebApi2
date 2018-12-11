using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackingWebApi.Models
{
    public interface IGpsContext
    {
        DbSet<Locations> Locations { get; set; }
        DbSet<Trackers> Trackers { get; set; }
        DbSet<Transports> Transports { get; set; }
        DbSet<Users> Users { get; set; }
    }
}
