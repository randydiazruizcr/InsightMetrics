using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Device
{
    public class DeviceRequest
    {
        [JsonProperty(PropertyName = "clientId", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientId { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "continuationToken", NullValueHandling = NullValueHandling.Ignore)]
        public string? ContinuationToken { get; set; }

        [JsonProperty(PropertyName = "deviceType", NullValueHandling = NullValueHandling.Ignore)]
        public DeviceType DeviceType { get; set; }
    }
}
