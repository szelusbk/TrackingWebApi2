using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Models
{
    public class GPSContext : DbContext
    {
        public GPSContext() : base() { }

        public DbSet<Locations> Locations { get; set; }
        public DbSet<Trackers> Trackers { get; set; }
        public DbSet<Transports> Transports { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(@"server");
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("aw");
            base.OnModelCreating(modelBuilder);
        }

    }
}
