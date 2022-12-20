namespace EventScheduling.Application.Invitation.Exceptions;

using Domain.SharedKernel.Exceptions;

public class InvitationDoesNotExistException : BusinessException
{
  public InvitationDoesNotExistException(Guid invitationId)
    : base($"the invitationId: {invitationId} does not exist")
  {
  }
}
