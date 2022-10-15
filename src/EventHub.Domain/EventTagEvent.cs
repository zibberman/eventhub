namespace EventHub.Domain
{
    public class EventTagEvent
    {
        public Guid EventId { get; set; }
        public Event Event { get; set; }

        public Guid EventTagId { get; set; }
        public EventTag EventTag { get; set; }
    }
}
