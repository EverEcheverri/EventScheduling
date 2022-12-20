namespace EventScheduling.Domain.Test.User;

using Domain.Event.Enums;
using EventScheduling.Test.Data.Event;
using Xunit;

public class InvitationTest
{
  [Fact]
  public void Invitation_Builds_Successfully()
  {
    // Arrange

    // Act
    var invitation = InvitationMother.Create();

    // Assert
    Assert.NotNull(invitation);
    Assert.Equal(Guid.Parse("aca6b8c6-45c8-408e-bf68-b6865dc0b729"), invitation.Id);
    Assert.Equal("developer_one@yopmail.com", invitation.Email);
    Assert.Equal(InvitationStatus.Pending, invitation.Status);
    Assert.Equal(DateTime.Parse("2022-01-01T13:00:00.0000000Z").ToUniversalTime(), invitation.StartTime);
    Assert.Equal(DateTime.Parse("2022-01-01T14:00:00.0000000Z").ToUniversalTime(), invitation.EndTime);
  }
}
