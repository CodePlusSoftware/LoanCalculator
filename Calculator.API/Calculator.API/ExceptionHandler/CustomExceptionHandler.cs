using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using Calculator.Business.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Calculator.API.ExceptionHandler
{
  public static class CustomExceptionHandler
  {
    public static void UseCustomErrors(this IApplicationBuilder app, IHostEnvironment environment)
    {
      if (environment.IsDevelopment())
        app.Use(WriteDevelopmentResponse);
      else
        app.Use(WriteProductionResponse);
    }

    private static Task WriteDevelopmentResponse(HttpContext httpContext, Func<Task> next)
    {
      return WriteResponse(httpContext, true);
    }

    private static Task WriteProductionResponse(HttpContext httpContext, Func<Task> next)
    {
      return WriteResponse(httpContext, false);
    }

    private static async Task WriteResponse(HttpContext httpContext, bool includeDetails)
    {
      var exceptionDetails = httpContext.Features.Get<IExceptionHandlerFeature>();
      var ex = exceptionDetails?.Error;

      if (ex != null)
      {
        httpContext.Response.ContentType = "application/problem+json";

        var problem = GetProblemDetails(ex, includeDetails);
        httpContext.Response.StatusCode = problem.Status ?? StatusCodes.Status500InternalServerError;
        var traceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier;
        if (traceId != null) problem.Extensions["traceId"] = traceId;

        var stream = httpContext.Response.Body;
        await JsonSerializer.SerializeAsync(stream, problem);
      }
    }

    private static ProblemDetails GetProblemDetails(Exception exception, bool includeDetails)
    {
      var includeMessage = false;
      var status = StatusCodes.Status500InternalServerError;

      switch (exception)
      {
        case ValidationException _:
        case UndefinedPlanException _:
        {
          includeMessage = true;
          status = StatusCodes.Status400BadRequest;
          break;
        }
        case InvalidPeriodException _:
        {
          status = StatusCodes.Status422UnprocessableEntity;
          includeDetails = true;
          break;
        }
        case ItemNotFoundException _:
        {
          status = StatusCodes.Status404NotFound;
          break;
        }
        default:
        {
          status = StatusCodes.Status500InternalServerError;
          break;
        }
      }

      var title = includeMessage ? $"An error occured {exception.Message}" : "An error occured";
      var details = includeDetails ? exception.ToString() : null;

      var problemDetails = new ProblemDetails
      {
        Title = title,
        Detail = details,
        Status = status
      };

      return problemDetails;
    }
  }
}