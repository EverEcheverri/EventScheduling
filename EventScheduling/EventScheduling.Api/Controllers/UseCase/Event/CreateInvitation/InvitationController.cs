namespace EventScheduling.Api.Controllers.UseCase.Event.CreateInvitation;

using System.ComponentModel.DataAnnotations;
using System.Net;
using Application.Invitation.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Middleware;

[Route("api/[controller]")]
[ApiController]
public class InvitationController : ControllerBase
{
  private readonly ICreateInvitation _createInvitation;

  public InvitationController(ICreateInvitation createInvitation)
  {
    _createInvitation = createInvitation;
  }


  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status409Conflict)]
  [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> CreateEvent([FromBody][Required] RequestCreateInvitation requestCreateInvitation,
    CancellationToken cancellationToken)
  {
    var command = requestCreateInvitation.ToCreateInvitationCommand();

    await _createInvitation.ExecuteAsync(command, cancellationToken);

    return StatusCode((int)HttpStatusCode.Created, command.InvitationId);
  }
}
