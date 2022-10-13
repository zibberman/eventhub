using EventHub.Domain;

namespace EventHub.Infrastructure.DataSeeds
{
    public class EventsSeed
    {
        public static async Task Seed(EventHubDbContext context)
        {
            if (!context.Events.Any())
            {
                var event1 = new Event
                {
                    Id = new Guid(),
                    EventTitle = "Philadelphia Street Food Festival",
                    Description = "The 1st ever Philadelphia Street Food Festival is coming to Xfinity Live! on Saturday, November 19th, 2022! This spectacular event will feature the Philadelphia area's best food trucks & restaurants with all food items priced at $5 or less! This will give guests the opportunity to sample a wide range of flavors & options from over 20+ vendors!",
                    StartDate = new DateTime(2022, 11, 19, 14, 0, 0),
                    EndDate = new DateTime(2022, 11, 19, 20, 0, 0),
                    EventType = context.EventTypes.First(n => n.TypeName == "Food & Drink"),
                    Location = new Location
                    {
                        Id = new Guid(),
                        Country = "United States of America",
                        City = "Philadelphia",
                        StreetAddress = "1100 Pattison Avenue",
                        Note = "Xfinity Live! Philadelphia 1100 Pattison Avenue Philadelphia, PA 19148 United States"
                    }
                };

                var event2 = new Event
                {
                    Id = new Guid(),
                    EventTitle = "Dallas Soul Food Festival",
                    Description = "Come enjoy food from over 30 different food vendors from Dallas, Houston, Austin, and other surrounding cities. The Dallas Soul Food will be a mix of foods including pork chops, oxtails, candied yams, greens, fried chicken, fish, barbecue, funnel cake, turkey legs, tacos, vegan & keto optional available.",
                    StartDate = new DateTime(2022, 10, 23, 12, 0, 0),
                    EndDate = new DateTime(2022, 11, 19, 19, 0, 0),
                    EventType = context.EventTypes.First(n => n.TypeName == "Food & Drink"),
                    Location = new Location
                    {
                        Id = new Guid(),
                        Country = "United States of America",
                        City = "Dallas",
                        StreetAddress = "816 Montgomery Street",
                        Note = "Lofty Spaces 816 Montgomery Street Dallas, TX 75215 United States"
                    }
                };

                context.Events.Add(event1);
                context.Events.Add(event2);

                await context.SaveChangesAsync();
            }
        }
    }
}
