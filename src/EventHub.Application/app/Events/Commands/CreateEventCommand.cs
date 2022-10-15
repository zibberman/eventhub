using AutoMapper;
using EventHub.Application.app.Events.Responses;
using EventHub.Application.Common.Interfaces;
using EventHub.Domain;
using MediatR;

namespace EventHub.Application.app.Events.Commands
{
    public class CreateEventCommand : IRequest<EventDto>
    {
        public string EventTitle { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TypeName { get; set; } = String.Empty;
        public string Country { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public string StreetAddress { get; set; } = String.Empty;
        public string Note { get; set; } = String.Empty;
    }

    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, EventDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public CreateEventCommandHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<EventDto> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var evt = _mapper.Map<Event>(request);
            evt.Id = new Guid();
            _repository.Add<Event>(evt);
            await _repository.Save();
            
            var evtDto = _mapper.Map<EventDto>(evt);
            return evtDto;
        }
    }
}
