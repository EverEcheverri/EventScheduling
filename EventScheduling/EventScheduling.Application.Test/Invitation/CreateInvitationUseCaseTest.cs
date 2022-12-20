namespace EventScheduling.Application.Test.Invitation;

using Application.Event.Exceptions;
using Application.Invitation.Interfaces;
using Application.Invitation.UseCases;
using Domain.Event;
using Domain.Event.Enums;
using Domain.Event.Repositories;
using Domain.User.Queries;
using Domain.User.Repositories;
using Domain.User.ValueObjects;
using EventScheduling.Application.Invitation.Exceptions;
using EventScheduling.Application.User.Exceptions;
using EventScheduling.Domain.User;
using EventScheduling.Test.Data.Commands;
using EventScheduling.Test.Data.Event;
using Moq;
using Xunit;

public class CreateInvitationUseCaseTest
{
  private readonly Mock<IEventRepository> _eventRepositoryMock;
  private readonly Mock<IInvitationRepository> _invitationRepositoryMock;
  private readonly ICreateInvitation _useCase;
  private readonly Mock<IUserRepository> _userRepositoryMock;

  public CreateInvitationUseCaseTest()
  {
    _eventRepositoryMock = new Mock<IEventRepository>();
    _invitationRepositoryMock = new Mock<IInvitationRepository>();
    _userRepositoryMock = new Mock<IUserRepository>();
    _useCase = new CreateInvitationUseCase(_eventRepositoryMock.Object, _userRepositoryMock.Object,
      _invitationRepositoryMock.Object);
  }

  [Fact]
  public async Task CreateInvitationUseCase_ExecuteAsync_Successfully()
  {
    // Arrange
    var @event = EventMother.Create();
    var userWithTimeZone = new GetWithCityQuery
    {
      Email = "developer_one@yopmail.com",
      TimeZoneId = "America/Bogota"
    };
    var command = CreateInvitationCommandMother.Create();
    var userLocalStartTime =
      TimeZoneInfo.ConvertTimeFromUtc(@event.StartTimeUtc, TimeZoneInfo.FindSystemTimeZoneById(userWithTimeZone.TimeZoneId));
    var userLocalEndTime =
      TimeZoneInfo.ConvertTimeFromUtc(@event.EndTimeUtc, TimeZoneInfo.FindSystemTimeZoneById(userWithTimeZone.TimeZoneId));


    _eventRepositoryMock.Setup(e => e.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
      .ReturnsAsync(@event);

    _userRepositoryMock.Setup(u => u.GetWithTimeZoneIdAsync(It.IsAny<Email>(), CancellationToken.None))
      .ReturnsAsync(userWithTimeZone);

    _invitationRepositoryMock.Setup(i => i.GetByEventIdAndEmailAsync(
        It.IsAny<Guid>(),
        It.IsAny<string>(),
        CancellationToken.None))
      .ReturnsAsync((Invitation)null);

    // Act
    await _useCase.ExecuteAsync(command, CancellationToken.None);

    // Asserts
    _eventRepositoryMock.Verify(e => e.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None), Times.Once);

    _userRepositoryMock.Verify(u => u.GetWithTimeZoneIdAsync(It.IsAny<Email>(), CancellationToken.None), Times.Once);

    _invitationRepositoryMock.Verify(i => i.GetByEventIdAndEmailAsync(
      It.IsAny<Guid>(),
      It.IsAny<string>(),
      CancellationToken.None), Times.Once);

    _eventRepositoryMock.Verify(u => u.UpdateAsync(It.IsAny<Event>(), CancellationToken.None), Times.Once);

    Assert.Collection(@event.Invitation,
      one =>
      {
        Assert.Equal("developer_one@yopmail.com", one.Email);
        Assert.Equal(InvitationStatus.Pending, one.Status);
        Assert.Equal(userLocalStartTime, one.StartTime);
        Assert.Equal(userLocalEndTime, one.EndTime);
      }
    );
  }

