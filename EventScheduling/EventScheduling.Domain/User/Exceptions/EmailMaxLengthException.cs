namespace EventScheduling.Domain.User.Exceptions;

using SharedKernel.Exceptions;

public class EmailMaxLengthException : BusinessException
{
  public EmailMaxLengthException() : base("Email max length exceeded 254 characters")
  {
  }
}
