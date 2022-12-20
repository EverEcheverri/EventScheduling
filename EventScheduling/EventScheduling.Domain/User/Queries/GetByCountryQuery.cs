using EventScheduling.Domain.User.Enums;
using EventScheduling.Domain.User.ValueObjects;

namespace EventScheduling.Domain.User.Queries;

public class GetByCountryQuery
{
  public UserName UserName { get; set; }
  public Email Email { get; set; }
  public UserRoles Role { get; set; }
  public string CityName { get; set; }
}
