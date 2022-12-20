namespace EventScheduling.Api.Middleware;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class CustomMiddleware
{
  private readonly ILogger<CustomMiddleware> _logger;
  private readonly RequestDelegate _next;

  public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger)
  {
    _next = next;
    _logger = logger;
  }

  public async Task Invoke(HttpContext httpContext)
  {
    var authHeader = httpContext.Request.Headers["Authorization"].ToString();

    _logger.Log(LogLevel.Warning, $"Authorization: {authHeader}");

    await _next(httpContext);
  }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class CustomMiddlewareExtensions
{
  public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
  {
    return builder.UseMiddleware<CustomMiddleware>();
  }
}
