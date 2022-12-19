namespace EventScheduling.Domain.User.Commands;

using Enums;
using ValueObjects;

public class CreateUserCommand
{
  public Guid Id { get; set; }
  public Email Email { get; set; }
  public UserName Name { get; set; }
  public Guid CityId { get; set; }
  public Mobile Mobile { get; set; }
  public UserRoles Role { get; set; }
}
