namespace EventScheduling.Api.Middleware;

using Domain.SharedKernel.Exceptions;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class ExceptionMiddleware
{
  private readonly ILogger<ExceptionMiddleware> _logger;
  private readonly RequestDelegate _next;

  public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
  {
    _next = next;
    _logger = logger;
  }

  public async Task Invoke(HttpContext httpContext)
  {
    if (httpContext == null)
    {
      return;
    }

    try
    {
      await _next(httpContext);
    }
    catch (Exception ex)
    {
      if (httpContext.Response.HasStarted)
      {
        _logger.LogWarning(
          "The response has already started, the http status code middleware will not be executed.");
        throw;
      }

      if (ex is BusinessException)
      {
        _logger.LogError(ex.Message);
        await httpContext.Response.FileManagerErrorResponseAsync(ex);
      }
      else
      {
        _logger.LogWarning(LoggingEvents.Unknown, "Exception not controlled or logged");
        _logger.LogError(ex, ex.Message);
        await httpContext.Response.FileManagerErrorResponseAsync(ex);
      }
    }
  }
}
