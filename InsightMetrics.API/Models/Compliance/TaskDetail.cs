using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Compliance
{
    public class TaskDetail
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "workload", NullValueHandling = NullValueHandling.Ignore)]
        public string Workload { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "onboardingRequirement", NullValueHandling = NullValueHandling.Ignore)]
        public bool OnboardingRequirement { get; set; }

        [JsonProperty(PropertyName = "notes", NullValueHandling = NullValueHandling.Ignore)]
        public string Notes { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "created_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedTime { get; set; }

        [JsonProperty(PropertyName = "updated_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedTime { get; set; }
    }
}
