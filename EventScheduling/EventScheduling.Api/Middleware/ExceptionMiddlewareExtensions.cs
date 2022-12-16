using System.Net;

namespace EventScheduling.Api.Middleware;

using EventScheduling.Application.City.Exceptions;
using EventScheduling.Application.User.Exceptions;
using Microsoft.Net.Http.Headers;

public static class ExceptionMiddlewareExtensions
{
  public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
  {
    return builder.UseMiddleware<ExceptionMiddleware>();
  }
  public static Task FileManagerErrorResponseAsync(this HttpResponse response,
      Exception businessException)
  {
    var (httpStatusCode, eventId) = GetResponseCode(businessException.GetType().Name);
    var message = $"{{\"code\": {eventId},\"message\":\"{businessException.Message}\"}}";
    response.Clear();
    response.StatusCode = (int)httpStatusCode;
    response.ContentType = "application/json";

    response.GetTypedHeaders().CacheControl =
      new CacheControlHeaderValue { NoStore = true, NoCache = true };

    response.WriteAsync(message);
    return Task.FromResult(response.StatusCode);
  }

  private static (HttpStatusCode, EventId) GetResponseCode(string exception)
  {
    return exception switch
    {
      // Conflict
      nameof(UserEmailAlreadyExistException) => (HttpStatusCode.Conflict, LoggingEvents.UserEmailAlreadyExist),
      nameof(CityAlreadyExistException) => (HttpStatusCode.Conflict, LoggingEvents.CityAlreadyExist),

      //Default
      _ => (HttpStatusCode.InternalServerError, LoggingEvents.Unknown)
    };
  }
}
