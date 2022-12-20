namespace EventScheduling.Application.Event.UseCases;

using City.Exceptions;
using Domain.City.Repositories;
using Domain.Event;
using Domain.Event.Commands;
using Domain.Event.Enums;
using Domain.Event.Repositories;
using Domain.LocationService;
using Exceptions;
using Interfaces;

public class CreateEventUseCase : ICreateEvent
{
  private readonly ICitylocationService _cityLocation;
  private readonly ICityRepository _cityRepository;
  private readonly IEventRepository _eventRepository;

  public CreateEventUseCase(IEventRepository eventRepository, ICityRepository cityRepository,
    ICitylocationService cityLocation)
  {
    _eventRepository = eventRepository;
    _cityRepository = cityRepository;
    _cityLocation = cityLocation;
  }

  public async Task ExecuteAsync(CreateEventCommand createEventCommand, CancellationToken cancellationToken)
  {
    if (createEventCommand.StartTimeUtc < DateTime.UtcNow)
    {
      throw new CannotCreateEventInPastTimeException(createEventCommand.StartTimeUtc);
    }

    var city = await _cityRepository.GetByIdAsync(createEventCommand.CityId, cancellationToken);
    if (city == null)
    {
      throw new CityDoesNotExistException(createEventCommand.CityId);
    }

    var countryId = Guid.Empty;
    var utcOffset = string.Empty;
    double latitude = 0;
    double longitude = 0;


    if (createEventCommand.EventType == EventType.Face2Face)
    {
      var cityLocationResult = await _cityLocation.GetCityLocationAsync(city.Name, cancellationToken);
      countryId = city.CountryId;
      utcOffset = cityLocationResult.location.utc_offset;
      latitude = double.Parse(cityLocationResult.location.lat);
      longitude = double.Parse(cityLocationResult.location.lon);
    }

    var newEvent = Event.Build(
      createEventCommand.Id,
      createEventCommand.Name,
      createEventCommand.Description,
      createEventCommand.EventType,
      createEventCommand.StartTimeUtc,
      createEventCommand.EndTimeUtc,
      createEventCommand.CityId,
      countryId,
      utcOffset,
      latitude,
      longitude);

    await _eventRepository.SaveAsync(newEvent, cancellationToken);
  }
}
