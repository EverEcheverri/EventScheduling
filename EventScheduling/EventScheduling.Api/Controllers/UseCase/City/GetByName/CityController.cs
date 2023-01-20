namespace EventScheduling.Api.Controllers.UseCase.City.GetByName;

using System.ComponentModel.DataAnnotations;
using System.Net;
using Application.City.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Middleware;

[Route("api/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
  private readonly IGetCity _getCity;

  public CityController(IGetCity getCity)
  {
    _getCity = getCity;
  }

  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status409Conflict)]
  [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> GetCity([FromQuery] [Required] string name, CancellationToken cancellationToken)
  {
    var city = await _getCity.ExecuteAsync(name, cancellationToken);

    return StatusCode((int)HttpStatusCode.OK, city);
  }
}
