using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Zoho
{
    /// <summary>
    /// Represents the result of a query for Zoho tickets, including a summary and detailed ticket list.
    /// </summary>
    public class ZohoTicketResult
    {
        /// <summary>
        /// Gets or sets the total number of tickets retrieved.
        /// </summary>
        [JsonProperty(PropertyName = "total", NullValueHandling = NullValueHandling.Ignore)]
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the summary list grouping tickets by their status or other criteria.
        /// </summary>
        [JsonProperty(PropertyName = "summary", NullValueHandling = NullValueHandling.Ignore)]
        public List<ZohoTicketSummary> Summary { get; set; } = [];

        /// <summary>
        /// Gets or sets the list of detailed Zoho ticket items.
        /// </summary>
        [JsonProperty(PropertyName = "tickets", NullValueHandling = NullValueHandling.Ignore)]
        public List<ZohoTicketItem> Tickets { get; set; } = [];
    }
}
