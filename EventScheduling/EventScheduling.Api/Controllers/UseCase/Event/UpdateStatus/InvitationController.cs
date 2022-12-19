using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventScheduling.Api.Controllers.UseCase.Event.UpdateStatus
{
  using System.ComponentModel.DataAnnotations;
  using System.Net;
  using Application.Invitation.Interfaces;
  using CreateInvitation;
  using EventScheduling.Domain.Event.Commands;
  using Middleware;

  [Route("api/[controller]")]
  [ApiController]
  public class InvitationController : ControllerBase
  {
    private readonly IUpdateInvitation _updateInvitation;

    public InvitationController(IUpdateInvitation updateInvitation)
    {
      _updateInvitation = updateInvitation;
    }

    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateEvent([FromBody][Required] RequestUpdateInvitation requestUpdateInvitation,
      CancellationToken cancellationToken)
    {
      var command = requestUpdateInvitation.ToUpdateInvitationCommand();

      await _updateInvitation.ExecuteAsync(command, cancellationToken);

      return StatusCode((int)HttpStatusCode.OK);
    }
  }
}
