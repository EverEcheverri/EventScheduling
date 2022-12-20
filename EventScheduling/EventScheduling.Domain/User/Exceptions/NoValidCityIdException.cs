namespace EventScheduling.Domain.User.Exceptions;

using SharedKernel.Exceptions;

public class NoValidCityIdException : BusinessException
{
  public NoValidCityIdException() : base("City id is null or empty")
  {
  }
}
