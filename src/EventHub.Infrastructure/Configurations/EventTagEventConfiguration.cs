using EventHub.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHub.Infrastructure.Configurations
{
    public class EventTagEventConfiguration : IEntityTypeConfiguration<EventTagEvent>
    {
        public void Configure(EntityTypeBuilder<EventTagEvent> builder)
        {
            builder.ToTable("EventTagEvents");
            builder.HasKey(n => new { n.EventId, n.EventTagId });
        }
    }
}
