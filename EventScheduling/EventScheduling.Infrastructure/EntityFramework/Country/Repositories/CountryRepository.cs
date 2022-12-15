namespace EventScheduling.Infrastructure.EntityFramework.Country.Repositories;

using System.Diagnostics.CodeAnalysis;
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
    var country =
      await _context.Country
        .Include(c => c.Cities)
        .Where(c => c.Name.ToLower() == name.ToLower())
        .SingleOrDefaultAsync(cancellationToken);

    return country;
  }
}
