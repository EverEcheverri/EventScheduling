namespace EventScheduling.Api.Controllers.UseCase.Cities.Create;

using System.ComponentModel.DataAnnotations;
using System.Net;
using Application.City.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
  private readonly ICreateCity _createCity;

  public CityController(ICreateCity createCity)
  {
    _createCity = createCity;
  }

  [HttpPost]
  public async Task<IActionResult> CreatePackage([FromBody] [Required] RequestCreateCity requestCreateCity,
    CancellationToken cancellationToken)
  {
    var command = requestCreateCity.ToCreateCityCommand();
    await _createCity.ExecuteAsync(command, cancellationToken);

    return StatusCode((int)HttpStatusCode.Created, command.Id);
  }
}
