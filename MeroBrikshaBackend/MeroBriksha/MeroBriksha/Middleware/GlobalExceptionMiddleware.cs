using MeroBriksha.Models;
using MeroBriksha.Services.Services.Exceptions;
using System.Collections.ObjectModel;
using System.Net;
using System.Text.Json;

namespace MeroBriksha.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        private readonly IHostEnvironment _environment;
        private static readonly JsonSerializerOptions serializationOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public GlobalExceptionMiddleware(
            RequestDelegate next,
            ILogger<GlobalExceptionMiddleware> logger,
            IHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); //
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = exception switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound,
                ValidationException => (int)HttpStatusCode.BadRequest,
                //ConflictException => (int)HttpStatusCode.Conflict,
                _ => (int)HttpStatusCode.InternalServerError
            };

            if (statusCode == (int)HttpStatusCode.InternalServerError)
            {
                _logger.LogError(
                    exception,
                    "Unhandled exception occurred. TraceId: {TraceId}",
                    context.TraceIdentifier);
            }
            else
            {
                _logger.LogWarning(
                    exception,
                    "Handled exception occurred. StatusCode: {StatusCode}, TraceId: {TraceId}",
                    statusCode,
                    context.TraceIdentifier);
            }

            var response = new ApiErrorResponse
            {
                StatusCode = statusCode,
                Message = GetSafeMessage(exception, statusCode),
                TraceId = context.TraceIdentifier
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var json = JsonSerializer.Serialize(response, serializationOptions);

            await context.Response.WriteAsync(json); //write the json response to the HTTP response body
        }

        private string GetSafeMessage(Exception exception, int statusCode)
        {
            if (statusCode == (int)HttpStatusCode.InternalServerError)
            {
                return _environment.IsDevelopment()
                    ? exception.Message
                    : "An unexpected error occurred.";
            }

            return exception.Message;
        }
    }
}
 