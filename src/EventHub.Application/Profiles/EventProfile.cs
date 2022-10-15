using AutoMapper;
using EventHub.Application.app.Events.Commands;
using EventHub.Application.app.Events.Responses;
using EventHub.Domain;

namespace EventHub.Application.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>()
                .ForMember(n => n.Country, n => n.MapFrom(n => n.Location.Country))
                .ForMember(n => n.City, n => n.MapFrom(n => n.Location.City))
                .ForMember(n => n.StreetAddress, n => n.MapFrom(n => n.Location.StreetAddress));

            CreateMap<CreateEventCommand, Event>()
                .ForPath(n => n.EventType.TypeName, n => n.MapFrom(n => n.TypeName))
                .ForPath(n => n.Location.Country, n => n.MapFrom(n => n.Country))
                .ForPath(n => n.Location.City, n => n.MapFrom(n => n.City))
                .ForPath(n => n.Location.StreetAddress, n => n.MapFrom(n => n.StreetAddress))
                .ForPath(n => n.Location.Note, n => n.MapFrom(n => n.Note));

            CreateMap<UpdateEventCommand, Event>();
        }
    }
}
