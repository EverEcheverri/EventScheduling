namespace EventScheduling.Application.Invitation.UseCases;

using Domain.Event.Commands;
using Domain.Event.Repositories;
using Exceptions;
using Interfaces;

public class UpdateInvitationUseCase : IUpdateInvitation
{
  private readonly IInvitationRepository _invitationRepository;

  public UpdateInvitationUseCase(IInvitationRepository invitationRepository)
  {
    _invitationRepository = invitationRepository;
  }

  public async Task ExecuteAsync(UpdateInvitationCommand invitationCommand, CancellationToken cancellationToken)
  {
    cancellationToken.ThrowIfCancellationRequested();
    var invitation = await _invitationRepository.GetByIdAsync(invitationCommand.InvitationId, cancellationToken);
    if (invitation == null)
    {
      throw new InvitationDoesNotExistException(invitationCommand.InvitationId);
    }

    invitation.UpdateStatus(invitationCommand.Status);
    await _invitationRepository.UpdateAsync(invitation, cancellationToken);
  }
}
