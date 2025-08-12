using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Alert
{
    public class AlertSummaryResponse
    {
        [JsonProperty(PropertyName = "postTuningAlerts", NullValueHandling = NullValueHandling.Ignore)]
        public int PostTuningAlerts { get; set; }

        [JsonProperty(PropertyName = "handledAutomatically", NullValueHandling = NullValueHandling.Ignore)]
        public int HandledAutomatically { get; set; }

        [JsonProperty(PropertyName = "escalated", NullValueHandling = NullValueHandling.Ignore)]
        public int Escalated { get; set; }

        [JsonProperty(PropertyName = "rawAlerts", NullValueHandling = NullValueHandling.Ignore)]
        public int RawAlerts { get; set; }

        [JsonProperty(PropertyName = "tunedOut", NullValueHandling = NullValueHandling.Ignore)]
        public int TunedOut { get; set; }

        [JsonProperty(PropertyName = "remaining", NullValueHandling = NullValueHandling.Ignore)]
        public int Remaining { get; set; }
    }
}
