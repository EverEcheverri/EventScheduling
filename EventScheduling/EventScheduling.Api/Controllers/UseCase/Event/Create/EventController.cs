using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventScheduling.Api.Controllers.UseCase.Event.Create
{
  using System.ComponentModel.DataAnnotations;
  using System.Net;
  using EventScheduling.Application.Event.Interfaces;
  using EventScheduling.Application.User.Interfaces;
  using EventScheduling.Domain.Event.Commands;
  using Middleware;
  using User.Create;

  [Route("api/[controller]")]
  [ApiController]
  public class EventController : ControllerBase
  {
    private readonly ICreateEvent _createEvent;

    public EventController(ICreateEvent createEvent)
    {
      _createEvent = createEvent;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateEvent([FromBody] [Required] RequestCreateEvent requestCreateEvent,
      CancellationToken cancellationToken)
    {
      var command = requestCreateEvent.ToCreateEventCommand();

      await _createEvent.ExecuteAsync(command, cancellationToken);

      return StatusCode((int)HttpStatusCode.Created, command.Id);
    }
  }
}
