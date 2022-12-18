namespace EventScheduling.Application.Invitation.UseCases;

using Domain.Event;
using Domain.Event.Commands;
using Domain.Event.Repositories;
using Domain.User.Repositories;
using Event.Exceptions;
using Interfaces;
using User.Exceptions;

public class CreateInvitationUseCase : ICreateInvitation
{
  private readonly IEventRepository _eventRepository;
  private readonly IInvitationRepository _invitationRepository;
  private readonly IUserRepository _userRepository;

  public CreateInvitationUseCase(IEventRepository eventRepository, IUserRepository userRepository,
    IInvitationRepository invitationRepository)
  {
    _eventRepository = eventRepository;
    _userRepository = userRepository;
    _invitationRepository = invitationRepository;
  }

  public async Task ExecuteAsync(CreateInvitationCommand createInvitationCommand, CancellationToken cancellationToken)
  {
    var @event = await _eventRepository.GetByIdAsync(createInvitationCommand.EventId, cancellationToken);
    if (@event == null)
    {
      throw new EventDoesNotExistException(createInvitationCommand.EventId);
    }

    var user = await _userRepository.GetByEmailAsync(createInvitationCommand.Email, cancellationToken);
    if (user == null)
    {
      throw new UserEmailDoesNotExistException(createInvitationCommand.Email);
    }

    var convertedStartTime = @event.StartTimeUtc;
    var convertedEndTime = @event.EndTimeUtc;

    var invitation = await _invitationRepository.GetByEventIdAndEmailAsync(createInvitationCommand.EventId,
      createInvitationCommand.Email, cancellationToken);
    if (invitation == null)
    {
      invitation = Invitation.Build(createInvitationCommand.Id, createInvitationCommand.Email,
        "Pending", convertedStartTime, convertedEndTime);
      @event.AddInvitation(invitation);
    }
    else
    {
      invitation.UpdateDates(convertedStartTime, convertedEndTime);
    }


    await _eventRepository.UpdateAsync(@event, cancellationToken);
  }
}

/*
DateTime utcTime = DateTime.Parse("2022-12-17 18:00:00.000");

//done
var byIdAsuncionTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, TimeZoneInfo.FindSystemTimeZoneById("America/Asuncion"));
Console.WriteLine($"hora Asuncion: {byIdAsuncionTime}");

var byIdMontevideoTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, TimeZoneInfo.FindSystemTimeZoneById("America/Montevideo"));
Console.WriteLine($"hora Montevideo: {byIdMontevideoTime}");

var byIdLimaTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, TimeZoneInfo.FindSystemTimeZoneById("America/Lima"));
Console.WriteLine($"hora Lima: {byIdLimaTime}");

var byIdBogotaTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, TimeZoneInfo.FindSystemTimeZoneById("America/Bogota"));
Console.WriteLine($"hora Bogota: {byIdBogotaTime}");
 
 */
