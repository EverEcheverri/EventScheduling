namespace EventScheduling.Domain.User.ValueObjects;

using Exceptions;

public sealed class UserName
{
  private const short ValueMaxLength = 255;

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
  }

  public static implicit operator UserName(string value)
  {
    return new UserName(value);
  }
}
