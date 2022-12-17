namespace EventScheduling.Domain.City;

using Exceptions;
using SharedKernel.Exceptions;

public sealed class City
{
  private City(Guid id, string name, Guid countryId, string timeZoneId)
  {
    Id = id;
    Name = name;
    CountryId = countryId;
    TimeZoneId = timeZoneId;
  }

  public Guid Id { get; set; }
  public string Name { get; set; }
  public Guid CountryId { get; set; }
  public string TimeZoneId { get; set; }

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
