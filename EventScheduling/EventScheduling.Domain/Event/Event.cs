namespace EventScheduling.Domain.Event;

using Enums;

public sealed class Event
{
    private readonly List<Invitation> _invitation = new();

    public Event()
    {

    }
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

    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public EventType EventType { get; }
    public DateTime StartTimeUtc { get; }
    public DateTime EndTimeUtc { get; }
    public Guid CityId { get; }
    public Guid CountryId { get; }
    public string UtcOffset { get; }
    public double Latitude { get; }
    public double Longitude { get; }
    public IReadOnlyCollection<Invitation> Invitation => _invitation;

    public static Event Build(Guid id, string name, string description, EventType eventType, DateTime startTimeUtc,
      DateTime endTimeUtc, Guid cityId, Guid countryId, string utcOffset, double latitude, double longitude)
    {
        var newEvent = new Event(id, name, description, eventType, startTimeUtc, endTimeUtc, cityId, countryId, utcOffset,
          latitude, longitude);
        return newEvent;
    }

    public void AddInvitation(Invitation invitation)
    {
        _invitation.Add(invitation);
    }
}
