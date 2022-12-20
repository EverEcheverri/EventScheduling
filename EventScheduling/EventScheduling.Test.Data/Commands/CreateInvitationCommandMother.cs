namespace EventScheduling.Test.Data.Commands;

using Domain.Event.Commands;
using Domain.Event.Enums;

public static class CreateInvitationCommandMother
{
  public static CreateInvitationCommand Create(
    string eventId = "a6daf43e-5eee-4473-a70c-6f890b20b79e",
    string invitationId = "aca6b8c6-45c8-408e-bf68-b6865dc0b729",
    InvitationStatus status = InvitationStatus.Pending,
    string email = "developer_one@yopmail.com"
  )
  {
    return new CreateInvitationCommand
    {
      EventId = Guid.Parse(eventId),
      InvitationId = Guid.Parse(invitationId),
      Status = status,
      Email = email
    };
  }
}