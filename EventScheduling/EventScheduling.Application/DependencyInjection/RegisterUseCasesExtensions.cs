namespace EventScheduling.Application.DependencyInjection;

using City.Interfaces;
using City.UseCases;
using Country.Interfaces;
using Country.UseCases;
using Event.Interfaces;
using Event.UseCases;
using Invitation.Interfaces;
using Invitation.UseCases;
using Microsoft.Extensions.DependencyInjection;
using User.Interfaces;
using User.UseCases;

public static class RegisterUseCasesExtensions
{
  public static void AddUseCases(this IServiceCollection services)
  {
    services
      .AddScoped<ICreateCity, CreateCityUseCase>()
      .AddScoped<IGetCountryByName, GetCountryByNameUseCase>()
      .AddScoped<ICreateUser, CreateUserUseCase>()
      .AddScoped<IGetByCountry, GetByCountryUseCase>()
      .AddScoped<ICreateEvent, CreateEventUseCase>()
      .AddScoped<ICreateInvitation, CreateInvitationUseCase>()
      .AddScoped<IUpdateInvitation, UpdateInvitationUseCase>();
  }
}
