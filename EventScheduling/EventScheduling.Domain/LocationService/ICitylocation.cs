using EventScheduling.Domain.Event.Commands;

namespace EventScheduling.Domain.LocationService;

public interface ICitylocationService
{
  Task<ResponseGetCityLocation> GetCityLocationAsync(string cityName, CancellationToken cancellationToken);
}
