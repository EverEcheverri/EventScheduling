using EventScheduling.Domain.SharedKernel.Exceptions;

namespace EventScheduling.Application.Event.Exceptions;

public class EventDoesNotExistException: BusinessException
{
  public EventDoesNotExistException(Guid eventId)
    : base($"the eventId: {eventId} does not exist")
  {
  }
}
