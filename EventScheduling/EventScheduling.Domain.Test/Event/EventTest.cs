namespace EventScheduling.Domain.Test.Event;

using Domain.Event.Enums;
using EventScheduling.Test.Data.Event;
using Xunit;

public class EventTest
{
  [Fact]
  public void Event_Builds_Successfully()
  {
    // Arrange

    // Act
    var @event = EventMother.Create();

    // Assert
    Assert.NotNull(@event);
    Assert.Equal(Guid.Parse("a6daf43e-5eee-4473-a70c-6f890b20b79e"), @event.Id);
    Assert.Equal("event test", @event.Name);
    Assert.Equal("description event test", @event.Description);
    Assert.Equal(EventType.Face2Face, @event.EventType);
    Assert.Equal(DateTime.Parse("2022-01-01T18:00:00.0000000Z").ToUniversalTime(), @event.StartTimeUtc);
    Assert.Equal(DateTime.Parse("2022-01-01T19:00:00.0000000Z").ToUniversalTime(), @event.EndTimeUtc);
    Assert.Equal(Guid.Parse("5ebf0600-c390-4b16-945d-eb0e734cf51c"), @event.CityId);
    Assert.Equal(Guid.Parse("8217f508-c17d-431e-9cf0-05ca8984971b"), @event.CountryId);
    Assert.Equal("-5.0", @event.UtcOffset);
    Assert.Equal(6.291, @event.Latitude);
    Assert.Equal(-75.536, @event.Longitude);
  }

  //
  [Fact]
  public void Event_AddInvitation_Successfully()
  {
    // Arrange

    // Act
    var @event = EventMother.Create();
    var invitation = InvitationMother.Create();
    @event.AddInvitation(invitation);
    // Assert
    Assert.NotNull(@event);
    Assert.Equal(Guid.Parse("a6daf43e-5eee-4473-a70c-6f890b20b79e"), @event.Id);
    Assert.Equal("event test", @event.Name);
    Assert.Equal("description event test", @event.Description);
    Assert.Equal(EventType.Face2Face, @event.EventType);
    Assert.Equal(DateTime.Parse("2022-01-01T18:00:00.0000000Z").ToUniversalTime(), @event.StartTimeUtc);
    Assert.Equal(DateTime.Parse("2022-01-01T19:00:00.0000000Z").ToUniversalTime(), @event.EndTimeUtc);
    Assert.Equal(Guid.Parse("5ebf0600-c390-4b16-945d-eb0e734cf51c"), @event.CityId);
    Assert.Equal(Guid.Parse("8217f508-c17d-431e-9cf0-05ca8984971b"), @event.CountryId);
    Assert.Equal("-5.0", @event.UtcOffset);
    Assert.Equal(6.291, @event.Latitude);
    Assert.Equal(-75.536, @event.Longitude);
    // Assert invitation
    Assert.Collection(@event.Invitation, one =>
      {
        Assert.Equal("developer_one@yopmail.com", one.Email);
        Assert.Equal(InvitationStatus.Pending, one.Status);
      }
    );
  }
}
