using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Compliance
{
    public class StatusCount
    {
        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "count", NullValueHandling = NullValueHandling.Ignore)]
        public int Count { get; set; }
    }
}
