using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Escalation
{
    public class EscalatedSummary
    {
        [JsonProperty(PropertyName = "total", NullValueHandling = NullValueHandling.Ignore)]
        public int Total { get; set; }
    }
}
