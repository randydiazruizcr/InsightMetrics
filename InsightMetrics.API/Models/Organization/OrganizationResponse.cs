using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Organization
{
    public class OrganizationResponse
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "display_name", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "timeZone", NullValueHandling = NullValueHandling.Ignore)]
        public string TimeZone { get; set; } = string.Empty;
    }
}
