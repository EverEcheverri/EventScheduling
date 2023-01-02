namespace EventScheduling.Domain.Country;

using City;
using SharedKernel.Exceptions;

public sealed class Country
{
  private readonly List<City> _cities = new();

  private Country(Guid id, string name)
  {
    Id = id;
    Name = name;
  }

  public Guid Id { get; }
  public string Name { get; }
  public IReadOnlyCollection<City> Cities => _cities;

  public static Country Build(Guid id, string name)
  {
    if (!Guid.TryParse(id.ToString(), out _))
    {
      throw new NoValidIdException();
    }

    if (name == null)
    {
      throw new NameNullOrEmptyException();
    }

    var city = new Country(id, name);
    return city;
  }
}
