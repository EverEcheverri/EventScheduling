namespace EventScheduling.Infrastructure.Test.EntityFramework.Event;

using System.Linq;
using System.Linq.Expressions;
using Domain.Event;
using Domain.Event.Enums;
using Domain.Event.Repositories;
using EventScheduling.Test.Data.Event;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Event.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

public class EventRepositoryTest
{
    private readonly Mock<IConfiguration> _configurationMock;
    private readonly Mock<IInvitationRepository> _invitationRepository;
    private readonly DbContextOptions<EventSchedulingDbContext> _options;
    private IEventRepository _eventRepository;

    public EventRepositoryTest()
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

        _invitationRepository = new Mock<IInvitationRepository>();
    }

    [Fact]
    public async Task FileRepository_GetByEmailAsync_Returns_User()
    {
        // Arrange
        var eventOne = EventMother.Create();
        var invitationOne = InvitationMother.Create();
        var invitationTwo = InvitationMother.Create("64ed394c-bd88-4067-a0d9-3efc91bde6c0", "developer_two@yopmail.com");
        eventOne.AddInvitation(invitationOne);
        eventOne.AddInvitation(invitationTwo);

        var eventTwo = EventMother.Create("29ca376a-53a6-4363-97cd-20d84b6c94a1");
        var invitationThree = InvitationMother.Create("f3ad6e7e-2af3-4ff2-aa8f-c0c066882656");
        var invitationFour = InvitationMother.Create("b25feb5e-c7d3-4bee-a816-fa931baa4e58", "developer_two@yopmail.com");
        eventTwo.AddInvitation(invitationThree);
        eventTwo.AddInvitation(invitationFour);

        await using var context = new EventSchedulingDbContext(_options, _configurationMock.Object);
        await context.Event.AddAsync(eventOne);
        await context.Event.AddAsync(eventTwo);
        await context.SaveChangesAsync();

        await using var contextAssert = new EventSchedulingDbContext(_options, _configurationMock.Object);
        _eventRepository = new EventRepository(contextAssert, _invitationRepository.Object);

        // Act
        Expression<Func<Event, bool>> predicateOne = e => e.Name == "event test";
        var eventResult = await _eventRepository.GetAsync(predicateOne, CancellationToken.None);

        //p => mySearchFilter.CategoryIds.Contains(p.CategoryId)
        Expression<Func<Event, bool>> predicateTwo = e => e.Invitation.Contains(invitationTwo);

        var eventTwoResult = await _eventRepository.GetAsync(predicateTwo, CancellationToken.None);

        // Assert File
        Assert.Equal("event test", eventOne.Name);
    }
}
