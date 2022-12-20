namespace EventScheduling.Domain.City.Exceptions;

using SharedKernel.Exceptions;

public class TimeZoneIdNullOrEmptyException : BusinessException
{
  public TimeZoneIdNullOrEmptyException() : base("TimeZoneId is null or empty")
  {
  }
}
