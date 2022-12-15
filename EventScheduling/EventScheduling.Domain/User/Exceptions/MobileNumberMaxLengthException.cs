using EventScheduling.Domain.SharedKernel.Exceptions;

namespace EventScheduling.Domain.User.Exceptions;

public class MobileNumberMaxLengthException: BusinessException
{
  public MobileNumberMaxLengthException(short value)
    : base($"Mobile number max length exceeded {value} characters")
  {
  }
}
