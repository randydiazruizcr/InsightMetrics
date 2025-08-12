using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Escalation
{
    public class Escalation
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "escalationName", NullValueHandling = NullValueHandling.Ignore)]
        public string EscalationName { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "severity", NullValueHandling = NullValueHandling.Ignore)]
        public string Severity { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "method", NullValueHandling = NullValueHandling.Ignore)]
        public string Method { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "falsePositive", NullValueHandling = NullValueHandling.Ignore)]
        public bool FalsePositive { get; set; }

        [JsonProperty(PropertyName = "product")]
        public string? Product { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "resolvedTime")]
        public DateTime? ResolvedTime { get; set; }

        [JsonProperty(PropertyName = "created_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedTime { get; set; }

        [JsonProperty(PropertyName = "updated_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedTime { get; set; }
    }
}
