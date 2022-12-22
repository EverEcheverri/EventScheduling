namespace EventScheduling.Application.Event.UseCases;

using Domain.Event;
using Domain.Event.Repositories;
using Exceptions;
using Interfaces;

public class EventDetailsUseCase : IEventDetails
{
  private readonly IEventRepository _eventRepository;

  public EventDetailsUseCase(IEventRepository eventRepository)
  {
    _eventRepository = eventRepository;
  }

  public async Task<Event> ExecuteAsync(Guid eventId, CancellationToken cancellationToken)
  {
    cancellationToken.ThrowIfCancellationRequested();
    var @event = await _eventRepository.GetByIdWithInvitationsAsync(eventId, cancellationToken);
    if (@event == null)
    {
      throw new EventDoesNotExistException(eventId);
    }

    return @event;
  }
}
