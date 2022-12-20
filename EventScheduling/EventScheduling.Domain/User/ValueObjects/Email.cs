namespace EventScheduling.Domain.User.ValueObjects;

using System.Text.RegularExpressions;
using Exceptions;

public sealed class Email
{
  private const short EmailMaxLength = 254;
  private readonly string _email;

  private static readonly Regex EmailRegex =
    new(@"^[A-Z0-9_+'-]+(?:\.[A-Z0-9_+'-]+)*@(?:[A-Z0-9]+(?:-[A-Z0-9]+)*\.)+([A-Z]{2,10})$", RegexOptions.Compiled,
      TimeSpan.FromMilliseconds(250));

  public Email(string email)
  {
    if (string.IsNullOrEmpty(email))
    {
      throw new EmailNullOrEmptyException();
    }

    email = email.Trim();
    if (email.Length > EmailMaxLength)
    {
      throw new EmailMaxLengthException();
    }

    if (!IsValidEmail(email))
    {
      throw new EmailInvalidPatternException();
    }
    _email = email;
  }

  private static bool IsValidEmail(string email)
  {
    try
    {
      var isValidEmail = EmailRegex.IsMatch(email.ToUpperInvariant());
      return isValidEmail;
    }
    catch (RegexMatchTimeoutException)
    {
      return false;
    }
    catch (ArgumentException)
    {
      return false;
    }
  }

  public static implicit operator Email(string value)
  {
    return new Email(value);
  }

  public static implicit operator string(Email email)
  {
    return email._email;
  }
}
