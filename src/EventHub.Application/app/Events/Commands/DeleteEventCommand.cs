using EventHub.Application.Common.Interfaces;
using EventHub.Domain;
using MediatR;

namespace EventHub.Application.app.Events.Commands
{
    public class DeleteEventCommand : IRequest
    {
        public Guid EventId { get; set; }
    }

    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IRepository _repository;

        public DeleteEventCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            await _repository.Remove<Event>(request.EventId);
            await _repository.Save();
            return Unit.Value;
        }
    }
}
