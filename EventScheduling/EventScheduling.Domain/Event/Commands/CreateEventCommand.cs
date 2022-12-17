namespace EventScheduling.Domain.Event.Commands;

using Enums;

public class CreateEventCommand
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public EventType EventType { get; set; }
  public DateTime StartTime { get; set; }
  public DateTime EndTime { get; set; }
  public Guid CityId { get; set; }
}
