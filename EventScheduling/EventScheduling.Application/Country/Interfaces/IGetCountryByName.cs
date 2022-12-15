namespace EventScheduling.Application.Country.Interfaces;

using Domain.Country;

public interface IGetCountryByName
{
  Task<Country> ExecuteAsync(string name, CancellationToken cancellationToken);
}
