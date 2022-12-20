namespace EventScheduling.Api.Controllers.UseCase.User.GetByCountry;

using System.ComponentModel.DataAnnotations;
using Application.User.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
  private readonly IGetByCountry _getByCountry;

  public UserController(IGetByCountry getByCountry)
  {
    _getByCountry = getByCountry;
  }

  [HttpGet("countryName")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ResponseGetUsersByCountryName>))]
  public async Task<IActionResult> GetByCountry([Required] string countryName, CancellationToken cancellationToken)
  {
    var users = await _getByCountry.ExecuteAsync(countryName, cancellationToken);
    return Ok(ResponseGetUsersByCountryName.Map(users));
  }
}
