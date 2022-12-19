namespace EventScheduling.Api.Controllers.UseCase.Event.CreateInvitation;

using System.ComponentModel.DataAnnotations;
using Domain.Event.Commands;

public class RequestCreateInvitation
{
  [Required]
  public Guid EventId { get; set; }

  [Required]
  public string Email { get; set; }

  internal CreateInvitationCommand ToCreateInvitationCommand()
  {
    return new CreateInvitationCommand
    {
      InvitationId = Guid.NewGuid(),
      EventId = EventId,
      Email = Email
    };
  }
}
