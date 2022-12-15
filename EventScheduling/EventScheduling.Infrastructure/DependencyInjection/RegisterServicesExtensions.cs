﻿namespace EventScheduling.Infrastructure.DependencyInjection;

using Domain.City.Repositories;
using Domain.Country.Repositories;
using EntityFramework.City.Repositories;
using EntityFramework.Country.Repositories;
using Microsoft.Extensions.DependencyInjection;

public static class RegisterServicesExtensions
{
  public static void AddRepositories(this IServiceCollection services)
  {
    services
      .AddScoped<ICityRepository, CityRepository>()
      .AddScoped<ICountryRepository, CountryRepository>();
  }
}