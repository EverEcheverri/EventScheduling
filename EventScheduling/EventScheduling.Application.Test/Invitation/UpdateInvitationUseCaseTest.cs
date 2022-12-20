namespace EventScheduling.Application.Test.Invitation;

using Application.Invitation.Interfaces;
using Application.Invitation.UseCases;
using Domain.Event.Commands;
using Domain.Event.Enums;
using Domain.Event.Repositories;
using Domain.User.Repositories;
using Domain.User.ValueObjects;
using EventScheduling.Domain.User.Queries;
using EventScheduling.Test.Data.Commands;
using EventScheduling.Test.Data.Event;
using Moq;
using Xunit;

public class UpdateInvitationUseCaseTest
{
  private readonly Mock<IInvitationRepository> _invitationRepositoryMock;
  private readonly IUpdateInvitation _useCase;
  public UpdateInvitationUseCaseTest()
  {
    _invitationRepositoryMock = new Mock<IInvitationRepository>();
    _useCase = new UpdateInvitationUseCase(_invitationRepositoryMock.Object);
  }

  [Fact]
  public async Task UpdateInvitationUseCase_ExecuteAsync_Successfully()
  {
    // Arrange
    var invitation = InvitationMother.Create();
    var command = new UpdateInvitationCommand
    {
      InvitationId = invitation.Id,
      Status = InvitationStatus.Accepted
    };

    _invitationRepositoryMock.Setup(i => i.GetByIdAsync(
        It.IsAny<Guid>(),
        CancellationToken.None))
      .ReturnsAsync(invitation);

    // Act
    await _useCase.ExecuteAsync(command, CancellationToken.None);

    // Asserts
    _invitationRepositoryMock.Verify(i => i.GetByIdAsync(
      It.IsAny<Guid>(),
      CancellationToken.None), Times.Once);
    
    Assert.Equal(InvitationStatus.Accepted, invitation.Status);
  }
}
