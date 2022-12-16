namespace EventScheduling.Application.User.UseCases;

using Domain.Country.Repositories;
using Domain.User.Queries;
using Domain.User.Repositories;
using Interfaces;

public class GetByCountryUseCase : IGetByCountry
{
  private readonly ICountryRepository _countryRepository;
  private readonly IUserRepository _userRepository;

  public GetByCountryUseCase(IUserRepository userRepository, ICountryRepository countryRepository)
  {
    _userRepository = userRepository;
    _countryRepository = countryRepository;
  }

  public async Task<ICollection<GetByCountryQuery>> ExecuteAsync(string countryName,
    CancellationToken cancellationToken)
  {
    var country = await _countryRepository.GetByNameAsync(countryName, cancellationToken);

    var users = await _userRepository.GetByCountryIdAsync(country.Id, cancellationToken);
    return users;
  }
}
