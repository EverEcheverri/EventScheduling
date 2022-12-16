namespace EventScheduling.Application.City.Exceptions;

using Domain.SharedKernel.Exceptions;

public class CityAlreadyExistException : BusinessException
{
  public CityAlreadyExistException(string city)
    : base($"the city {city} already exist")
  {
  }
}
