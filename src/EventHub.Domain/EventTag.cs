namespace EventHub.Domain
{
    public class EventTag : Entity
    {
        public string TagName { get; set; } = String.Empty;

        public ICollection<EventTagEvent> EventTagEvents { get; set; }
    }
}
