namespace EventScheduling.Application.User.Interfaces;

using Domain.User.Commands;

public interface ICreateUser
{
  Task ExecuteAsync(CreateUserCommand createCityCommand, CancellationToken cancellationToken);
}
