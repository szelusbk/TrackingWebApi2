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

            //modelBuilder.Entity<Locations>(table =>
            //{
            //    table.HasKey(x => x.id);

            //    table.HasOne(x => x.tracker)
            //    .WithMany(x => x.Locations)
            //    .HasForeignKey(x => x.imei)
            //    .HasPrincipalKey(x => x.imei)//<<== here is core code to let foreign key userId point to User.Id.
            //    .OnDelete(DeleteBehavior.Cascade);
            //});

            base.OnModelCreating(modelBuilder);
        }

    }
}
