using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Auth
{
    /// <summary>
    /// Generic service result wrapper for handling operation outcomes with optional data.
    /// </summary>
    /// <typeparam name="T">The type of the result data.</typeparam>
    public class ServiceResult<T>
    {
        /// <summary>
        /// Indicates whether the service operation was successful.
        /// </summary>
        [JsonProperty(PropertyName = "success", NullValueHandling = NullValueHandling.Ignore)]
        public bool Success { get; set; }

        /// <summary>
        /// A message describing the result or error.
        /// </summary>
        [JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
        public string? Message { get; set; }

        /// <summary>
        /// The result data returned from the service operation, if any.
        /// </summary>
        [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
        public T? Data { get; set; }

        /// <summary>
        /// Creates a successful <see cref="ServiceResult{T}"/> with a message and data.
        /// </summary>
        /// <param name="message">A success message.</param>
        /// <param name="data">The data to return.</param>
        /// <returns>A successful service result.</returns>
        public static ServiceResult<T> Ok(string message, T data) =>
            new()
            {
                Success = true,
                Message = message,
                Data = data
            };

        /// <summary>
        /// Creates a failed <see cref="ServiceResult{T}"/> with a message.
        /// </summary>
        /// <param name="message">An error message.</param>
        /// <returns>A failed service result.</returns>
        public static ServiceResult<T> Fail(string message) =>
            new()
            {
                Success = false,
                Message = message
            };
    }
}
