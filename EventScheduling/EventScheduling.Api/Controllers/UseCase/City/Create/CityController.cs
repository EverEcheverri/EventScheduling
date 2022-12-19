namespace EventScheduling.Api.Controllers.UseCase.City.Create;

using System.ComponentModel.DataAnnotations;
using System.Net;
using Cities.Create;
using EventScheduling.Api.Middleware;
using EventScheduling.Application.City.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("api/city")]
[ApiController]
public class CityController : ControllerBase
{
  private readonly ICreateCity _createCity;

  public CityController(ICreateCity createCity)
  {
    _createCity = createCity;
  }

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status409Conflict)]
  [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> CreateCity([FromBody] [Required] RequestCreateCity requestCreateCity,
    CancellationToken cancellationToken)
  {
    var command = requestCreateCity.ToCreateCityCommand();
    await _createCity.ExecuteAsync(command, cancellationToken);

    return StatusCode((int)HttpStatusCode.Created, command.Id);
  }
}
