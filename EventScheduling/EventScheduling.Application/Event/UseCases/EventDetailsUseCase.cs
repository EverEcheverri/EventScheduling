using EventScheduling.Application.Event.Interfaces;

namespace EventScheduling.Application.Event.UseCases;

using Domain.Event;
using Domain.Event.Queries;
using EventScheduling.Application.Event.Exceptions;
using EventScheduling.Domain.Event.Repositories;

public class EventDetailsUseCase : IEventDetails
{
  private readonly IEventRepository _eventRepository;

  public EventDetailsUseCase(IEventRepository eventRepository)
  {
    _eventRepository = eventRepository;
  } 

  public async Task<Event> ExecuteAsync(Guid eventId, CancellationToken cancellationToken)
  {
    var @event = await _eventRepository.GetByIdWithInvitationsAsync(eventId, cancellationToken);
    if (@event == null)
    {
      throw new EventDoesNotExistException(eventId);
    }
    return @event;
  }
}
