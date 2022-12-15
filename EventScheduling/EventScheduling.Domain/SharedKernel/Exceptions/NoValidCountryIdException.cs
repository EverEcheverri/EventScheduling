namespace EventScheduling.Domain.SharedKernel.Exceptions;

public class NoValidCountryIdException: BusinessException
{
  public NoValidCountryIdException() : base("CountryId is null, default or empty")
  {
  }
}
