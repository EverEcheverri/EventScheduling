namespace EventScheduling.Domain.User;

using Enums;
using Exceptions;
using ValueObjects;

public sealed class User
{
  private User(Guid id, Email email, UserName name, Mobile mobile, UserRoles role, Guid cityId)
  {
    Id = id;
    Email = email;
    Name = name;
    Mobile = mobile;
    Role = role;
    CityId = cityId;
  }

  public Guid Id { get; set; }
  public Email Email { get; set; }
  public UserName Name { get; set; }
  public Mobile Mobile { get; set; }
  public UserRoles Role { get; set; }
  public Guid CityId { get; set; }

  public static User Build(Guid id, Email email, UserName name, Guid cityId, Mobile mobile, UserRoles role)
  {
    if (!Guid.TryParse(cityId.ToString(), out _))
    {
      throw new NoValidCityIdException();
    }

    var user = new User(id, email, name, mobile, role, cityId);
    return user;
  }
}
