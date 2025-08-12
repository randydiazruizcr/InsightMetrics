using Newtonsoft.Json;
using Serilog.Context;
using System.Diagnostics;
using System.Net;
using System.Net.Mime;

namespace InsightMetrics.API.Utils
{

    /// <summary>
    /// Middleware that adds context to logs for every HTTP request.
    /// This includes information such as Correlation ID, request path, HTTP method, 
    /// user IP, user agent, request duration, and hostname.
    /// </summary>
    public class ErrorHandlingMiddleware(RequestDelegate Next, ILogger<ErrorHandlingMiddleware> logger)
    {
        private readonly RequestDelegate _Next = Next;
        private readonly ILogger<ErrorHandlingMiddleware> _Logger = logger;
        private const string CorrelationHeader = "X-Correlation-ID";
        private const string ForwardedForHeader = "X-Forwarded-For";

        /// <summary>
        /// Handles the incoming HTTP request, adding relevant information to the logs.
        /// Generates or retrieves a Correlation ID, measures the request duration. 
        /// Upon completion, it logs the relevant details of the request for analysis purposes.
        /// </summary>
        /// <param name="HttpContext">The current HTTP context.</param>
        /// <returns>A task representing the execution of this middleware.</returns>
        /// <remarks>
        /// This middleware adds the CorrelationId to Serilog logs to facilitate tracing and
        /// diagnosing requests across different services or systems.
        /// </remarks>
        public async Task InvokeAsync(HttpContext HttpContext)
        {
            var correlationId = HttpContext.Request.Headers.TryGetValue(CorrelationHeader, out var value)
                ? value.ToString()
                : Guid.NewGuid().ToString();

            HttpContext.Request.Headers[CorrelationHeader] = correlationId;

            var userId = HttpContext.User?.Identity?.Name ?? "Anonymous";
            var ipAddress = HttpContext.Request.Headers.TryGetValue(ForwardedForHeader, out var forwardedFor)
                ? forwardedFor.ToString().Split(',')[0].Trim()
                : HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
            var userAgent = HttpContext.Request.Headers.UserAgent.ToString();

            var stopwatch = Stopwatch.StartNew();

            try
            {
                using (LogContext.PushProperty("correlationId", correlationId))
                using (LogContext.PushProperty("requestPath", HttpContext.Request.Path))
                using (LogContext.PushProperty("httpMethod", HttpContext.Request.Method))
                using (LogContext.PushProperty("userId", userId))
                using (LogContext.PushProperty("ipAddress", ipAddress))
                using (LogContext.PushProperty("userAgent", userAgent))
                using (LogContext.PushProperty("hostName", Dns.GetHostName()))
                {
                    await _Next(HttpContext);
                }
            }
            catch (Exception ex)
            {
                stopwatch.Stop();

                using (LogContext.PushProperty("RequestDuration", stopwatch.ElapsedMilliseconds))
                {
                    _Logger.LogError(ex, "An unhandled exception occurred while processing the request.");

                    HttpContext.Response.ContentType = MediaTypeNames.Application.Json;
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    var errorResponse = new
                    {
                        correlationId,
                        message = "An unexpected error occurred.",
                        detail = ex.Message
                    };

                    var json = JsonConvert.SerializeObject(errorResponse);
                    await HttpContext.Response.WriteAsync(json);
                }
            }
        }
    }
}
