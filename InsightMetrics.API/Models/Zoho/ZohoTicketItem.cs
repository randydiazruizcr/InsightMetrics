using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Zoho
{
    /// <summary>
    /// Represents a ticket item retrieved from Zoho Desk.
    /// </summary>
    public class ZohoTicketItem
    {
        /// <summary>
        /// Gets or sets the unique identifier of the ticket.
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the subject or title of the ticket.
        /// </summary>
        [JsonProperty(PropertyName = "subject", NullValueHandling = NullValueHandling.Ignore)]
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the current status of the ticket.
        /// </summary>
        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the priority level of the ticket.
        /// </summary>
        [JsonProperty(PropertyName = "priority", NullValueHandling = NullValueHandling.Ignore)]
        public string Priority { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the timestamp associated with the ticket, usually representing the creation or last update time.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the creation time of the ticket.
        /// </summary>
        [JsonProperty(PropertyName = "created_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Gets or sets the last updated time of the ticket.
        /// </summary>
        [JsonProperty(PropertyName = "updated_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedTime { get; set; }
    }
}
