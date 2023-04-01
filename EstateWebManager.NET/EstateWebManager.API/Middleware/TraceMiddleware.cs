using EstateWebManager.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace EstateWebManager.API.Middleware
{
    public class TraceMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<TraceMiddleware> _logger;

        public TraceMiddleware(RequestDelegate next, ILogger<TraceMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            DateTime start = DateTime.Now;
            string traceId = httpContext.TraceIdentifier;
            string method = httpContext.Request.Method;
            string host = httpContext.Request.Host.Host + httpContext.Request.Path;
            string query;
            if (!httpContext.Request.QueryString.HasValue)
            {
                query = "[none]";
            }
            else query = httpContext.Request.QueryString.ToString();

            _logger.LogInformation("[{TraceId}][{TimeStamp}]\n\tClient requested {method} from {host} with query params {query}", traceId, DateTime.Now, method, host, query);

            await _next.Invoke(httpContext);

            traceId = httpContext.TraceIdentifier;
            int statusCode = httpContext.Response.StatusCode;
            double responseTime = (DateTime.Now - start).TotalSeconds;

            _logger.LogInformation("[{TraceId}][{TimeStamp}]\n\tServer responded to client with status code {statusCode} in {responseTime} seconds", traceId, DateTime.Now, statusCode, responseTime);
        }
    }

    public static class GlobalTraceMiddleware
    {
        public static IApplicationBuilder UseGlobalTraceMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TraceMiddleware>();
        }
    }
}
