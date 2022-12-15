namespace EventScheduling.Domain.City;

using EventScheduling.Domain.SharedKernel.ValueObjects;
using SharedKernel.Exceptions;

public sealed class City
{
  private City(GuidValueObject id, string name, GuidValueObject countryId)
  {
    Id = id;
    Name = name;
    CountryId = countryId;
  }

  public GuidValueObject Id { get; set; }
  public string Name { get; set; }
  public GuidValueObject CountryId { get; set; }

  public static City Build(GuidValueObject id, string name, GuidValueObject countryId)
  {
    if (name == null)
    {
      throw new NameNullOrEmptyException();
    }

    var city = new City(id, name, countryId);
    return city;
  }
}
