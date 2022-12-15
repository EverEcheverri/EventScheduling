namespace EventScheduling.Application.City.UseCases;

using Domain.City;
using Domain.City.Commands;
using Domain.City.Repositories;
using Domain.Country.Repositories;
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
    var city = City.Build(createCityCommand.Id, createCityCommand.Name, createCityCommand.CountryId);
    await _cityRepository.SaveAsync(city, cancellationToken);
  }
}
