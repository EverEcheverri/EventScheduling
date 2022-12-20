using EventScheduling.Domain.User.ValueObjects;

namespace EventScheduling.Domain.User.Queries;

public class GetWithCityQuery
{
  public Email Email { get; set; }
  public string TimeZoneId { get; set; }
}
