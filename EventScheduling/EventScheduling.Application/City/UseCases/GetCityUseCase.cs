namespace EventScheduling.Application.City.UseCases;

using Domain.City;
using Domain.City.Repositories;
using Interfaces;

public class GetCityUseCase : IGetCity
{
    private readonly ICityRepository _cityRepository;

    public GetCityUseCase(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<City> ExecuteAsync(string name, CancellationToken cancellationToken)
    {
        var city = await _cityRepository.GetAsync(c => c.Name.ToLower() == name.ToLower(), cancellationToken);
        var testById = await _cityRepository.GetAsync(c => c.Id == city.Id, cancellationToken);

        return city;
    }
}
