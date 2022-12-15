namespace EventScheduling.Api.Controllers.UseCase.User.Create;

using System.ComponentModel.DataAnnotations;
using Domain.User.Commands;
using Domain.User.Enums;

public class RequestCreateUser
{
  [Required]
  public string Email { get; set; }

  [Required]
  public string Name { get; set; }

  [Required]
  public Guid CityId { get; set; }

  [Required]
  public string Mobile { get; set; }

  [Required]
  public int Role { get; set; }

  internal CreateUserCommand ToCreateUserCommand()
  {
    return new CreateUserCommand
    {
      Email = Email,
      Name = Name,
      CityId = CityId,
      Mobile = Mobile,
      Role = (UserRoles)Role
    };
  }
}
