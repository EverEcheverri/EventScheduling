namespace EventScheduling.Domain.City;

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

    if (!Guid.TryParse(id.ToString(), out _))
    {
      throw new NoValidIdException();
    }

    var city = new City(id, name, countryId);
    return city;
  }
}
