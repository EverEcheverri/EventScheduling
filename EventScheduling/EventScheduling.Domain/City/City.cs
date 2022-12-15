namespace EventScheduling.Domain.City;

using Exceptions;
using SharedKernel.Exceptions;

public sealed class City
{
  private City(Guid id, string name, Guid countryId)
  {
    Id = id;
    Name = name;
    CountryId = countryId;
  }

  public Guid Id { get; set; }
  public string Name { get; set; }
  public Guid CountryId { get; set; }

  public static City Build(Guid id, string name, Guid countryId)
  {
    if (name == null)
    {
      throw new NameNullOrEmptyException();
    }

    if (!Guid.TryParse(countryId.ToString(), out _))
    {
      throw new NoValidCountryIdException();
    }

    var city = new City(id, name, countryId);
    return city;
  }
}
