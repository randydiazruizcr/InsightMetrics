using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Auth
{
    public class TokenRequest
    {
        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string? Email { get; set; } = null!;
    }
}
