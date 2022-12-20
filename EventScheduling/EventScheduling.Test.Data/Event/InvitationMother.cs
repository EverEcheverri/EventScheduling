namespace EventScheduling.Test.Data.Event;

using Domain.Event;
using Domain.Event.Enums;

public static class InvitationMother
{
  public static Invitation Create(
    string id = "aca6b8c6-45c8-408e-bf68-b6865dc0b729",
    string email = "developer_one@yopmail.com",
    InvitationStatus status = InvitationStatus.Pending,
    DateTime startTime = default,
    DateTime endTime = default
  )
  {
    if (startTime == default)
    {
      startTime = DateTime.Parse("2022-01-01T13:00:00.0000000Z").ToUniversalTime();
    }

    if (endTime == default)
    {
      endTime = DateTime.Parse("2022-01-01T14:00:00.0000000Z").ToUniversalTime();
    }

    return Invitation.Build(
      Guid.Parse(id),
      email,
      status,
      startTime,
      endTime);
  }
}
