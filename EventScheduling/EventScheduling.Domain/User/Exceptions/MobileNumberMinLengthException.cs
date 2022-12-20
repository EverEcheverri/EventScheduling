namespace EventScheduling.Domain.User.Exceptions;

using SharedKernel.Exceptions;

public class MobileNumberMinLengthException : BusinessException
{
  public MobileNumberMinLengthException(short value)
    : base($"The mobile number must be at least {value} characters")
  {
  }
}
