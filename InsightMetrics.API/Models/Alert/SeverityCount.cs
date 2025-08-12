using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Alert
{
    public class SeverityCount
    {
        [JsonProperty(PropertyName = "severity", NullValueHandling = NullValueHandling.Ignore)]
        public string Severity { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "count", NullValueHandling = NullValueHandling.Ignore)]
        public int Count { get; set; }
    }
}
