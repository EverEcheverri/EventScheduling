namespace EventScheduling.Infrastructure.EntityFramework;

using Configurations;
using Data;
using Domain.Team;
using Domain.User;
using Domain.UserTeam;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class EventSchedulingDbContext : DbContext
{
  protected readonly IConfiguration _configuration;

  public EventSchedulingDbContext(DbContextOptions<EventSchedulingDbContext> options,
    IConfiguration configuration)
    : base(options)
  {
    _configuration = configuration;
  }

  public DbSet<Domain.Country.Country> Country { get; set; }
  public DbSet<Domain.City.City> City { get; set; }
  public DbSet<Domain.User.User> User { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    var connectionString = GetConnectionStringPath();
    base.OnConfiguring(optionsBuilder);
    optionsBuilder.UseSqlite($"Data Source={connectionString};");
    //optionsBuilder.EnableSensitiveDataLogging();
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfiguration(new CountryEntityTypeConfiguration());
    modelBuilder.ApplyConfiguration(new CityEntityTypeConfiguration());
    modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
    modelBuilder.ApplyConfiguration(new TeamEntityTypeConfiguration());
    modelBuilder.ApplyConfiguration(new UserTeamEntityTypeConfiguration());

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
    var absolutePath = Path.GetFullPath(relativePath!);
    return absolutePath;
  }
}
