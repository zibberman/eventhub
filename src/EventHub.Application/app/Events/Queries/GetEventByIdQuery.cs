using MediatR;
using EventHub.Application.app.Events.Responses;
using EventHub.Application.Common.Interfaces;
using AutoMapper;
using EventHub.Domain;

namespace EventHub.Application.app.Events.Queries
{
    public class GetEventByIdQuery : IRequest<EventDto>
    {
        public Guid EventId { get; set; }
    }

    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, EventDto>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetEventByIdQueryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EventDto> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var evt = await _repository.GetByIdWithInclude<Event>(request.EventId, n => n.Location);
            return _mapper.Map<EventDto>(evt);
        }
    }
}
