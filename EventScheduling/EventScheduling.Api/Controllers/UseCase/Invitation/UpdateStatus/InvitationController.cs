namespace EventScheduling.Api.Controllers.UseCase.Invitation.UpdateStatus
{
  using System.ComponentModel.DataAnnotations;
  using System.Net;
  using Application.Invitation.Interfaces;
  using Microsoft.AspNetCore.Mvc;
  using Middleware;

  [Route("api/invitation")]
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
