using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Escalation
{
    public class EscalationResponse
    {
        [JsonProperty(PropertyName = "escalated", NullValueHandling = NullValueHandling.Ignore)]
        public EscalatedSummary Escalated { get; set; } = new EscalatedSummary();

        [JsonProperty(PropertyName = "breakDown", NullValueHandling = NullValueHandling.Ignore)]
        public List<EscalationBreakDown> BreakDown { get; set; } = [];

        [JsonProperty(PropertyName = "escalations", NullValueHandling = NullValueHandling.Ignore)]
        public List<Escalation> Escalations { get; set; } = [];

        [JsonProperty(PropertyName = "timing", NullValueHandling = NullValueHandling.Ignore)]
        public EscalatedTimming Timing { get; set; } = new EscalatedTimming();
    }
}
