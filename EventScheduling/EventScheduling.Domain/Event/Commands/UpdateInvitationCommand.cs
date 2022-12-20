using EventScheduling.Domain.Event.Enums;

namespace EventScheduling.Domain.Event.Commands;

public class UpdateInvitationCommand
{
  public Guid InvitationId { get; set; }
  public InvitationStatus Status { get; set; }
}
