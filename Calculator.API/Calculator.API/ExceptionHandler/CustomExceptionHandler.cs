// // <copyright file="ExceptionHandler.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>26-01-2021</date>
// // <summary>ExceptionHandler.cs</summary>

using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
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
      {
        app.Use(WriteDevelopmentResponse);
      }
      else
      {
        app.Use(WriteProductionResponse);
      }
    }

    private static Task WriteDevelopmentResponse(HttpContext httpContext, Func<Task> next)
      => WriteResponse(httpContext, includeDetails: true);

    private static Task WriteProductionResponse(HttpContext httpContext, Func<Task> next)
      => WriteResponse(httpContext, includeDetails: false);

    private static async Task WriteResponse(HttpContext httpContext, bool includeDetails)
    {
      var exceptionDetails = httpContext.Features.Get<IExceptionHandlerFeature>();
      var ex = exceptionDetails?.Error;

      if (ex != null)
      {
        httpContext.Response.ContentType = "application/problem+json";

        var problem = GetProblemDetails(ex, includeDetails);

        var traceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier;
        if (traceId != null)
        {
          problem.Extensions["traceId"] = traceId;
        }
        
        var stream = httpContext.Response.Body;
        await JsonSerializer.SerializeAsync(stream, problem);
      }
    }

    private static ProblemDetails GetProblemDetails(Exception exception, bool includeDetails)
    {
      var title = includeDetails ? "An error occured: " + exception.Message : "An error occured";
      var details = includeDetails ? exception.ToString() : null;
      var problemDetails = new ProblemDetails
      {
        Title = title,
        Detail = details
      };

      switch (exception)
      {
        case ValidationException _:
        {
          problemDetails.Status = StatusCodes.Status400BadRequest;
          break;
        }
        default:
        {
          problemDetails.Status = StatusCodes.Status500InternalServerError;
          break;
        }
      }

      return problemDetails;
    }
  }
}