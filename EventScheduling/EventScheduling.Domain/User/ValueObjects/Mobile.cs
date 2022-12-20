namespace EventScheduling.Domain.User.ValueObjects;

using System.Text.RegularExpressions;
using Exceptions;

public sealed class Mobile
{
  private const short ValueMaxLength = 15;
  private const short ValueMinLength = 10;

  private static readonly Regex MobileNumberRegex =
    new(@"^[0-9_\s:.-]*$", RegexOptions.Compiled, TimeSpan.FromMilliseconds(250));

  private readonly string _mobile;

  public Mobile(string mobile)
  {
    if (string.IsNullOrWhiteSpace(mobile))
    {
      throw new MobileNullOrEmptyException();
    }

    switch (mobile.Length)
    {
      case <= ValueMinLength:
        throw new MobileNumberMinLengthException(ValueMinLength);
      case > ValueMaxLength:
        throw new MobileNumberMaxLengthException(ValueMaxLength);
    }

    if (!HasValidCharacters(mobile))
    {
      throw new MobileNumberInvalidCharacterException();
    }

    _mobile = mobile;
  }

  public static implicit operator Mobile(string value)
  {
    return new Mobile(value);
  }

  public static implicit operator string(Mobile mobile)
  {
    return mobile._mobile;
  }

  private static bool HasValidCharacters(string value)
  {
    return MobileNumberRegex.IsMatch(value);
  }
}
