using ForsyteIT.Guardian.Models.Report;
using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Device
{
    public class DeviceReportResponse
    {
        [JsonProperty(PropertyName = "clientName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ClientName { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "supportedDevices", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ClientDeviceData SupportedDevices { get; set; } = new ClientDeviceData();

        [JsonProperty(PropertyName = "NoSupportedDevices", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ClientDeviceData NoSupportedDevices { get; set; } = new ClientDeviceData();

        [JsonProperty(PropertyName = "createdDateTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedDateTime { get; set; }

        [JsonProperty(PropertyName = "lastUpdateDateTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime LastUpdateDateTime { get; set; }
    }
}
