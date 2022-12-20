namespace EventScheduling.Application.User.Interfaces;

using Domain.User.Queries;

public interface IGetByCountry
{
  Task<ICollection<GetByCountryQuery>> ExecuteAsync(string countryName, CancellationToken cancellationToken);
}
