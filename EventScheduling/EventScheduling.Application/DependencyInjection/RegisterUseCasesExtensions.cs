namespace EventScheduling.Application.DependencyInjection;

using City.Interfaces;
using City.UseCases;
using Country.Interfaces;
using Country.UseCases;
using Microsoft.Extensions.DependencyInjection;

public static class RegisterUseCasesExtensions
{
  public static void AddUseCases(this IServiceCollection services)
  {
    services
      .AddScoped<ICreateCity, CreateCityUseCase>()
      .AddScoped<IGetCountryByName, GetCountryByNameUseCase>();
  }
}
