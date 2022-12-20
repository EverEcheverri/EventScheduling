namespace EventScheduling.Api.Controllers.UseCase.Cities.Create;

using EventScheduling.Domain.City.Commands;
using System.ComponentModel.DataAnnotations;

public class RequestCreateCity
{
  [Required]
  public Guid Id { get; set; }

  [Required]
  public string Name { get; set; }

  [Required]
  public Guid CountryId { get; set; }

  internal CreateCityCommand ToCreateCityCommand()
  {
    return new CreateCityCommand
    {
      Id = Id,
      Name = Name,
      CountryId = CountryId
    };
  }
}
