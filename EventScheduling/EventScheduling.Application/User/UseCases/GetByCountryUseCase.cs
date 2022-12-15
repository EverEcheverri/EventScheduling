namespace EventScheduling.Application.User.UseCases;

using Domain.Country.Repositories;
using Domain.User;
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

  public async Task<ICollection<User>> ExecuteAsync(string countryName, CancellationToken cancellationToken)
  {
    var country = await _countryRepository.GetByNameAsync(countryName, cancellationToken);
    var cityIds = country.Cities.Select(c => c.Id).ToList();

    var users = await _userRepository.GetByCountryIdAsync(cityIds, cancellationToken);
    return users;
  }
}
