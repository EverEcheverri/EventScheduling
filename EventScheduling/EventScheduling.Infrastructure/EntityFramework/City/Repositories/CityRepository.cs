﻿namespace EventScheduling.Infrastructure.EntityFramework.City.Repositories;

using System.Linq.Expressions;
using Domain.City;
using Domain.City.Repositories;
using Microsoft.EntityFrameworkCore;

public class CityRepository : ICityRepository
{
  private readonly EventSchedulingDbContext _context;

  public CityRepository(EventSchedulingDbContext context)
  {
    _context = context;
  }

  public async Task SaveAsync(City city, CancellationToken cancellationToken)
  {
    cancellationToken.ThrowIfCancellationRequested();
    await _context.City.AddAsync(city, cancellationToken);
    await _context.SaveChangesAsync(cancellationToken);
  }

  public async Task<City?> GetByNameAsync(string name, CancellationToken cancellationToken)
  {
    cancellationToken.ThrowIfCancellationRequested();
    return await _context.City.FirstOrDefaultAsync(u => u.Name == name, cancellationToken);
  }

  public async Task<City?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
  {
    cancellationToken.ThrowIfCancellationRequested();
    return await _context.City.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
  }

  public async Task<City> GetAsync(Expression<Func<City, bool>> predicate, CancellationToken cancellationToken)
  {
    var city = await _context.City
      .Include(c => c.Users)
      .FirstOrDefaultAsync(predicate, cancellationToken);

    return city;
  }
}
