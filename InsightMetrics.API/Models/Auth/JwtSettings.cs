using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Auth
{
    /// <summary>
    /// Represents settings for JWT authentication.
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// Gets or sets the secret key used for signing the JWT.
        /// </summary>
        [JsonProperty(PropertyName = "key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the issuer of the JWT.
        /// </summary>
        [JsonProperty(PropertyName = "issuer", NullValueHandling = NullValueHandling.Ignore)]
        public string Issuer { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the audience of the JWT.
        /// </summary>
        [JsonProperty(PropertyName = "audience", NullValueHandling = NullValueHandling.Ignore)]
        public string Audience { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the expiry time of the JWT in minutes.
        /// </summary>
        [JsonProperty(PropertyName = "expiry_minutes", NullValueHandling = NullValueHandling.Ignore)]
        public int ExpiryMinutes { get; set; }
    }
}
