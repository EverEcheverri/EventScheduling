namespace EventScheduling.Domain.User.Repositories;

using Queries;

public interface IUserRepository
{
  Task SaveAsync(User user, CancellationToken cancellationToken);
  Task<ICollection<GetByCountryQuery>> GetByCountryIdAsync(Guid countryId, CancellationToken cancellationToken);
}
