using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EventHub.Infrastructure
{
    public class EventHubDbContextFactory : IDesignTimeDbContextFactory<EventHubDbContext>
    {
        public EventHubDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<EventHubDbContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new EventHubDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EventHub.API"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
