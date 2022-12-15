namespace EventScheduling.Domain.User.Exceptions;

using SharedKernel.Exceptions;

public class MobileNumberInvalidCharacterException : BusinessException
{
  public MobileNumberInvalidCharacterException() 
    : base("Mobile number contains invalid character")
  {
  }
}
