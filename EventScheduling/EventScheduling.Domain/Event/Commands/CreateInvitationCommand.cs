namespace EventScheduling.Domain.Event.Commands;

public class CreateInvitationCommand
{
  public Guid EventId { get; set; }
  public Guid Id { get; set; }
  public string Email { get; set; }
}
