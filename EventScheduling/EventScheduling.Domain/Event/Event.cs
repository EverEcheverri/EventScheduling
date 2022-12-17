namespace EventScheduling.Domain.Event;

using Enums;

public sealed class Event
{
  private Event(Guid id, string name, string description, EventType eventType, DateTime startTime,
    DateTime endTime, Guid cityId, Guid countryId, double latitude, double longitude)
  {
    Id = id;
    Name = name;
    Description = description;
    EventType = eventType;
    StartTime = DateTime.SpecifyKind(startTime, DateTimeKind.Local);
    EndTime = DateTime.SpecifyKind(endTime, DateTimeKind.Local);
    CityId = cityId;
    CountryId = countryId;
    Latitude = latitude;
    Longitude = longitude;
  }

  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public EventType EventType { get; set; }
  public DateTime StartTime { get; set; }
  public DateTime EndTime { get; set; }
  public Guid CityId { get; set; }
  public Guid CountryId { get; set; }
  public double Latitude { get; set; }
  public double Longitude { get; set; }

  public static Event Build(Guid id, string name, string description, EventType eventType, DateTime startTime,
    DateTime endTime, Guid cityId, Guid countryId, double latitude, double longitude)
  {
    var newEvent = new Event(id, name, description, eventType, startTime, endTime, cityId, countryId, latitude, longitude);
    return newEvent;
  }
}
