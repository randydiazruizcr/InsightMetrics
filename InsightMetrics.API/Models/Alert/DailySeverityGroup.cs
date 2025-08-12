using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Alert
{
    public class DailySeverityGroup
    {
        [JsonProperty(PropertyName = "date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "severities", NullValueHandling = NullValueHandling.Ignore)]
        public List<SeverityCount> Severities { get; set; } = [];
    }
}
