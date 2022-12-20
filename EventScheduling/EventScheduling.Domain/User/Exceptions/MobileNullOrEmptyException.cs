using EventScheduling.Domain.SharedKernel.Exceptions;

namespace EventScheduling.Domain.User.Exceptions;

public class MobileNullOrEmptyException: BusinessException
{
  public MobileNullOrEmptyException() : base("Mobile is null or empty")
  {
  }
}
