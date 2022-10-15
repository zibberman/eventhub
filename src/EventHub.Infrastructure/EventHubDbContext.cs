using EventHub.Domain;
using EventHub.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EventHub.Infrastructure
{
    public class EventHubDbContext : DbContext
    {
        public EventHubDbContext(DbContextOptions<EventHubDbContext> options) : base(options) {}

        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventTag> EventTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventTypeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventTagConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventTagEventConfiguration).Assembly);
        }
    }
}
