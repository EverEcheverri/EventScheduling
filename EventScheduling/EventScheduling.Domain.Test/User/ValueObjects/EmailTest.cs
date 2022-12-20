namespace EventScheduling.Domain.Test.User.ValueObjects;

using Domain.User.Exceptions;
using Domain.User.ValueObjects;
using Xunit;

public class EmailTest
{
  [Fact]
  public void Email_Create_ValueObject()
  {
    var email = new Email("developer_one@yopmail.com");

    Assert.NotNull(email);
    Assert.Equal("developer_one@yopmail.com", email);
  }

  [Fact]
  public void Email_Implicit_ValueObject()
  {
    var email = (Email)"developer_one@yopmail.com";

    Assert.NotNull(email);
    Assert.Equal("developer_one@yopmail.com", email);
  }

  [Fact]
  public void Email_Empty_Throws_EmailNullOrEmptyException()
  {
    var exception = Assert.Throws<EmailNullOrEmptyException>(() => new Email(string.Empty));
    Assert.Equal("Email is null or empty", exception.Message);
  }

  [Fact]
  public void Email_Throws_EmailMaxLengthException()
  {
    var email = $"{new string('a', 255)}";
    var exception = Assert.Throws<EmailMaxLengthException>(() => new Email(email));
    Assert.Equal("Email max length exceeded 254 characters", exception.Message);
  }

  [Theory]
  [InlineData("developer_one")]
  [InlineData("developer_one@yopmail")]
  [InlineData("developer_one_@@yopmail.com")]
  public void Email_Throws_EmailInvalidPatternException(string email)
  {
    var exception = Assert.Throws<EmailInvalidPatternException>(() => new Email(email));
    Assert.Equal("Email invalid pattern", exception.Message);
  }
}
