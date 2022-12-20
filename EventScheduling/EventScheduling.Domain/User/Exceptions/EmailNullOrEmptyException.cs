namespace EventScheduling.Domain.User.Exceptions;

using SharedKernel.Exceptions;

public class EmailNullOrEmptyException: BusinessException
{
  public EmailNullOrEmptyException() : base("Email is null or empty")
  {
  }
}
