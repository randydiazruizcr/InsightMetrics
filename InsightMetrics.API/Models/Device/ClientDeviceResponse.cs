using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Device
{
    public class ClientDeviceResponse
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Id { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "aadDeviceId", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AadDeviceId { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "defenderDeviceId", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string DefenderDeviceId { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "graphDeviceId", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string GraphDeviceId { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "deviceName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string DeviceName { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "osPlatform", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string OsPlatform { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "osVersion", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string OsVersion { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "osProcessor", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string OsProcessor { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "version", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Version { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "healthStatus", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string HealthStatus { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "onboardingStatus", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string OnboardingStatus { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "exposureLevel", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ExposureLevel { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "managedBy", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ManagedBy { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "isCompliant", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsCompliant { get; set; }

        [JsonProperty(PropertyName = "isManaged", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsManaged { get; set; }

        [JsonProperty(PropertyName = "supported", NullValueHandling = NullValueHandling.Ignore)]
        public bool Supported { get; set; }

        [JsonProperty(PropertyName = "firstSeen", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime FirstSeen { get; set; } = DateTime.MinValue;

        [JsonProperty(PropertyName = "lastSeen", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime LastSeen { get; set; } = DateTime.MinValue;
    }
}
