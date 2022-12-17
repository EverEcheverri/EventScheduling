namespace EventScheduling.Infrastructure.Services;

using System.Text.Json;
using Domain.Event.Commands;
using Domain.LocationService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public class LocationService : ICitylocation
{
  private readonly HttpClient _client;
  protected readonly IConfiguration _configuration;
  private readonly ILogger<LocationService> _logger;

  public LocationService(IConfiguration configuration, IHttpClientFactory httpClientFactory,
    ILogger<LocationService> logger)
  {
    _configuration = configuration;
    _logger = logger;
    _client = httpClientFactory.CreateClient("Weatherstack");
  }

  public async Task<ResponseGetCityLocation> IGetCityLocationAsync(string cityName, CancellationToken cancellationToken)
  {
    cancellationToken.ThrowIfCancellationRequested();
    var accessKey = _configuration.GetSection("LocationService:AccessKey").Value;
    var requestUri = $"current?access_key={accessKey}&query={cityName}";

    try
    {
      var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
      var response = await _client.SendAsync(request, cancellationToken);
      
      if (response.IsSuccessStatusCode)
      {
        var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
        var cityLocation =
          JsonSerializer.Deserialize<ResponseGetCityLocation>(jsonString);
        return cityLocation;
      }

      return new ResponseGetCityLocation();
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, $"An error has occurred calling IGetCityLocationAsync: {ex.Message}");
      throw;
    }
  }
}
