using AutoMapper;
using Events.Application.Events.Quaries.GetEventList;
using Events.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Events.Application.Events.Commands.CreateEvent;
using Events.Application.Events.Commands.DeleteCommand;
using Events.Application.Events.Commands.UpdateEvent;
using Microsoft.AspNetCore.Mvc;

namespace Events.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EventController : BaseController
    {
        private readonly IMapper _mapper;
        public EventController(IMapper mapper) => _mapper = mapper;
        /// <summary>
        /// Gets the list of events
        /// </summary>
        /// <remarks>
        /// GET /event/events
        /// </remarks>
        /// <returns>Returns EventListVm</returns>
        /// <response code="200">Success</response>
        [AllowAnonymous]
        [HttpGet("events")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EventListVm>> GetAll()
        {
            var query = new GetEventListQuery
            {
                Id = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        /// <summary>
        /// Creates the event
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /event
        /// {
        ///     title: "event title",
        ///     Description: "event Description",
        ///     StartDateTime: "event StartDateTime",
        ///     EndDateTime: "event EndDateTime",
        ///     ImageId: "event ImageId",
        ///     SpaceId: "event SpaceId",
        ///     Tickets: "Quantity event Tickets"
        /// }
        /// </remarks>
        /// <param name="createEventDto">CreateEventDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="404">Bad request</response>
        [AllowAnonymous]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEventDto createEventDto)
        {
            var command = _mapper.Map<CreateEventCommand>(createEventDto);
            command.Id = Id;
            var eventId = await Mediator.Send(command);
            return Ok(eventId);
        }
        /// <summary>
        /// Updates the event
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /event
        /// {
        ///     title: "update event title",
        ///     Description: "update event Description",
        ///     StartDateTime: "update event StartDateTime",
        ///     EndDateTime: "update event EndDateTime",
        ///     ImageId: "update event ImageId",
        ///     SpaceId: "update event SpaceId",
        ///     Tickets: "update Quantity event Tickets"
        /// }
        /// </remarks>
        /// <param name="updateEventDto">UpdateNoteDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="404">Bad request</response>
        [AllowAnonymous]
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateEventDto updateEventDto)
        {
            var command = _mapper.Map<UpdateEventCommand>(updateEventDto);
            command.Id = Id;
            await Mediator.Send(command);
            return NoContent();
        }
        /// <summary>
        /// Deletes the event by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /event/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the event (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="404">Bad request</response>
        [AllowAnonymous]
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteEventCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
        
        
    }
}
