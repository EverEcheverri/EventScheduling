namespace EventScheduling.Infrastructure.EntityFramework.User.Repositories;

using Domain.User;
using Domain.User.Queries;
using Domain.User.Repositories;
using Domain.User.ValueObjects;
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

  public async Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken)
  {
    cancellationToken.ThrowIfCancellationRequested();

    return await _context.User
      .FirstOrDefaultAsync(u => u.Email == email, cancellationToken: cancellationToken);
  }
  public async Task<GetWithCityQuery> GetWithTimeZoneIdAsync(Email email, CancellationToken cancellationToken)
  {
    var query = from u in _context.User
                join ci in _context.City
                  on u.CityId equals ci.Id
                where u.Email == email
                select new GetWithCityQuery
                {
                  Email = u.Email,
                  TimeZoneId = ci.TimeZoneId
                };

    var userWithTimeZoneId = await query.SingleOrDefaultAsync(cancellationToken).ConfigureAwait(false);

    return userWithTimeZoneId;
  }
  public async Task<ICollection<GetByCountryQuery>> GetByCountryIdAsync(Guid countryId,
    CancellationToken cancellationToken)
  {
    var query = from u in _context.User
                join ci in _context.City
                  on u.CityId equals ci.Id
                where ci.CountryId == countryId
                select new GetByCountryQuery
                {
                  UserName = u.Name,
                  Email = u.Email,
                  Role = u.Role,
                  CityName = ci.Name
                };

    var userByCountry = await query.ToListAsync(cancellationToken).ConfigureAwait(false);

    return userByCountry;
  }
}
