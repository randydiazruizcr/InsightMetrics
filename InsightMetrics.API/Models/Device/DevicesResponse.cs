using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Device
{
    public class DevicesResponse
    {
        [JsonProperty(PropertyName = "deviceReport", NullValueHandling = NullValueHandling.Ignore)]
        public DeviceReportResponse DeviceReport { get; set; } = new();

        [JsonProperty(PropertyName = "devices", NullValueHandling = NullValueHandling.Ignore)]
        public List<ClientDeviceResponse> Devices { set; get; } = [];

        [JsonProperty(PropertyName = "continuationToken", NullValueHandling = NullValueHandling.Ignore)]
        public string? ContinuationToken { get; set; }
    }
}
