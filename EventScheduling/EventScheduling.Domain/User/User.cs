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

  public Guid Id { get; }
  public Email Email { get; }
  public UserName Name { get; }
  public Mobile Mobile { get; }
  public UserRoles Role { get; private set; }
  public Guid CityId { get; private set; }

  public static User Build(Guid id, Email email, UserName name, Guid cityId, Mobile mobile, UserRoles role)
  {
    if (!Guid.TryParse(cityId.ToString(), out _))
    {
      throw new NoValidCityIdException();
    }

    return new User(id, email, name, mobile, role, cityId);
  }
}
