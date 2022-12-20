namespace EventScheduling.Domain.User.ValueObjects;

using Exceptions;

public sealed class UserName
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
}
