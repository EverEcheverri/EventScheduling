namespace EventScheduling.Application.User.Interfaces;

using Domain.User;

public interface IGetByCountry
{
  Task<ICollection<User>> ExecuteAsync(string countryName, CancellationToken cancellationToken);
}
