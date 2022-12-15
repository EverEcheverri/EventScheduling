namespace EventScheduling.Domain.Team;

using User;

public sealed class Team
{
  private readonly List<User> _users = new();

  private Team(Guid id, string name)
  {
    Id = id;
    Name = name;
  }

  public Guid Id { get; set; }
  public string Name { get; set; }
  public IReadOnlyCollection<User> Users => _users;

  public static Team Build(Guid id, string name)
  {
    var team = new Team(id, name);
    return team;
  }
}
