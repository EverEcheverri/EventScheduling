namespace EventScheduling.Api.Controllers.UseCase.Event.Create;

using System.ComponentModel.DataAnnotations;
using Domain.Event.Commands;
using Domain.Event.Enums;

public class RequestCreateEvent
{
  [Required]
  public string Name { get; set; }

  [Required]
  public string Description { get; set; }

  [Required]
  public EventType EventType { get; set; }

  [Required]
  public DateTime StartTime { get; set; }

  [Required]
  public DateTime EndTime { get; set; }

  [Required]
  public Guid CityId { get; set; }


  internal CreateEventCommand ToCreateEventCommand()
  {
    return new CreateEventCommand
    {
      Id = Guid.NewGuid(),
      Name = Name,
      Description = Description,
      EventType = EventType,
      StartTime = StartTime,
      EndTime = EndTime,
      CityId = CityId
    };
  }
}
