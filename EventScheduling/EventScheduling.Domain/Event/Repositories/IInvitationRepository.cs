namespace EventScheduling.Domain.Event.Repositories;

public interface IInvitationRepository
{
  Task SaveAsync(Invitation invitation, CancellationToken cancellationToken);
  Task<Invitation> GetByIdAsync(Guid invitationId, CancellationToken cancellationToken);
  Task<Invitation> GetByEventIdAndEmailAsync(Guid eventId, string email, CancellationToken cancellationToken);
  Task UpdateAsync(Invitation invitation, CancellationToken cancellationToken);
}
