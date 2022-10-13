using EventHub.Domain;

namespace EventHub.Infrastructure.DataSeeds
{
    public class EventTypesSeed
    {
        public static async Task Seed(EventHubDbContext context)
        {
            if (!context.EventTypes.Any())
            {
                string[] types = { "Corporate", "Fundraising", "Conferences & Expos",
                    "Classes & WorkShops", "Virtual", "Fandom", "Festival & Fairs",
                    "Food & Drink", "Hackathons", "Sport" };
                
                foreach (var i in types)
                {
                    context.Add(new EventType { Id = new Guid(), TypeName = i });
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