  [Fact]
  public async Task CreateInvitationUseCase_Throws_EventDoesNotExistException()
  {
    // Arrange
    var command = CreateInvitationCommandMother.Create();

    _eventRepositoryMock.Setup(e => e.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
      .ReturnsAsync((Event)null);


    // Act
    var exception =
      await Assert.ThrowsAsync<EventDoesNotExistException>(() =>
        _useCase.ExecuteAsync(command, CancellationToken.None));

    // Asserts
    Assert.Equal("the eventId: a6daf43e-5eee-4473-a70c-6f890b20b79e does not exist", exception.Message);

    _eventRepositoryMock.Verify(e => e.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None), Times.Once);

    _userRepositoryMock.Verify(u => u.GetWithTimeZoneIdAsync(It.IsAny<Email>(), CancellationToken.None), Times.Never);

    _invitationRepositoryMock.Verify(i => i.GetByEventIdAndEmailAsync(
      It.IsAny<Guid>(),
      It.IsAny<string>(),
      CancellationToken.None), Times.Never);

    _eventRepositoryMock.Verify(u => u.UpdateAsync(It.IsAny<Event>(), CancellationToken.None), Times.Never);
  }

  [Fact]
  public async Task CreateInvitationUseCase_Throws_UserEmailDoesNotExistException()
  {
    // Arrange
    var @event = EventMother.Create();
    var command = CreateInvitationCommandMother.Create();

    _eventRepositoryMock.Setup(e => e.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
      .ReturnsAsync(@event);

    _userRepositoryMock.Setup(u => u.GetWithTimeZoneIdAsync(It.IsAny<Email>(), CancellationToken.None))
      .ReturnsAsync((GetWithCityQuery)null);

    _invitationRepositoryMock.Setup(i => i.GetByEventIdAndEmailAsync(
        It.IsAny<Guid>(),
        It.IsAny<string>(),
        CancellationToken.None))
      .ReturnsAsync((Invitation)null);

    // Act
    var exception =
      await Assert.ThrowsAsync<UserEmailDoesNotExistException>(() =>
        _useCase.ExecuteAsync(command, CancellationToken.None));

    // Asserts
    Assert.Equal("the email developer_one@yopmail.com does not exist", exception.Message);

    _eventRepositoryMock.Verify(e => e.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None), Times.Once);

    _userRepositoryMock.Verify(u => u.GetWithTimeZoneIdAsync(It.IsAny<Email>(), CancellationToken.None), Times.Once);

    _invitationRepositoryMock.Verify(i => i.GetByEventIdAndEmailAsync(
      It.IsAny<Guid>(),
      It.IsAny<string>(),
      CancellationToken.None), Times.Never);

    _eventRepositoryMock.Verify(u => u.UpdateAsync(It.IsAny<Event>(), CancellationToken.None), Times.Never);
  }

  [Fact]
  public async Task CreateInvitationUseCase_Throws_InvitationAlreadyExistException()
  {
    // Arrange
    var @event = EventMother.Create();

    var userWithTimeZone = new GetWithCityQuery
    {
      Email = "developer_one@yopmail.com",
      TimeZoneId = "America/Bogota"
    };
    var command = CreateInvitationCommandMother.Create();
    var invitation = InvitationMother.Create();

    _eventRepositoryMock.Setup(e => e.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
      .ReturnsAsync(@event);

    _userRepositoryMock.Setup(u => u.GetWithTimeZoneIdAsync(It.IsAny<Email>(), CancellationToken.None))
      .ReturnsAsync(userWithTimeZone);

    _invitationRepositoryMock.Setup(i => i.GetByEventIdAndEmailAsync(
        It.IsAny<Guid>(),
        It.IsAny<string>(),
        CancellationToken.None))
      .ReturnsAsync(invitation);

    // Act
    var exception =
      await Assert.ThrowsAsync<InvitationAlreadyExistException>(() =>
        _useCase.ExecuteAsync(command, CancellationToken.None));

    // Asserts
    Assert.Equal("the invitationId: aca6b8c6-45c8-408e-bf68-b6865dc0b729 already exist", exception.Message);

    _userRepositoryMock.Verify(u => u.GetWithTimeZoneIdAsync(It.IsAny<Email>(), CancellationToken.None), Times.Once);

    _invitationRepositoryMock.Verify(i => i.GetByEventIdAndEmailAsync(
      It.IsAny<Guid>(),
      It.IsAny<string>(),
      CancellationToken.None), Times.Once);

    _eventRepositoryMock.Verify(u => u.UpdateAsync(It.IsAny<Event>(), CancellationToken.None), Times.Never);
  }
}
