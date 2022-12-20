using EventScheduling.Domain.SharedKernel.Exceptions;

namespace EventScheduling.Application.City.Exceptions;

public class CityDoesNotExistException: BusinessException
{
  public CityDoesNotExistException(Guid cityId)
    : base($"the city with id {cityId} does not exist")
  {
  }
}
