using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Compliance
{
    public class ComplianceScoreResponse
    {
        [JsonProperty(PropertyName = "tasks", NullValueHandling = NullValueHandling.Ignore)]
        public List<TaskDetail> Tasks { get; set; } = [];

        [JsonProperty(PropertyName = "total", NullValueHandling = NullValueHandling.Ignore)]
        public int Total { get; set; }

        [JsonProperty(PropertyName = "groupedByStatus", NullValueHandling = NullValueHandling.Ignore)]
        public List<StatusCount> GroupedByStatus { get; set; } = [];
    }
}
