namespace EventScheduling.Application.Test.User;

using Application.User.Interfaces;
using Application.User.UseCases;
using Domain.Country;
using Domain.Country.Repositories;
using Domain.User.Enums;
using Domain.User.Queries;
using Domain.User.Repositories;
using Moq;
using Xunit;

public class GetByCountryUseCaseTest
{
  private readonly Mock<ICountryRepository> _countryRepositoryMock;
  private readonly IGetByCountry _useCase;
  private readonly Mock<IUserRepository> _userRepositoryMock;

  public GetByCountryUseCaseTest()
  {
    _countryRepositoryMock = new Mock<ICountryRepository>();
    _userRepositoryMock = new Mock<IUserRepository>();
    _useCase = new GetByCountryUseCase(_userRepositoryMock.Object, _countryRepositoryMock.Object);
  }

  [Fact]
  public async Task GetByCountryUseCase_ExecuteAsync_Successfully()
  {
    var list = new List<GetByCountryQuery>
    {
      new()
      {
        UserName = "userOne",
        Email = "UserOne@noname.com",
        CityName = "cityOne",
        Role = UserRoles.Developer
      }
    };
    // Arrange
    var colombiaId = Guid.Parse("8217f508-c17d-431e-9cf0-05ca8984971b");
    var colombia = Country.Build(colombiaId, "Colombia");

    _countryRepositoryMock.Setup(c => c.GetByNameAsync(It.IsAny<string>(), CancellationToken.None))
      .ReturnsAsync(colombia);

    _userRepositoryMock.Setup(u => u.GetByCountryIdAsync(It.IsAny<Guid>(), CancellationToken.None))
      .ReturnsAsync(list);

    // Act
    var userByCountry = await _useCase.ExecuteAsync("Colombia", CancellationToken.None);

    // Asserts

    _countryRepositoryMock.Verify(u => u.GetByNameAsync(It.IsAny<string>(), CancellationToken.None), Times.Once());
    _userRepositoryMock.Verify(u => u.GetByCountryIdAsync(It.IsAny<Guid>(), CancellationToken.None), Times.Once());

    Assert.Collection(userByCountry, one =>
      {
        Assert.Equal("userOne", one.UserName);
        Assert.Equal("UserOne@noname.com", one.Email);
        Assert.Equal("cityOne", one.CityName);
        Assert.Equal(UserRoles.Developer, one.Role);
      }
    );
  }
}
