namespace EventScheduling.Application.Test.Event;

using Application.Event.Exceptions;
using Application.Event.Interfaces;
using Application.Event.UseCases;
using City.Exceptions;
using Domain.City;
using Domain.City.Repositories;
using Domain.Event;
using Domain.Event.Repositories;
using Domain.LocationService;
using EventScheduling.Test.Data.City;
using EventScheduling.Test.Data.Commands;
using Moq;
using Xunit;

public class CreateEventUseCaseTest
{
  private readonly Mock<ICitylocationService> _cityLocationMock;
  private readonly Mock<ICityRepository> _cityRepositoryMock;
  private readonly Mock<IEventRepository> _eventRepositoryMock;
  private readonly ICreateEvent _useCase;

  public CreateEventUseCaseTest()
  {
    _cityLocationMock = new Mock<ICitylocationService>();
    _cityRepositoryMock = new Mock<ICityRepository>();
    _eventRepositoryMock = new Mock<IEventRepository>();
    _useCase = new CreateEventUseCase(_eventRepositoryMock.Object, _cityRepositoryMock.Object,
      _cityLocationMock.Object);
  }

  [Fact]
  public async Task CreateEventUseCase_ExecuteAsync_Successfully()
  {
    // Arrange
    var startTime = DateTime.UtcNow.AddHours(1);
    var command = CreateEventCommandMother.Create(startTimeUtc: startTime);
    var city = CityMother.Create();
    var cityLocation = ResponseGetCityLocationMother.Create();

    _cityRepositoryMock.Setup(u => u.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
      .ReturnsAsync(city);

    _cityLocationMock.Setup(cl => cl.GetCityLocationAsync(city.Name, CancellationToken.None))
      .ReturnsAsync(cityLocation);

    // Act
    await _useCase.ExecuteAsync(command, CancellationToken.None);

    // Asserts
    _cityRepositoryMock.Verify(u => u.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None), Times.Once);
    _cityLocationMock.Verify(cl => cl.GetCityLocationAsync(city.Name, CancellationToken.None), Times.Once);
    _eventRepositoryMock.Verify(u => u.SaveAsync(It.IsAny<Event>(), CancellationToken.None), Times.Once);
  }

  [Fact]
  public async Task CreateEventUseCase_Throws_CannotCreateEventInPastTimeException()
  {
    // Arrange
    var command = CreateEventCommandMother.Create();

    // Act
    var exception =
      await Assert.ThrowsAsync<CannotCreateEventInPastTimeException>(() =>
        _useCase.ExecuteAsync(command, CancellationToken.None));

    // Asserts
    Assert.Equal($"cannot create an event in past time, utc time: {command.StartTimeUtc}", exception.Message);

    _cityRepositoryMock.Verify(u => u.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None), Times.Never);
    _cityLocationMock.Verify(cl => cl.GetCityLocationAsync(It.IsAny<string>(), CancellationToken.None), Times.Never);
    _eventRepositoryMock.Verify(u => u.SaveAsync(It.IsAny<Event>(), CancellationToken.None), Times.Never);
  }

  [Fact]
  public async Task CreateEventUseCase_Throws_CityDoesNotExistException()
  {
    // Arrange
    var startTime = DateTime.UtcNow.AddHours(1);
    var command = CreateEventCommandMother.Create(startTimeUtc: startTime);
    var city = CityMother.Create();

    _cityRepositoryMock.Setup(u => u.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
      .ReturnsAsync((City)null);

    // Act
    var exception =
      await Assert.ThrowsAsync<CityDoesNotExistException>(() =>
        _useCase.ExecuteAsync(command, CancellationToken.None));

    // Asserts
    Assert.Equal("the city with id 5ebf0600-c390-4b16-945d-eb0e734cf51c does not exist", exception.Message);

    _cityRepositoryMock.Verify(u => u.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None), Times.Once);
    _cityLocationMock.Verify(cl => cl.GetCityLocationAsync(city.Name, CancellationToken.None), Times.Never);
    _eventRepositoryMock.Verify(u => u.SaveAsync(It.IsAny<Event>(), CancellationToken.None), Times.Never);
  }
}
