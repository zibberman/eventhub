using AutoMapper;
using EventHub.Application.Common.Interfaces;
using EventHub.Domain;
using MediatR;

namespace EventHub.Application.app.Events.Commands
{
    public class UpdateEventCommand : IRequest
    {
        public Guid EventId { get; set; }
        public string EventTitle { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var evt = await _repository.GetById<Event>(request.EventId);
            _mapper.Map(request, evt);
            await _repository.Save();
            return Unit.Value;
        }
    }
}
