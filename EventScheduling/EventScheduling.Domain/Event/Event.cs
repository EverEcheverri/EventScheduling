namespace EventScheduling.Domain.Event;

using Enums;

public sealed class Event
{
  private Event(Guid id, string name, string description, EventType eventType, DateTime startTimeUtc,
    DateTime endTimeUtc, Guid cityId, Guid countryId, string utcOffset, double latitude, double longitude)
  {
    Id = id;
    Name = name;
    Description = description;
    EventType = eventType;
    StartTimeUtc = DateTime.SpecifyKind(startTimeUtc, DateTimeKind.Utc);
    EndTimeUtc = DateTime.SpecifyKind(endTimeUtc, DateTimeKind.Utc);
    CityId = cityId;
    CountryId = countryId;
    UtcOffset = utcOffset;
    Latitude = latitude;
    Longitude = longitude;
  }

  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public EventType EventType { get; set; }
  public DateTime StartTimeUtc { get; set; }
  public DateTime EndTimeUtc { get; set; }
  public Guid CityId { get; set; }
  public Guid CountryId { get; set; }
  public string UtcOffset { get; set; }
  public double Latitude { get; set; }
  public double Longitude { get; set; }

  public static Event Build(Guid id, string name, string description, EventType eventType, DateTime startTimeUtc,
    DateTime endTimeUtc, Guid cityId, Guid countryId, string utcOffset, double latitude, double longitude)
  {
    var newEvent = new Event(id, name, description, eventType, startTimeUtc, endTimeUtc, cityId, countryId, utcOffset,
      latitude, longitude);
    return newEvent;
  }
}
