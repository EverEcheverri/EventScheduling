namespace EventScheduling.Api.Controllers.UseCase.User.GetByCountry;

using Domain.User.Queries;

public class ResponseGetUsersByCountryName
{
  public string UserName { get; set; }
  public string Email { get; set; }
  public string Role { get; set; }
  public string CityName { get; set; }

  internal static ICollection<ResponseGetUsersByCountryName> Map(IEnumerable<GetByCountryQuery> users)
  {
    return users.Select(u => new ResponseGetUsersByCountryName
    {
      UserName = u.UserName,
      Email = u.Email,
      Role = u.Role.ToString(),
      CityName = u.CityName
    }).ToList();
  }
}
