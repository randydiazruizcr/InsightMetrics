using InsightMetrics.API.Models.Zoho;
using InsightMetrics.API.Repositories.Interfaces;
using InsightMetrics.API.Services.Interfaces;

namespace InsightMetrics.API.Services.Implementations
{
    public class ZohoDeskService(IZohoDeskRepository zohoDeskRepository) : IZohoDeskService
    {
        private readonly IZohoDeskRepository _zohoDeskRepository = zohoDeskRepository;

        /// <summary>
        /// Retrieves Zoho Desk tickets for a specific client from the past 30 days.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>
        /// A <see cref="ZohoTicketResult"/> object containing ticket details,
        /// a summary grouped by status, and the total count.
        /// </returns>
        public async Task<ZohoTicketResult> GetTicketsAsync(string clientId)
        {
            return await _zohoDeskRepository.GetTicketsAsync(clientId);
        }
    }
}
