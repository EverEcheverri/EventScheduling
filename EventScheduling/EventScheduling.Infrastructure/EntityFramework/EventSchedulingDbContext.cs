namespace EventScheduling.Infrastructure.EntityFramework;

using Configurations;
using Data;
using Domain.Event;
using Domain.Team;
using Domain.UserTeam;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public class EventSchedulingDbContext : DbContext
{
  protected readonly IConfiguration _configuration;

  public EventSchedulingDbContext()
  {
    
  }

  public EventSchedulingDbContext(DbContextOptions<EventSchedulingDbContext> options,
    IConfiguration configuration)
    : base(options)
  {
    _configuration = configuration;
  }

  public DbSet<Domain.Country.Country> Country { get; set; }
  public DbSet<Domain.City.City> City { get; set; }
  public DbSet<Domain.User.User> User { get; set; }
  public DbSet<Domain.Event.Event> Event { get; set; }
  public DbSet<Invitation> Invitation { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    var connectionString = GetConnectionStringPath();
    base.OnConfiguring(optionsBuilder);
    optionsBuilder.UseSqlite($"Data Source={connectionString};")
      .LogTo(Console.WriteLine, LogLevel.Information);
    optionsBuilder.EnableSensitiveDataLogging();
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfiguration(new CountryEntityTypeConfiguration());
    modelBuilder.ApplyConfiguration(new CityEntityTypeConfiguration());
    modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
    modelBuilder.ApplyConfiguration(new TeamEntityTypeConfiguration());
    modelBuilder.ApplyConfiguration(new UserTeamEntityTypeConfiguration());
    modelBuilder.ApplyConfiguration(new EventEntityTypeConfiguration());
    modelBuilder.Entity<Invitation>().Configure();

    var cities = InitialData.GetCities();
    var countries = InitialData.GetCountries();
    var users = InitialData.GetUsers();
    var teams = InitialData.GetTeams();
    var userTeams = InitialData.GetUserTeams();

    modelBuilder.Entity<Domain.City.City>().HasData(cities);
    modelBuilder.Entity<Domain.Country.Country>().HasData(countries);
    modelBuilder.Entity<Domain.User.User>().HasData(users);
    modelBuilder.Entity<Team>().HasData(teams);
    modelBuilder.Entity<UserTeam>().HasData(userTeams);
  }

  public string GetConnectionStringPath()
  {
    var relativePath = _configuration.GetConnectionString("DefaultConnection");
    if (relativePath == null)
    {
      relativePath =
        "C:\\Projects\\Code Challenge\\EventScheduling\\EventScheduling.Infrastructure\\event-schedulingdb";
    }
    var absolutePath = Path.GetFullPath(relativePath!);
    return absolutePath;
  }
}
