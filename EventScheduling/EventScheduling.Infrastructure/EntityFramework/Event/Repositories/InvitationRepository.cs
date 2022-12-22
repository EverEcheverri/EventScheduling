namespace EventScheduling.Infrastructure.EntityFramework.Event.Repositories;

using Domain.Event;
using Domain.Event.Repositories;
using Microsoft.EntityFrameworkCore;

public class InvitationRepository : IInvitationRepository
{
  private readonly EventSchedulingDbContext _context;

  public InvitationRepository(EventSchedulingDbContext context)
  {
    _context = context;
  }

  public Task SaveAsync(Invitation invitation, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public async Task<Invitation> GetByIdAsync(Guid invitationId, CancellationToken cancellationToken)
  {
    cancellationToken.ThrowIfCancellationRequested();
    return await _context.Invitation.FirstOrDefaultAsync(i => i.Id == invitationId, cancellationToken);
  }

  public async Task<Invitation> GetByEventIdAndEmailAsync(Guid eventId, string email,
    CancellationToken cancellationToken)
  {
    cancellationToken.ThrowIfCancellationRequested();
    return await _context.Invitation.FirstOrDefaultAsync(i => i.EventId == eventId && i.Email == email,
      cancellationToken);
  }

  public async Task UpdateAsync(Invitation invitation, CancellationToken cancellationToken)
  {
    cancellationToken.ThrowIfCancellationRequested();
    _context.Entry(invitation).State = EntityState.Modified;
    await _context.SaveChangesAsync(cancellationToken);
  }
}
