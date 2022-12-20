namespace EventScheduling.Test.Data.Commands;

using Domain.User.Commands;
using Domain.User.Enums;

public static class CreateUserCommandMother
{
  public static CreateUserCommand Create(
    string id = "7603871d-a355-41db-bcf2-e98b580b370c",
    string email = "developer_one@yopmail.com",
    string name = "developer_one",
    string cityId = "5ebf0600-c390-4b16-945d-eb0e734cf51c",
    string mobile = "111 1111111",
    UserRoles role = UserRoles.Developer
  )
  {
    return new CreateUserCommand
    {
      Id = Guid.Parse(id),
      Email = email,
      Name = name,
      CityId = Guid.Parse(cityId),
      Mobile = mobile,
      Role = role
    };
  }
}
