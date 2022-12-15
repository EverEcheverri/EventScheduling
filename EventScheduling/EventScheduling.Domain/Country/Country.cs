namespace EventScheduling.Domain.Country;

using City;
using EventScheduling.Domain.SharedKernel.ValueObjects;
using SharedKernel.Exceptions;

public sealed class Country
{
  private readonly List<City> _cities = new();

  private Country(GuidValueObject id, string name)
  {
    Id = id;
    Name = name;
  }

  public GuidValueObject Id { get; set; }
  public string Name { get; set; }
  public IReadOnlyCollection<City> Cities => _cities;

  public static Country Build(GuidValueObject id, string name)
  {
    if (name == null)
    {
      throw new NameNullOrEmptyException();
    }

    var city = new Country(id, name);
    return city;
  }
}
