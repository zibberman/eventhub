using System;
namespace EventHub.Domain
{
    public class EventType : Entity
    {
        public string TypeName { get; set; } = String.Empty;

        public ICollection<Event> Events { get; set; }
    }
}
