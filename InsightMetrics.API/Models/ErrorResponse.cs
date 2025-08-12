using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace InsightMetrics.API.Models
{
    /// <summary>
    /// Represents a standard error response for API requests.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Indicates if the request was unsuccessful.
        /// </summary>
        [SwaggerSchema("Indicates if the request was unsuccessful")]
        [JsonProperty(PropertyName = "error", NullValueHandling = NullValueHandling.Ignore)]
        public bool Error { get; set; } = true;

        /// <summary>
        /// A description of the error that occurred.
        /// </summary>
        [SwaggerSchema("Description of the error")]
        [JsonProperty(PropertyName = "error_description", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorDescription { get; set; } = default!;

        /// <summary>
        /// Optional user email extracted from the JWT token, if available.
        /// </summary>
        [SwaggerSchema("Optional user email from JWT token")]
        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string? Email { get; set; }

        /// <summary>
        /// UTC timestamp of when the error occurred.
        /// </summary>
        [SwaggerSchema("UTC timestamp of the error")]
        [JsonProperty(PropertyName = "timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// A unique trace identifier that can be used for debugging and correlation.
        /// </summary>
        [SwaggerSchema("Trace ID to help with debugging")]
        [JsonProperty(PropertyName = "trace_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TraceId { get; set; } = Guid.NewGuid().ToString();
    }
}
