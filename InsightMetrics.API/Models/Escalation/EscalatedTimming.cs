using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Escalation
{
    public class EscalatedTimming
    {
        [JsonProperty(PropertyName = "handleSOC", NullValueHandling = NullValueHandling.Ignore)]
        public int HandledSOC { get; set; }

        [JsonProperty(PropertyName = "businessHours", NullValueHandling = NullValueHandling.Ignore)]
        public int BusinessHours { get; set; }

        [JsonProperty(PropertyName = "offHours", NullValueHandling = NullValueHandling.Ignore)]
        public int OffHours { get; set; }
    }
}
