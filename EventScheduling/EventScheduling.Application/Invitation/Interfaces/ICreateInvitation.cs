namespace EventScheduling.Application.Invitation.Interfaces;

using Domain.Event.Commands;

public interface ICreateInvitation
{
  Task ExecuteAsync(CreateInvitationCommand invitationCommand, CancellationToken cancellationToken);
}
