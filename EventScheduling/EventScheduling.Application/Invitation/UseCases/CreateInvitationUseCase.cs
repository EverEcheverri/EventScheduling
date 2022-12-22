namespace EventScheduling.Application.Invitation.UseCases;

using Domain.Event;
using Domain.Event.Commands;
using Domain.Event.Enums;
using Domain.Event.Repositories;
using Domain.User.Repositories;
using Event.Exceptions;
using EventScheduling.Application.Invitation.Exceptions;
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

  public async Task ExecuteAsync(CreateInvitationCommand invitationCommand, CancellationToken cancellationToken)
  {
    cancellationToken.ThrowIfCancellationRequested();
    var @event = await _eventRepository.GetByIdAsync(invitationCommand.EventId, cancellationToken);
    if (@event == null)
    {
      throw new EventDoesNotExistException(invitationCommand.EventId);
    }

    var user = await _userRepository.GetWithTimeZoneIdAsync(invitationCommand.Email, cancellationToken);
    if (user == null)
    {
      throw new UserEmailDoesNotExistException(invitationCommand.Email);
    }

    var convertedStartTime =
      TimeZoneInfo.ConvertTimeFromUtc(@event.StartTimeUtc, TimeZoneInfo.FindSystemTimeZoneById(user.TimeZoneId));
    var convertedEndTime =
      TimeZoneInfo.ConvertTimeFromUtc(@event.EndTimeUtc, TimeZoneInfo.FindSystemTimeZoneById(user.TimeZoneId));

    var invitation = await _invitationRepository.GetByEventIdAndEmailAsync(invitationCommand.EventId,
      invitationCommand.Email, cancellationToken);

    if (invitation != null)
    {
      throw new InvitationAlreadyExistException(invitation.Id);
    }

    invitation = Invitation.Build(invitationCommand.InvitationId, invitationCommand.Email,
      InvitationStatus.Pending, convertedStartTime, convertedEndTime);
    @event.AddInvitation(invitation);

    await _eventRepository.UpdateAsync(@event, cancellationToken);
  }
}
