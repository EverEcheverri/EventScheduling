namespace EventScheduling.Application.Event.Interfaces;

using Domain.Event.Commands;

public interface ICreateEvent
{
  Task ExecuteAsync(CreateEventCommand createEventCommand, CancellationToken cancellationToken);
}
