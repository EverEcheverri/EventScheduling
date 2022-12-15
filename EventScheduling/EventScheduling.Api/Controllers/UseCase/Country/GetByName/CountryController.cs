namespace EventScheduling.Api.Controllers.UseCase.Country.GetByName;

using Application.Country.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
  private readonly IGetCountryByName _getCountryByName;

  public CountryController(IGetCountryByName getCountryByName)
  {
    _getCountryByName = getCountryByName;
  }

  [HttpGet]
  [Route("name")]
  public async Task<IActionResult> GetCountryByName(string name, CancellationToken cancellationToken)
  {
    var countries = await _getCountryByName.ExecuteAsync(name, cancellationToken);

    return Ok(countries);
  }
}
