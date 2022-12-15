namespace EventScheduling.Domain.User;

using Enums;
using ValueObjects;

public sealed class User
{
  private User(Email email, UserName name, Guid cityId, string mobile, UserRoles role)
  {
    Email = email;
    Name = name;
    CityId = cityId;
    Mobile = mobile;
    Role = role;
  }

  public Email Email { get; set; }
  public UserName Name { get; set; }
  public Guid CityId { get; set; }
  public string Mobile { get; set; }
  public UserRoles Role { get; set; }

  public static User Build(Email email, UserName name, Guid cityId, string mobile, UserRoles role)
  {
    var user = new User(email, name, cityId, mobile, role);
    return user;
  }
}
