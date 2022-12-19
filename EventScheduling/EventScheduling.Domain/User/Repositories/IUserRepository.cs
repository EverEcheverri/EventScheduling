namespace EventScheduling.Domain.User.Repositories;

using Queries;
using ValueObjects;

public interface IUserRepository
{
  Task SaveAsync(User user, CancellationToken cancellationToken);
  Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken);
  Task<GetWithCityQuery> GetWithTimeZoneIdAsync(Email email, CancellationToken cancellationToken);
  Task<ICollection<GetByCountryQuery>> GetByCountryIdAsync(Guid countryId, CancellationToken cancellationToken);
}
