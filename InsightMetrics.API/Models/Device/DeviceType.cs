using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace InsightMetrics.API.Models.Device
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DeviceType
    {
        Supported,
        Unsupported,
    }
}
