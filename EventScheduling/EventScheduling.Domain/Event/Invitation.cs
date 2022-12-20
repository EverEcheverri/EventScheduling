using EventScheduling.Domain.Event.Enums;

namespace EventScheduling.Domain.Event;

public sealed class Invitation
{
  public Guid EventId { get; set; }
  private Invitation(Guid id, string email, InvitationStatus status, DateTime startTime, DateTime endTime)
  {
    Id = id;
    Email = email;
    Status = status;
    StartTime = startTime;
    EndTime = endTime;
  }

  public Guid Id { get; set; }
  public string Email { get; set; }
  public InvitationStatus Status { get; private set; }
  public DateTime StartTime { get; private set; }
  public DateTime EndTime { get; private set; }

  public static Invitation Build(Guid id, string email, InvitationStatus status, DateTime startTime, DateTime endTime)
  {
    var invitation = new Invitation(id, email, status, startTime, endTime);
    return invitation;
  }

  public void UpdateStatus(InvitationStatus status)
  {
    Status = status;
  }

  public void UpdateTime(DateTime startTime, DateTime endTime)
  {
    StartTime = startTime;
    EndTime = endTime;
  }
}
