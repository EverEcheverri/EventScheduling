namespace EventScheduling.Domain.Test.User.ValueObjects;

using EventScheduling.Domain.User.Exceptions;
using EventScheduling.Domain.User.ValueObjects;
using Xunit;

public class UserNameTest
{
  [Fact]
  public void UserName_Create_ValueObject()
  {
    var userName = new UserName("developer_one");

    Assert.NotNull(userName);
    Assert.Equal("developer_one", userName);
  }

  [Fact]
  public void UserName_Implicit_ValueObject()
  {
    var userName = (UserName)"developer_one";

    Assert.NotNull(userName);
    Assert.Equal("developer_one", userName);
  }

  [Fact]
  public void UserName_Empty_Throws_UserNameNullOrEmptyException()
  {
    var exception = Assert.Throws<UserNameNullOrEmptyException>(() => new UserName(string.Empty));
    Assert.Equal("User name is null or empty", exception.Message);
  }

  [Fact]
  public void UserName_Empty_Throws_UserNameMaxLengthException()
  {
    var userName = $"{new string('a', 256)}";
    var exception = Assert.Throws<UserNameMaxLengthException>(() => new UserName(userName));
    Assert.Equal("User name max length exceeded", exception.Message);
  }
}
