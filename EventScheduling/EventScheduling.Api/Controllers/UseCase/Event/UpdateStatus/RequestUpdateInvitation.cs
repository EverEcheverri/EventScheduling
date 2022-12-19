namespace EventScheduling.Api.Controllers.UseCase.Event.UpdateStatus;

using System.ComponentModel.DataAnnotations;
using Domain.Event.Commands;
using Domain.Event.Enums;

public class RequestUpdateInvitation
{
  [Required]
  public Guid InvitationId { get; set; }

  [Required]
  public int Status { get; set; }

  internal UpdateInvitationCommand ToUpdateInvitationCommand()
  {
    return new UpdateInvitationCommand
    {
      InvitationId = InvitationId,
      Status = (InvitationStatus)Status
    };
  }
}
