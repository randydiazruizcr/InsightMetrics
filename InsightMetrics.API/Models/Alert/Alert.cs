using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Alert
{
    public class Alert
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "severity", NullValueHandling = NullValueHandling.Ignore)]
        public string Severity { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "productName", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductName { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "createdDateTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedDateTime { get; set; }

        [JsonProperty(PropertyName = "lastUpdateDateTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime LastUpdateDateTime { get; set; }
    }
}
