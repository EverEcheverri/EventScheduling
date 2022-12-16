namespace EventScheduling.Domain.City.Repositories;

public interface ICityRepository
{
  Task<City?> GetByNameAsync(string name, CancellationToken cancellationToken);
  Task SaveAsync(City city, CancellationToken cancellationToken);
}
