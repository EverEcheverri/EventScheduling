namespace EventScheduling.Domain.City.Repositories;

public interface ICityRepository
{
  Task SaveAsync(City city, CancellationToken cancellationToken);
}
