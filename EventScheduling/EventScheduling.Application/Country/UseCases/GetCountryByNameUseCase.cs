namespace EventScheduling.Application.Country.UseCases;

using Domain.Country;
using Domain.Country.Repositories;
using Interfaces;

public class GetCountryByNameUseCase : IGetCountryByName
{
  private readonly ICountryRepository _countryRepository;

  public GetCountryByNameUseCase(ICountryRepository countryRepository)
  {
    _countryRepository = countryRepository;
  }

  public async Task<Country> ExecuteAsync(string name, CancellationToken cancellationToken)
  {
    cancellationToken.ThrowIfCancellationRequested();
    return await _countryRepository.GetByNameAsync(name, cancellationToken);
  }
}
