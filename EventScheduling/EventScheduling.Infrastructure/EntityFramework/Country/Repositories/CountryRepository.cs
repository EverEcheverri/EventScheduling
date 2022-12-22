namespace EventScheduling.Infrastructure.EntityFramework.Country.Repositories;

using Domain.Country;
using Domain.Country.Repositories;
using Microsoft.EntityFrameworkCore;

public class CountryRepository : ICountryRepository
{
  private readonly EventSchedulingDbContext _context;

  public CountryRepository(EventSchedulingDbContext context)
  {
    _context = context;
  }

  public async Task<Country> GetByNameAsync(string name, CancellationToken cancellationToken)
  {
    cancellationToken.ThrowIfCancellationRequested();
    var countryResultAsync =
      await _context.Country
        .Include(c => c.Cities)
        .FirstOrDefaultAsync(co => co.Name.ToLower() == name.ToLower(),
          cancellationToken);

    return countryResultAsync;
  }
}
