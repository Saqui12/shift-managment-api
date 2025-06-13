
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Infrastructure.Middelware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var logger = context.RequestServices.GetService<ILogger<ErrorHandlingMiddleware>>();
   
              logger?.LogError(exception, "An unhandled exception occurred.");
        
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = exception switch
            {
                    
                    KeyNotFoundException => StatusCodes.Status404NotFound,
                    ArgumentNullException => 400,
                    FluentValidation.ValidationException => 400,
                    ArgumentException => 400,
                    InvalidOperationException => 409,
                    _ => 500 
                };

            ProblemDetails response = new()
            {

                Status =context.Response.StatusCode,
                Type=exception.GetType().Name,
                Title = "An error occurred while processing your request.",
                Detail = exception.Message 
            };
    
             await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
    
    
}
