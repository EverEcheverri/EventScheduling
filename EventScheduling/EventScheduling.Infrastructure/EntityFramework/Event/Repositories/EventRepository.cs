namespace EventScheduling.Infrastructure.EntityFramework.Event.Repositories;

using Domain.Event;
using Domain.Event.Repositories;
using Microsoft.EntityFrameworkCore;

public class EventRepository : IEventRepository
{
  private readonly EventSchedulingDbContext _context;
  private readonly IInvitationRepository _invitationRepository;

  public EventRepository(EventSchedulingDbContext context, IInvitationRepository invitationRepository)
  {
    _context = context;
    _invitationRepository = invitationRepository;
  }

  public async Task SaveAsync(Event @event, CancellationToken cancellationToken)
  {
    await _context.Event.AddAsync(@event, cancellationToken);
    await _context.SaveChangesAsync(cancellationToken);
  }

  public async Task UpdateAsync(Event @event, CancellationToken cancellationToken)
  {
    try
    {
      foreach (var invitation in @event.Invitation)
      {
        var invitationExist =
          await _invitationRepository.GetByIdAsync(invitation.Id, cancellationToken);

        _context.Entry(invitation).State = invitationExist == null
          ? EntityState.Added
          : EntityState.Modified;
      }

      _context.Entry(@event).State = EntityState.Modified;
      await _context.SaveChangesAsync(cancellationToken);
    }
    catch (Exception ex)
    {
      while (ex.InnerException != null)
      {
        ex = ex.InnerException;
      }

      Console.WriteLine(ex.Message);
      throw;
    }
  }

  public async Task<Event> GetByIdAsync(Guid eventId, CancellationToken cancellationToken)
  {
    return (await _context.Event
      .FirstOrDefaultAsync(u => u.Id == eventId, cancellationToken))!;
  }

  public async Task<Event> GetByIdWithInvitationsAsync(Guid eventId, CancellationToken cancellationToken)
  {
    return (await _context.Event
      .Include(e => e.Invitation)
      .FirstOrDefaultAsync(u => u.Id == eventId, cancellationToken))!;
  }

  public async Task<Event?> GetByNameAsync(string eventName, CancellationToken cancellationToken)
  {
    return await _context.Event.FirstOrDefaultAsync(u => u.Name == eventName, cancellationToken);
  }
}
