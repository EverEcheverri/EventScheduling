namespace EventScheduling.Domain.Country.Repositories;

public interface ICountryRepository
{
  Task<Country> GetByNameAsync(string name, CancellationToken cancellationToken);
}
