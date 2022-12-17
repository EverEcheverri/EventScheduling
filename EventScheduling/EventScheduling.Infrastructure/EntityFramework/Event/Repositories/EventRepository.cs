namespace EventScheduling.Infrastructure.EntityFramework.Event.Repositories;

using Domain.Event;
using Domain.Event.Repositories;
using Microsoft.EntityFrameworkCore;

public class EventRepository : IEventRepository
{
  private readonly EventSchedulingDbContext _context;

  public EventRepository(EventSchedulingDbContext context)
  {
    _context = context;
  }

  public async Task SaveAsync(Event @event, CancellationToken cancellationToken)
  {
    await _context.Event.AddAsync(@event, cancellationToken);
    await _context.SaveChangesAsync(cancellationToken);
  }

  public async Task<Event?> GetByNameAsync(string eventName, CancellationToken cancellationToken)
  {
    return await _context.Event.FirstOrDefaultAsync(u => u.Name == eventName, cancellationToken);
  }
}
