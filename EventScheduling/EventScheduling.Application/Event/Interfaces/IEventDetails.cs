namespace EventScheduling.Application.Event.Interfaces;

using Domain.Event;

public interface IEventDetails
{
  Task<Event> ExecuteAsync(Guid eventId, CancellationToken cancellationToken);
}
