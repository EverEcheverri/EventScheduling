namespace EventScheduling.Domain.User.Exceptions;

using SharedKernel.Exceptions;

public class EmailInvalidPatternException : BusinessException
{
  public EmailInvalidPatternException() : base("Email invalid pattern")
  {
  }
}
