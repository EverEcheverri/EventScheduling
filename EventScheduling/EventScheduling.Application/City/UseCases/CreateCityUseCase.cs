﻿namespace EventScheduling.Application.City.UseCases;

using Domain.City;
using Domain.City.Commands;
using Domain.City.Repositories;
using Exceptions;
using Interfaces;

public class CreateCityUseCase : ICreateCity
{
  private readonly ICityRepository _cityRepository;

  public CreateCityUseCase(ICityRepository cityRepository)
  {
    _cityRepository = cityRepository;
  }

  public async Task ExecuteAsync(CreateCityCommand createCityCommand, CancellationToken cancellationToken)
  {
    cancellationToken.ThrowIfCancellationRequested();
    var city = _cityRepository.GetByNameAsync(createCityCommand.Name, cancellationToken);
    if (city != null)
    {
      throw new CityAlreadyExistException(createCityCommand.Name);
    }

    var newCity = City.Build(createCityCommand.Id, createCityCommand.Name, createCityCommand.CountryId,
      createCityCommand.TimeZoneId);
    await _cityRepository.SaveAsync(newCity, cancellationToken);
  }
}
