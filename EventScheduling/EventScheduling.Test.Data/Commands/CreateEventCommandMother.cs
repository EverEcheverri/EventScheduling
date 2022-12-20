namespace EventScheduling.Test.Data.Commands;

using Domain.Event.Commands;
using Domain.Event.Enums;

public static class CreateEventCommandMother
{
  public static CreateEventCommand Create(
  string id = "a614093c-1b62-4db2-9120-4a84e4ebbd1d",
  string name = "event test",
  string description = "event test description",
  EventType eventType = EventType.Face2Face,
  DateTime startTimeUtc = default,
  DateTime endTimeUtc = default,
  string cityId = "5ebf0600-c390-4b16-945d-eb0e734cf51c")
  {
    if (startTimeUtc == default)
    {
      startTimeUtc = DateTime.Parse("2022-01-01T13:00:00.0000000Z").ToUniversalTime();
    }

    if (endTimeUtc == default)
    {
      endTimeUtc = DateTime.Parse("2022-01-01T14:00:00.0000000Z").ToUniversalTime();
    }

    return new CreateEventCommand
    {
      Id = Guid.Parse(id),
      Name = name,
      Description = description,
      EventType = eventType,
      StartTimeUtc = startTimeUtc,
      EndTimeUtc = endTimeUtc,
      CityId = Guid.Parse(cityId)
    };
  }
}
