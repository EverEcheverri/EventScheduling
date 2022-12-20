namespace EventScheduling.Test.Data.User;

using Domain.User;
using Domain.User.Enums;

public static class UserMother
{
  public static User Create(
    string id ="b2181377-6a51-446e-afb6-07f1402834e3",
    string email ="developer_one@yopmail.com",
    string name ="developer_one",
    string cityId ="5ebf0600-c390-4b16-945d-eb0e734cf51c",
    string mobile ="111 1111111",
    UserRoles role = UserRoles.Developer)
  {
    var user = User.Build(
      Guid.Parse(id),
      email,
      name,
      Guid.Parse(cityId),
      mobile,
      role);
    
    return user;
  }
}
