namespace EventScheduling.Infrastructure.EntityFramework.City.Repositories;

using Domain.City;
using Domain.City.Repositories;

public class CityRepository : ICityRepository
{
  private readonly EventSchedulingDbContext _context;

  public CityRepository(EventSchedulingDbContext context)
  {
    _context = context;
  }

  public async Task SaveAsync(City city, CancellationToken cancellationToken)
  {
    await _context.City.AddAsync(city, cancellationToken);
    await _context.SaveChangesAsync(cancellationToken);
  }
}
