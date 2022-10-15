namespace EventHub.Domain
{
    public class Location : Entity
    {
        public string Country { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public string StreetAddress { get; set; } = String.Empty;
        public string Note { get; set; } = String.Empty;

        public ICollection<Event> Events { get; set; }
    }
}
