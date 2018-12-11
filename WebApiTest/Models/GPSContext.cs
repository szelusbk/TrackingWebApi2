using Microsoft.EntityFrameworkCore;


namespace TrackingWebApi.Models
{
    public class GpsContext : DbContext, IGpsContext
    {
        public GpsContext() : base() {}
        public GpsContext(DbContextOptions<GpsContext> options) : base(options) {}

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
