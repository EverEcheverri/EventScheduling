namespace EventScheduling.Api.Controllers.UseCase.User.Create;

using System.ComponentModel.DataAnnotations;
using System.Net;
using Application.User.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Middleware;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
  private readonly ICreateUser _createUser;

  public UserController(ICreateUser createUser)
  {
    _createUser = createUser;
  }

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status409Conflict)]
  [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> CreatePackage([FromBody] [Required] RequestCreateUser requestCreateUser,
    CancellationToken cancellationToken)
  {
    var command = requestCreateUser.ToCreateUserCommand();
    await _createUser.ExecuteAsync(command, cancellationToken);

    return StatusCode((int)HttpStatusCode.Created, command.Email);
  }
}
