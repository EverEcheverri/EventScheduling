namespace EventScheduling.Domain.User.ValueObjects;

using Exceptions;
using SharedKernel;

public sealed class UserName : ValueObject
{
  private const short ValueMaxLength = 255;
  private readonly string _userName;

  public UserName(string userName)
  {
    if (string.IsNullOrWhiteSpace(userName))
    {
      throw new UserNameNullOrEmptyException();
    }

    if (userName.Length > ValueMaxLength)
    {
      throw new UserNameMaxLengthException();
    }

    _userName = userName;
  }

  public static implicit operator UserName(string value)
  {
    return new UserName(value);
  }

  public static implicit operator string(UserName userName)
  {
    return userName._userName;
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return _userName;
  }
}
