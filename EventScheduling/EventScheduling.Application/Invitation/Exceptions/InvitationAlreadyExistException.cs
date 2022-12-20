using EventScheduling.Domain.SharedKernel.Exceptions;

namespace EventScheduling.Application.Invitation.Exceptions;

public class InvitationAlreadyExistException: BusinessException
{
  public InvitationAlreadyExistException(Guid invitationId)
    : base($"the invitationId: {invitationId} already exist")
  {
  }
}
