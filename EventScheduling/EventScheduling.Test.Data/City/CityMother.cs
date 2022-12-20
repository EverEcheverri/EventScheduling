namespace EventScheduling.Test.Data.City;

using Domain.City;

public static class CityMother
{
  public static City Create(
    string id = "5ebf0600-c390-4b16-945d-eb0e734cf51c",
    string name = "Medellin",
    string countryId = "8217f508-c17d-431e-9cf0-05ca8984971b",
    string timeZoneId = "America/Bogota")
  {
    var user = City.Build(
      Guid.Parse(id),
      name,
      Guid.Parse(countryId),
      timeZoneId
    );

    return user;
  }
}
