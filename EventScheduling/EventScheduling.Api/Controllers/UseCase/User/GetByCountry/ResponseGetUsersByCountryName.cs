namespace EventScheduling.Api.Controllers.UseCase.User.GetByCountry;

using Domain.User;

public class ResponseGetUsersByCountryName
{
  public string Email { get; set; }
  public string Name { get; set; }
  public Guid CityId { get; set; }
  public string Mobile { get; set; }
  public string Role { get; set; }
  internal static ICollection<ResponseGetUsersByCountryName> Map(IEnumerable<User> mediaUrlInfoDto)
  {
    return mediaUrlInfoDto.Select(u => new ResponseGetUsersByCountryName
    {
      Email = u.Email,
      Name = u.Name,
      CityId = u.CityId,
      Mobile = u.Mobile,
      Role = u.Role.ToString()
    }).ToList();
  }
}
