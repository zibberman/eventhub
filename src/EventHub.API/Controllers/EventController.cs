using EventHub.Application.app.Events.Commands;
using EventHub.Application.app.Events.Queries;
using EventHub.Application.app.Events.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetEvent(Guid id)
        {
            var evt = await _mediator.Send(new GetEventByIdQuery { EventId = id });
            if (evt == null)
                return NotFound();
            return evt;
        }

        [HttpPost]
        public async Task<ActionResult<EventDto>> CreateEvent(CreateEventCommand command)
        {
            var evtDto = await _mediator.Send(command);
            return evtDto;
        }

        [HttpPut]
        public async Task UpdateEvent(UpdateEventCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            var evt = await _mediator.Send(new DeleteEventCommand { EventId = id });
            return NoContent();
        }
    }
}
