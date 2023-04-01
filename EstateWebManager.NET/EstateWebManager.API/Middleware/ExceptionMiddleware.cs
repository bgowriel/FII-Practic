using EstateWebManager.Domain.Exceptions;
using System.Net;

namespace EstateWebManager.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception e)
            {
                _logger.LogError(e, message: e.Message);
                await HandleGlobalExceptionAsync(httpContext, e);
            }
        }

        private static async Task HandleGlobalExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;//de returnat codul specific

            await context.Response.WriteAsync("Response status: " + context.Response.StatusCode.ToString());
            await context.Response.WriteAsync(exception.Message);
            if (exception.InnerException != null) await context.Response.WriteAsync(exception.InnerException.Message);
            if (exception.StackTrace != null) await context.Response.WriteAsync(exception.StackTrace);
        }
    }

    public static class GlobalExceptionMiddleware
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
