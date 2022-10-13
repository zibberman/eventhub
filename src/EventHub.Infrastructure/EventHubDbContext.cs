using EventHub.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventHub.Infrastructure
{
    public class EventHubDbContext : DbContext
    {
        public EventHubDbContext(DbContextOptions<EventHubDbContext> options) : base(options) {}

        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
    }
}
