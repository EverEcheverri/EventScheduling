namespace EventScheduling.Domain.Event.Commands;

using Enums;

public class CreateInvitationCommand
{
  public Guid EventId { get; set; }
  public Guid InvitationId { get; set; }
  public InvitationStatus Status { get; set; }
  public string Email { get; set; }
}
