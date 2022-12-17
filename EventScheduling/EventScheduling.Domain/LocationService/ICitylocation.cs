using EventScheduling.Domain.Event.Commands;

namespace EventScheduling.Domain.LocationService;

public interface ICitylocation
{
  Task<ResponseGetCityLocation> IGetCityLocationAsync(string cityName, CancellationToken cancellationToken);
}
