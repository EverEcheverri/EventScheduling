namespace EventScheduling.Domain.User.Exceptions;

using SharedKernel.Exceptions;

public class UserNameMaxLengthException : BusinessException
{
  public UserNameMaxLengthException() : base("User name max length exceeded")
  {
  }
}
