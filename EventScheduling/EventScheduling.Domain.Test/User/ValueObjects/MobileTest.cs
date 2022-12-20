using EventScheduling.Domain.User.ValueObjects;

namespace EventScheduling.Domain.Test.User.ValueObjects;

using EventScheduling.Domain.User.Exceptions;
using Newtonsoft.Json.Linq;
using Xunit;

public class MobileTest
{
  [Fact]
  public void Mobile_Create_ValueObject()
  {
    var mobile = new Mobile("111 1111111");

    Assert.NotNull(mobile);
    Assert.Equal("111 1111111", mobile);
  }

  [Fact]
  public void Mobile_Implicit_ValueObject()
  {
    var mobile = (Mobile)"111 1111111";

    Assert.NotNull(mobile);
    Assert.Equal("111 1111111", mobile);
  }

  [Fact]
  public void Mobile_Empty_Throws_MobileNullOrEmptyException()
  {
    var exception = Assert.Throws<MobileNullOrEmptyException>(() => new Mobile(string.Empty));
    Assert.Equal("Mobile is null or empty", exception.Message);
  }

  [Fact]
  public void Mobile_Throws_MobileNumberMinLengthException()
  {
    var mobile = $"{new string('1', 10)}";
    var exception = Assert.Throws<MobileNumberMinLengthException>(() => new Mobile(mobile));
    Assert.Equal($"The mobile number must be at least {mobile.Length} characters", exception.Message);
  }

  [Fact]
  public void Mobile_Throws_MobileNumberMaxLengthException()
  {
    var mobile = $"{new string('1', 16)}";
    var exception = Assert.Throws<MobileNumberMaxLengthException>(() => new Mobile(mobile));
    Assert.Equal($"Mobile number max length exceeded 15 characters", exception.Message);
  }

  [Fact]
  public void Mobile_MobileNumberInvalidCharacterException()
  {
    var mobile = $"{new string('a', 15)}";
    var exception = Assert.Throws<MobileNumberInvalidCharacterException>(() => new Mobile(mobile));
    Assert.Equal("Mobile number contains invalid character", exception.Message);
  }
}
