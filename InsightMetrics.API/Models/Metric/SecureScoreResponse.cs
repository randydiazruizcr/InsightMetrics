using ForsyteIT.CosmosAPI.Models.Guardian;
using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Metric
{
    public class SecureScoreResponse
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "currentScore", NullValueHandling = NullValueHandling.Ignore)]
        public double CurrentScore { get; set; }

        [JsonProperty(PropertyName = "maxScore", NullValueHandling = NullValueHandling.Ignore)]
        public double MaxScore { get; set; }

        [JsonProperty(PropertyName = "createdDateTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedDateTime { get; set; }
    }
}
