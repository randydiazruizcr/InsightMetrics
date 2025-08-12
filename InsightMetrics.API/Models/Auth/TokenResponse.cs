using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace InsightMetrics.API.Models.Auth
{
    /// <summary>
    /// Represents the response returned after successful authentication containing the access token and related metadata.
    /// </summary>
    public class TokenResponse
    {
        /// <summary>
        /// The type of the token issued. Typically set to "Bearer".
        /// </summary>
        [SwaggerSchema("The type of token, typically 'Bearer'.")]
        [JsonProperty("token_type", NullValueHandling = NullValueHandling.Ignore)]
        public string TokenType { get; set; } = "Bearer";

        /// <summary>
        /// The lifetime in seconds of the access token.
        /// </summary>
        [SwaggerSchema("Duration in seconds until the token expires.")]
        [JsonProperty("expires_in", NullValueHandling = NullValueHandling.Ignore)]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// The extended expiration time in seconds (if supported).
        /// </summary>
        [SwaggerSchema("Extended expiration time in seconds.")]
        [JsonProperty("ext_expires_in", NullValueHandling = NullValueHandling.Ignore)]
        public int ExtExpiresIn { get; set; }

        /// <summary>
        /// The access token issued by the authorization server.
        /// </summary>
        [SwaggerSchema("The access token issued by the authorization server.")]
        [JsonProperty("access_token", NullValueHandling = NullValueHandling.Ignore)]
        public string AccessToken { get; set; } = string.Empty;
    }
}
