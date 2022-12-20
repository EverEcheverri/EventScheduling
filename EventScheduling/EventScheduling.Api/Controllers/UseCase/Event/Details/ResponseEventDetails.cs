namespace EventScheduling.Api.Controllers.UseCase.Event.Details;

using Domain.Event;

public class ResponseEventDetails
{
  public string Email { get; set; }
  public string Status { get; set; }

  internal static ICollection<ResponseEventDetails> Map(Event @event)
  {
    return @event.Invitation.Select(i => new ResponseEventDetails
    {
      Email = i.Email,
      Status = i.Status.ToString()
    }).ToList();
  }
}
