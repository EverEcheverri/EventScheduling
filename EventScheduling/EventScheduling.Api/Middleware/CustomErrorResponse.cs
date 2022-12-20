namespace EventScheduling.Api.Middleware;

public class CustomErrorResponse
{
  public CustomErrorResponse(int code, string message)
  {
    Code = code;
    Message = message;
  }

  public int Code { get; }
  public string Message { get; }
}
