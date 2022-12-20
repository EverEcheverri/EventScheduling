namespace EventScheduling.Test.Data.Commands;

using Domain.Event.Commands;

public static class ResponseGetCityLocationMother
{
  public static ResponseGetCityLocation Create(
    string utcOffset = "Medellin",
    string latitude = "4.600",
    string longitude = "-74.083")
  {
    return new ResponseGetCityLocation
    {
      location = new Location { utc_offset = utcOffset, lat = latitude, lon = longitude },
      request = new Request()
    };
  }
}
