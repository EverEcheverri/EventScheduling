namespace EventScheduling.Application.Test.Event;

using Application.Event.Interfaces;
using Application.Event.UseCases;
using Domain.Event.Enums;
using Domain.Event.Repositories;
using EventScheduling.Test.Data.Event;
using Moq;
using Xunit;

public class EventDetailsUseCaseTest
{
  private readonly Mock<IEventRepository> _eventRepositoryMock;
  private readonly IEventDetails _useCase;

  public EventDetailsUseCaseTest()
  {
    _eventRepositoryMock = new Mock<IEventRepository>();
    _useCase = new EventDetailsUseCase(_eventRepositoryMock.Object);
  }

  [Fact]
  public async Task EventDetailsUseCase_ExecuteAsync_Successfully()
  {
    // Arrange
    var @event = EventMother.Create();
    var invitationOne = InvitationMother.Create();
    var invitationTwo = InvitationMother.Create("fca381f4-5ecc-4977-a290-9e798e9f3d25", "developer_two@yopmail.com");
    @event.AddInvitation(invitationOne);
    @event.AddInvitation(invitationTwo);

    _eventRepositoryMock.Setup(c => c.GetByIdWithInvitationsAsync(It.IsAny<Guid>(), CancellationToken.None))
      .ReturnsAsync(@event);

    // Act
    var eventDetails = await _useCase.ExecuteAsync(@event.Id, CancellationToken.None);

    // Asserts
    _eventRepositoryMock.Verify(c => c.GetByIdWithInvitationsAsync(It.IsAny<Guid>(), CancellationToken.None),
      Times.Once);

    Assert.Collection(eventDetails.Invitation,
      one =>
      {
        Assert.Equal("developer_one@yopmail.com", one.Email);
        Assert.Equal(InvitationStatus.Pending, one.Status);
      },
      two =>
      {
        Assert.Equal("developer_two@yopmail.com", two.Email);
        Assert.Equal(InvitationStatus.Pending, two.Status);
      }
    );
  }
}
