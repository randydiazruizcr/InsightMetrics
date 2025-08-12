using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Zoho
{
    /// <summary>
    /// Represents a summary of Zoho tickets grouped by their status.
    /// </summary>
    public class ZohoTicketSummary
    {
        /// <summary>
        /// Gets or sets the status name of the ticket group.
        /// </summary>
        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the count of tickets for the specified status.
        /// </summary>
        [JsonProperty(PropertyName = "count", NullValueHandling = NullValueHandling.Ignore)]
        public int Count { get; set; }
    }
}
