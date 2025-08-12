using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Alert
{
    public class TopAlertCategory
    {
        [JsonProperty(PropertyName = "category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "count", NullValueHandling = NullValueHandling.Ignore)]
        public int Count { get; set; }
    }
}
