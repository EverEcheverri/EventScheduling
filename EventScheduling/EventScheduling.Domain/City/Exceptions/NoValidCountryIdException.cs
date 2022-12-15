using EventScheduling.Domain.SharedKernel.Exceptions;

namespace EventScheduling.Domain.City.Exceptions;

public class NoValidCountryIdException: BusinessException
{
  public NoValidCountryIdException() : base("CountryId is null, default or empty")
  {
  }
}
