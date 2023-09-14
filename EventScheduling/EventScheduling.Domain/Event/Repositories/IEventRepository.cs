using System.Linq.Expressions;

namespace EventScheduling.Domain.Event.Repositories;

public interface IEventRepository
{
    Task SaveAsync(Event @event, CancellationToken cancellationToken);
    Task<Event> GetByIdAsync(Guid eventId, CancellationToken cancellationToken);
    Task<Event?> GetByNameAsync(string eventName, CancellationToken cancellationToken);
    Task UpdateAsync(Event @event, CancellationToken cancellationToken);

    Task<Event> GetByIdWithInvitationsAsync(Guid eventId, CancellationToken cancellationToken);
    Task<Event> GetAsync(Expression<Func<Event, bool>> predicate, CancellationToken cancellationToken);
}
