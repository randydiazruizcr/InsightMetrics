using InsightMetrics.API.Models.Zoho;

namespace InsightMetrics.API.Services.Interfaces
{
    public interface IZohoDeskService
    {
        /// <summary>
        /// Retrieves Zoho Desk tickets for a specific client from the past 30 days.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>
        /// A <see cref="ZohoTicketResult"/> object containing ticket details,
        /// a summary grouped by status, and the total count.
        /// </returns>
        Task<ZohoTicketResult> GetTicketsAsync(string clientId);
    }
}
