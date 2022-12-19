﻿namespace EventScheduling.Api.Controllers.UseCase.Country.GetByName;

using Application.Country.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Middleware;

[Route("api/country")]
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
  [ProducesResponseType(StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(CustomErrorResponse), StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> GetCountryByName(string name, CancellationToken cancellationToken)
  {
    var countries = await _getCountryByName.ExecuteAsync(name, cancellationToken);

    return Ok(countries);
  }
}
