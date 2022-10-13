namespace EventHub.Domain
{
    public class Event : Entity
    {
        public string EventTitle { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Guid LocationId { get; set; }
        public Location Location { get; set; }

        public Guid EventTypeId { get; set; }
        public EventType EventType { get; set; }
    }
}
