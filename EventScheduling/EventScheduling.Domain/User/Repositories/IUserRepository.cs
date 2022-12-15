namespace EventScheduling.Domain.User.Repositories;

using Country;

public interface IUserRepository
{
  Task SaveAsync(User user, CancellationToken cancellationToken);
  Task<ICollection<User>> GetByCountryIdAsync(List<Guid> cityIds, CancellationToken cancellationToken);
}
