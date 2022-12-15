namespace EventScheduling.Application.User.UseCases;

using Domain.User;
using Domain.User.Commands;
using Domain.User.Repositories;
using Interfaces;

public class CreateUserUseCase : ICreateUser
{
  private readonly IUserRepository _userRepository;

  public CreateUserUseCase(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public async Task ExecuteAsync(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
  {
    var user = User.Build(createUserCommand.Email, createUserCommand.Name, createUserCommand.CityId,
      createUserCommand.Mobile, createUserCommand.Role);
    await _userRepository.SaveAsync(user, cancellationToken);
  }
}
