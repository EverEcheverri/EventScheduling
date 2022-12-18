using EventScheduling.Domain.Event.Commands;

namespace EventScheduling.Domain.LocationService;

public interface ICitylocationService
{
  Task<ResponseGetCityLocation> IGetCityLocationAsync(string cityName, CancellationToken cancellationToken);
}
