namespace EventScheduling.Test.Data.Event;

using Domain.Event;
using Domain.Event.Enums;

public static class EventMother
{
  public static Event Create(
    string id = "a6daf43e-5eee-4473-a70c-6f890b20b79e",
    string name = "event test",
    string description = "description event test",
    EventType eventType = EventType.Face2Face,
    DateTime startTimeUtc = default,
    DateTime endTimeUtc = default,
    string cityId = "5ebf0600-c390-4b16-945d-eb0e734cf51c",
    string countryId = "8217f508-c17d-431e-9cf0-05ca8984971b",
    string utcOffset = "-5.0",
    double latitude = 6.291,
    double longitude = -75.536
  )
  {
    if (startTimeUtc == default)
    {
      startTimeUtc = DateTime.Parse("2022-01-01T18:00:00.0000000Z").ToUniversalTime();
    }

    if (endTimeUtc == default)
    {
      endTimeUtc = DateTime.Parse("2022-01-01T19:00:00.0000000Z").ToUniversalTime();
    }

    return Event.Build(
      Guid.Parse(id),
      name,
      description,
      eventType,
      startTimeUtc,
      endTimeUtc,
      Guid.Parse(cityId),
      Guid.Parse(countryId),
      utcOffset,
      latitude,
      longitude
    );
  }
}
