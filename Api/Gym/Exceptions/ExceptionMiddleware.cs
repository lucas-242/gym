using Gym.Exceptions;
using System.Net;

namespace Gym.Api.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _environment;

        public ExceptionMiddleware(RequestDelegate next, IWebHostEnvironment environment)
        {
            _next = next;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (AppException ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, AppException exception)
        {
            context.Response.ContentType = "application/json";

            var result = new ErrorDetails()
            {
                Message = exception.Message,
                StatusCode = (int)exception.StatusCode,
                Details = GetDetailsAccordingToEnvironment(exception),
            }.ToString();

            context.Response.StatusCode = (int)exception.StatusCode;

            return context.Response.WriteAsync(result);
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            string result = new ErrorDetails()
            {
                Message = exception.Message,
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Details = GetDetailsAccordingToEnvironment(exception),
            }.ToString();

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return context.Response.WriteAsync(result);
        }

        private string? GetDetailsAccordingToEnvironment(Exception ex)
        {
            return _environment.IsDevelopment() ? ex.StackTrace : null;
        }
    }
}
