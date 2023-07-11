using Microsoft.EntityFrameworkCore;

namespace Travel.API.Entities.Context
{
    public class TravelPlannerDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<DestinationTrip> DestinationTrips { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<User> Users { get; set; }


        public TravelPlannerDbContext(DbContextOptions<TravelPlannerDbContext> options):base(options){
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Code).HasMaxLength(10);

                entity.HasMany(e => e.Locations)
                    .WithOne(l => l.Country)
                    .HasForeignKey(l => l.CountryId);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(250);
            });

            modelBuilder.Entity<Destination>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();

                entity.HasOne(d => d.Location)
                    .WithMany(l => l.Destinations)
                    .HasForeignKey(d => d.LocationId);
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(250);

                entity.HasMany(e => e.Destinations)
                    .WithMany(d => d.Trips)
                    .UsingEntity<DestinationTrip>(
                        l => l.HasOne<Destination>().WithMany().HasForeignKey(r => r.DestinationId),
                        w => w.HasOne<Trip>().WithMany().HasForeignKey(r => r.TripId)
                        ) ;
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasMany(e => e.Trips).WithOne(d => d.User)
                    .HasForeignKey(t => t.UserId);
            });

            modelBuilder.Entity<DestinationTrip>(entity =>
            {
                entity.HasKey(e =>  new {e.DestinationId, e.TripId});
            });
        }
    }
}
