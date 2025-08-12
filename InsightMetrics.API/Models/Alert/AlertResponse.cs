using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Alert
{
    public class AlertResponse
    {
        [JsonProperty(PropertyName = "alerts", NullValueHandling = NullValueHandling.Ignore)]
        public List<Alert> Alerts { get; set; } = [];

        [JsonProperty(PropertyName = "total", NullValueHandling = NullValueHandling.Ignore)]
        public int Total { get; set; }

        [JsonProperty(PropertyName = "topAlertCategories", NullValueHandling = NullValueHandling.Ignore)]
        public List<TopAlertCategory> TopCategories { get; set; } = [];

        [JsonProperty(PropertyName = "dailySeverityGroup", NullValueHandling = NullValueHandling.Ignore)]
        public List<DailySeverityGroup> DailySeverityGroup { get; set; } = [];
    }
}
