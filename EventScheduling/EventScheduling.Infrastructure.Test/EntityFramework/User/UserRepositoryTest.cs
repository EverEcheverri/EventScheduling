namespace EventScheduling.Infrastructure.Test.EntityFramework.User;

using Domain.User;
using Domain.User.Repositories;
using EventScheduling.Domain.User.Enums;
using EventScheduling.Infrastructure.EntityFramework.User.Repositories;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

public class UserRepositoryTest
{
  private readonly DbContextOptions<EventSchedulingDbContext> _options;
  private readonly Mock<IConfiguration> _configurationMock;
  private IUserRepository _userRepository;
  public UserRepositoryTest()
  {
    _options = new DbContextOptionsBuilder<EventSchedulingDbContext>()
      .UseInMemoryDatabase(Guid.NewGuid().ToString())
      //Suppress Transactions are not supported by the in-memory store
      .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
      .Options;

    var mockConfSection = new Mock<IConfigurationSection>();
    mockConfSection.SetupGet(m => m[It.Is<string>(s => s == "DefaultConnection")])
      .Returns("..\\EventScheduling.Infrastructure\\event-schedulingdb");

    _configurationMock = new Mock<IConfiguration>();
    _configurationMock.Setup(a =>
      a.GetSection(It.Is<string>(s => s == "ConnectionStrings")))
      .Returns(mockConfSection.Object);
  }

  //GetByEmailAsync
  [Fact]
  public async Task FileRepository_GetByEmailAsync_Returns_User()
  {
    // Arrange
    var userOne = User.Build(
      Guid.Parse("b2181377-6a51-446e-afb6-07f1402834e3"),
      "developer_one@yopmail.com",
      "developer_one",
      Guid.Parse("5ebf0600-c390-4b16-945d-eb0e734cf51c"),
      "111 1111111",
      UserRoles.Developer);

    var userTwo = User.Build(Guid.Parse("140c7396-cb76-45ea-88c5-e709702dd927"),
      "developer_four@yopmail.com",
      "developer_four",
      Guid.Parse("386a04f3-e4c4-4922-9e79-e75ac0fa3a6a"),
      "444 4444444",
      UserRoles.Developer);

    await using var context = new EventSchedulingDbContext(_options, _configurationMock.Object);
    await context.User.AddAsync(userOne);
    await context.User.AddAsync(userTwo);
    await context.SaveChangesAsync();

    await using var contextAssert = new EventSchedulingDbContext(_options, _configurationMock.Object);
    _userRepository = new UserRepository(contextAssert);

    // Act
    var user = await _userRepository.GetByEmailAsync(userOne.Email, CancellationToken.None);

    // Assert File
    Assert.Equal("developer_one@yopmail.com", user.Email);

  }
}
