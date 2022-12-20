namespace EventScheduling.Domain.Test.User;

using Domain.User.Enums;
using EventScheduling.Test.Data.User;
using Xunit;

public class UserTest
{
  [Fact]
  public void User_Builds_Successfully()
  {
    // Arrange

    // Act
    var user = UserMother.Create();

    // Assert
    Assert.NotNull(user);
    Assert.Equal(Guid.Parse("b2181377-6a51-446e-afb6-07f1402834e3"), user.Id);
    Assert.Equal("developer_one@yopmail.com", user.Email);
    Assert.Equal("developer_one", user.Name);
    Assert.Equal(Guid.Parse("5ebf0600-c390-4b16-945d-eb0e734cf51c"), user.CityId);
    Assert.Equal("111 1111111", user.Mobile);
    Assert.Equal(UserRoles.Developer, user.Role);
  }
}
