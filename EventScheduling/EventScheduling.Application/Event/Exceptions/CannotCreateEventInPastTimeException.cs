using EventScheduling.Domain.SharedKernel.Exceptions;

namespace EventScheduling.Application.Event.Exceptions;

public class CannotCreateEventInPastTimeException: BusinessException
{
  public CannotCreateEventInPastTimeException(DateTime dateTime)
    : base($"cannot create an event in past time, utc time: {dateTime}")
  {
  }
}
