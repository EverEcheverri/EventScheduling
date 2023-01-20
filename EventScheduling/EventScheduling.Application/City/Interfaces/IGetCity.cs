using EventScheduling.Domain.City.Commands;

namespace EventScheduling.Application.City.Interfaces;

using Domain.City;

public interface IGetCity
{
  Task<City> ExecuteAsync(string name, CancellationToken cancellationToken);
}
