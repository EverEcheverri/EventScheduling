using EventScheduling.Domain.Event.Commands;

namespace EventScheduling.Application.Invitation.Interfaces;

public interface IUpdateInvitation
{
  Task ExecuteAsync(UpdateInvitationCommand invitationCommand, CancellationToken cancellationToken);
}
