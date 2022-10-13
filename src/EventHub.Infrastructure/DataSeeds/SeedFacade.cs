using Microsoft.EntityFrameworkCore;

namespace EventHub.Infrastructure.DataSeeds
{
    public class SeedFacade
    {
        public static async Task SeedData(EventHubDbContext context)
        {
            context.Database.Migrate();

            await EventTypesSeed.Seed(context);
            await EventsSeed.Seed(context);
        }
    }
}
