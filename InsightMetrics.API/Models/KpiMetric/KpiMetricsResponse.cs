using Newtonsoft.Json;

namespace InsightMetrics.API.Models.KpiMetric
{
    public class KpiMetricsResponse
    {
        [JsonProperty(PropertyName = "mttd", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Mttd { get; set; }

        [JsonProperty(PropertyName = "mttr", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Mttr { get; set; }

        [JsonProperty(PropertyName = "slaViolationTimeMttd", NullValueHandling = NullValueHandling.Ignore)]
        public decimal SlaViolationTimeMttd { get; set; }

        [JsonProperty(PropertyName = "slaViolationTimeMttr", NullValueHandling = NullValueHandling.Ignore)]
        public decimal SlaViolationTimeMttr { get; set; }
    }
}
