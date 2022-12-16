namespace EventScheduling.Api.Middleware;

using Microsoft.AspNetCore.Mvc;


public static class CustomBadRequest
{
  public static CustomErrorResponse ConstructErrorMessages(ActionContext context)
  {
    var allErrors = string.Join(" ",
      context.ModelState.Values
        .SelectMany(x => x.Errors)
        .Select(x => string.IsNullOrEmpty(x.ErrorMessage) ? "The input was not valid." : x.ErrorMessage));

    var errorString = $"One or more validation errors occurred: {allErrors}";
    return new CustomErrorResponse(LoggingEvents.GeneralValidationError, errorString);
  }
}
