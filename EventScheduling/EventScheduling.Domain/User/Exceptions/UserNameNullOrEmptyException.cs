using EventScheduling.Domain.SharedKernel.Exceptions;

namespace EventScheduling.Domain.User.Exceptions;

public class UserNameNullOrEmptyException : BusinessException
{
  public UserNameNullOrEmptyException() : base("User name is null or empty")
  {
  }
}
