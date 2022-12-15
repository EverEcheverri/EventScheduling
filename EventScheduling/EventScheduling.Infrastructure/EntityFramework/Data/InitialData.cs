﻿namespace EventScheduling.Infrastructure.EntityFramework.Data;

using Domain.City;
using Domain.Country;
using Domain.Team;
using Domain.User;
using Domain.User.Enums;
using Domain.UserTeam;

internal static class InitialData
{
  private static readonly Guid ColombiaId = Guid.Parse("8217f508-c17d-431e-9cf0-05ca8984971b");
  private static readonly Guid PeruId = Guid.Parse("e0007308-e1e3-4892-a5a7-883c02c6de22");
  private static readonly Guid UruguayId = Guid.Parse("c39c3b7178e94dcdbbbd35ac159f984b");
  private static readonly Guid ParaguayId = Guid.Parse("3eb63894-c376-4eea-923a-ac1f3bfc6235");

  private static readonly Guid MedellinId = Guid.Parse("5ebf0600-c390-4b16-945d-eb0e734cf51c");
  private static readonly Guid BogotaId = Guid.Parse("9b862593-628a-4bc1-8cc4-038e01f34241");
  private static readonly Guid LimaId = Guid.Parse("386a04f3-e4c4-4922-9e79-e75ac0fa3a6a");
  private static readonly Guid MontevideoId = Guid.Parse("102077ed-f0de-442c-8d97-fbb7dfd96d08");
  private static readonly Guid AsuncionId = Guid.Parse("0de67652-5cc0-42ca-8005-aa41b3a41802");

  private static readonly Guid TeamOneId = Guid.Parse("fc74ff91-3de6-4267-bce9-f390d3b0ca7c");
  private static readonly Guid TeamTwoId = Guid.Parse("7c9c3d92-40c1-4ac3-95dc-fd2916e1beda");

  internal static IEnumerable<Country> GetCountries()
  {
    return new List<Country>
    {
      Country.Build(ColombiaId, "Colombia"),
      Country.Build(PeruId, "Peru"),
      Country.Build(UruguayId, "Uruguay"),
      Country.Build(ParaguayId, "Paraguay"),
    };
  }

  internal static IEnumerable<City> GetCities()
  {
    return new List<City>
    {
      City.Build(MedellinId, "Medellin", ColombiaId),
      City.Build(BogotaId, "Bogota", ColombiaId),
      City.Build(LimaId, "Lima", PeruId),
      City.Build(MontevideoId, "Montevideo", UruguayId),
      City.Build(AsuncionId, "Asuncion", ParaguayId)
    };
  }

  internal static IEnumerable<User> GetUsers()
  {
    return new List<User>
    {
      User.Build("developer_one@yopmail.com", "developer_one", MedellinId, "111 1111111", UserRoles.Developer),
      User.Build("developer_two@yopmail.com", "developer_two", MedellinId, "222 2222222", UserRoles.Developer),
      User.Build("developer_three@yopmail.com", "developer_three", BogotaId, "333 3333333", UserRoles.Developer),
      User.Build("developer_four@yopmail.com", "developer_four", LimaId, "444 4444444", UserRoles.Developer),
      User.Build("developer_five@yopmail.com", "developer_five", MontevideoId, "555 5555555", UserRoles.Developer),
      User.Build("developer_six@yopmail.com", "developer_six", AsuncionId, "666 6666666", UserRoles.Developer),
      User.Build("qa_one@yopmail.com", "qa_one", AsuncionId, "777 7777777", UserRoles.QAEngineer)
    };
  }

  internal static IEnumerable<Team> GetTeams()
  {
    return new List<Team>
    {
      Team.Build(TeamOneId, "team_one"),
      Team.Build(TeamTwoId, "team_two")
    };
  }

  internal static IEnumerable<UserTeam> GetUserTeams() 
  {
    return new List<UserTeam>
    {
      UserTeam.Build(TeamOneId, "developer_one@yopmail.com"),
      UserTeam.Build(TeamOneId, "developer_two@yopmail.com"),
      UserTeam.Build(TeamOneId, "developer_four@yopmail.com"),
      UserTeam.Build(TeamOneId, "qa_one@yopmail.com"),

      UserTeam.Build(TeamTwoId, "developer_three@yopmail.com"),
      UserTeam.Build(TeamTwoId, "developer_five@yopmail.com"),
      UserTeam.Build(TeamTwoId, "developer_six@yopmail.com"),
      UserTeam.Build(TeamTwoId, "qa_one@yopmail.com")
    };
  }
}
