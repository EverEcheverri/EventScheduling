namespace EventScheduling.Domain.User;

using Enums;

public sealed class User
{
  private User(string email, string name, Guid cityId, string mobile, UserRoles role)
  {
    Email = email;
    Name = name;
    CityId = cityId;
    Mobile = mobile;
    Role = role;
  }

  public string Email { get; set; }
  public string Name { get; set; }
  public Guid CityId { get; set; }
  public string Mobile { get; set; }
  public UserRoles Role { get; set; }

  public static User Build(string email, string name, Guid cityId, string mobile, UserRoles role)
  {
    var user = new User(email, name, cityId, mobile, role);
    return user;
  }
}
