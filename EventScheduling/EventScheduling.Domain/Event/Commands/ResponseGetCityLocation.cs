namespace EventScheduling.Domain.Event.Commands;

public class ResponseGetCityLocation
{
  public Request request { get; set; }
  public Location location { get; set; }
}

public class Request
{
  public string type { get; set; }
  public string query { get; set; }
}

public class Location
{
  public string name { get; set; }
  public string country { get; set; }
  public string region { get; set; }
  public string lat { get; set; }
  public string lon { get; set; }
  public string timezone_id { get; set; }
  public string localtime { get; set; }
  public string utc_offset { get; set; }
}
