namespace EventScheduling.Domain.City;

using Exceptions;
using SharedKernel.Exceptions;
using User;

public sealed class City
{
  private readonly List<User> _users = new();

  private City(Guid id, string name, Guid countryId, string timeZoneId)
  {
    Id = id;
    Name = name;
    CountryId = countryId;
    TimeZoneId = timeZoneId;
  }

  public Guid Id { get; }
  public string Name { get; }
  public Guid CountryId { get; }
  public string TimeZoneId { get; }
  public IReadOnlyCollection<User> Users => _users;

  public static City Build(Guid id, string name, Guid countryId, string timeZoneId)
  {
    if (string.IsNullOrWhiteSpace(name))
    {
      throw new NameNullOrEmptyException();
    }

    if (!Guid.TryParse(id.ToString(), out _))
    {
      throw new NoValidIdException();
    }

    if (string.IsNullOrWhiteSpace(timeZoneId))
    {
      throw new TimeZoneIdNullOrEmptyException();
    }

    var city = new City(id, name, countryId, timeZoneId);
    return city;
  }
}
