namespace EventScheduling.Api.Controllers.UseCase.Event.GuestsStatus;

using System.ComponentModel.DataAnnotations;
using Application.Event.Interfaces;
using Details;
using Microsoft.AspNetCore.Mvc;

[Route("api/event")]
[ApiController]
public class EventController : ControllerBase
{
  private readonly IEventDetails _eventDetails;

  public EventController(IEventDetails eventDetails)
  {
    _eventDetails = eventDetails;
  }

  [HttpGet]
  [Route("details/view")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseEventDetails))]
  public async Task<IActionResult> ResponseEventGuestsStatus([Required] Guid eventId, CancellationToken cancellationToken)
  {
    var eventInviteResult = await _eventDetails.ExecuteAsync(eventId, cancellationToken);
    return Ok(ResponseEventDetails.Map(eventInviteResult));
  }
}
