namespace EventScheduling.Domain.City.Commands;

public class CreateCityCommand
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public Guid CountryId { get; set; }
  public string TimeZoneId { get; set; }
}
