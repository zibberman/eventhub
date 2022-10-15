namespace EventHub.Application.app.Events.Responses
{
    public class EventDto
    {
        public string EventTitle { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Country { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public string StreetAddress { get; set; } = String.Empty;
    }
}
