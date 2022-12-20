namespace EventScheduling.Api.Controllers.UseCase.Event.Create;

using System.ComponentModel.DataAnnotations;
using System.Globalization;
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
    var startTime = DateTime.Parse(StartTime.ToString(CultureInfo.InvariantCulture));
    var endTime = DateTime.Parse(EndTime.ToString(CultureInfo.InvariantCulture));
    return new CreateEventCommand
    {
      Id = Guid.NewGuid(),
      Name = Name,
      Description = Description,
      EventType = EventType,
      StartTimeUtc = startTime.ToUniversalTime(),
      EndTimeUtc = endTime.ToUniversalTime(),
      CityId = CityId
    };
  }
}
