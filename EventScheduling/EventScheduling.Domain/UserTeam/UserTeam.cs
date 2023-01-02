namespace EventScheduling.Domain.UserTeam;

using User;

public sealed class UserTeam
{
  private readonly List<User> _users = new();
  private UserTeam(Guid teamId, string email)
  {
    TeamId = teamId;
    Email = email;
  }

  public Guid TeamId { get; }
  public string Email { get; }

  public static UserTeam Build(Guid teamId, string email)
  {

    var userTeam = new UserTeam(teamId, email);
    return userTeam;
  }
}
