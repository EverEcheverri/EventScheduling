namespace EventScheduling.Application.Test.User;

using Application.User.Interfaces;
using Application.User.UseCases;
using Domain.User;
using Domain.User.Repositories;
using Domain.User.ValueObjects;
using EventScheduling.Application.User.Exceptions;
using EventScheduling.Test.Data.Commands;
using EventScheduling.Test.Data.User;
using Moq;
using Xunit;

public class CreateUserUseCaseTest
{
  private readonly ICreateUser _createUserUseCase;
  private readonly Mock<IUserRepository> _userRepositoryMock;

  public CreateUserUseCaseTest()
  {
    _userRepositoryMock = new Mock<IUserRepository>();
    _createUserUseCase = new CreateUserUseCase(_userRepositoryMock.Object);
  }

  [Fact]
  public async Task CreateUserUseCase_ExecuteAsync_Successfully()
  {
    // Arrange
    var command = CreateUserCommandMother.Create();
    _userRepositoryMock.Setup(u => u.GetByEmailAsync(It.IsAny<Email>(), CancellationToken.None))
      .ReturnsAsync((User)null);

    // Act
    await _createUserUseCase.ExecuteAsync(command, CancellationToken.None);

    // Asserts
    
    _userRepositoryMock.Verify(u => u.GetByEmailAsync(It.IsAny<Email>(), CancellationToken.None), Times.Once());
    _userRepositoryMock.Verify(u => u.SaveAsync(It.IsAny<User>(), CancellationToken.None), Times.Once);
  }

  [Fact]
  public async Task ExecuteAsync_Throws_UserEmailAlreadyExistException()
  {
     // Arrange
    var user = UserMother.Create();
    var command = CreateUserCommandMother.Create();
    _userRepositoryMock.Setup(u => u.GetByEmailAsync(It.IsAny<Email>(), CancellationToken.None))
      .ReturnsAsync(user);

    // Act
    var exception =
      await Assert.ThrowsAsync<UserEmailAlreadyExistException>(() => _createUserUseCase.ExecuteAsync(command, CancellationToken.None));
    
    // Asserts
    Assert.Equal($"the email developer_one@yopmail.com already exist", exception.Message);
    
    _userRepositoryMock.Verify(u => u.GetByEmailAsync(It.IsAny<Email>(), CancellationToken.None), Times.Once());
    _userRepositoryMock.Verify(u => u.SaveAsync(It.IsAny<User>(), CancellationToken.None), Times.Never);
  }
}
