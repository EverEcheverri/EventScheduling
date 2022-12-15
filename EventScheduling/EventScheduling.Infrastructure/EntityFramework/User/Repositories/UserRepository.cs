namespace EventScheduling.Infrastructure.EntityFramework.User.Repositories;

using Domain.User;
using Domain.User.Repositories;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
  private readonly EventSchedulingDbContext _context;

  public UserRepository(EventSchedulingDbContext context)
  {
    _context = context;
  }

  public async Task SaveAsync(User user, CancellationToken cancellationToken)
  {
    await _context.User.AddAsync(user, cancellationToken);
    await _context.SaveChangesAsync(cancellationToken);
  }

  public async Task<ICollection<User>> GetByCountryIdAsync(List<Guid> cityIds, CancellationToken cancellationToken)
  {
    await Test("colombia", cancellationToken);
    var userResultAsync =
      await _context.User
        .Where(u => cityIds.Any(ci => u.CityId == ci))
        .ToListAsync(
          cancellationToken);

    return userResultAsync;
  }

  public async Task Test(string name, CancellationToken cancellationToken)
  {
    var countryResultAsync =
      await _context.Country
        .FirstOrDefaultAsync(co => co.Name.ToLower() == name,
          cancellationToken);

    var user = (from u in _context.User
      join ci in _context.City
        on u.CityId equals ci.Id
      where ci.CountryId == countryResultAsync.Id
      select new
      {
        UserName = u.Name,
        UserCity = ci.Name
      }).ToList();
  }
}
