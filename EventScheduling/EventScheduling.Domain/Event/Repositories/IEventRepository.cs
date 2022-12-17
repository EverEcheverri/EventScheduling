namespace EventScheduling.Domain.Event.Repositories;

public interface IEventRepository
{
  Task SaveAsync(Event @event, CancellationToken cancellationToken);
  Task<Event?> GetByNameAsync(string eventName, CancellationToken cancellationToken);
}
