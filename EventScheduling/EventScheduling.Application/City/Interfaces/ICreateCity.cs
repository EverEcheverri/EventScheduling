namespace EventScheduling.Application.City.Interfaces;

using Domain.City.Commands;

public interface ICreateCity
{
  Task ExecuteAsync(CreateCityCommand createCityCommand, CancellationToken cancellationToken);
}
