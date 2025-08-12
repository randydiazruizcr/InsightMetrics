using ForsyteIT.CosmosAPI.CRUDS.Guardian;
using ForsyteIT.CosmosAPI.Models.CollectionTypes;
using ForsyteIT.CosmosAPI.Models.Guardian.SecondaryData.Zoho;
using ForsyteIT.Guardian.Models;
using InsightMetrics.API.Models.Zoho;
using InsightMetrics.API.Repositories.Interfaces;
using System.Text;

namespace InsightMetrics.API.Repositories.Implementations
{
    /// <summary>
    /// Repository implementation for retrieving Zoho Desk ticket data.
    /// </summary>
    public class ZohoDeskRepository : IZohoDeskRepository
    {
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
            var sb = new StringBuilder();

            sb.AppendLine("SELECT");
            sb.AppendLine("    c.id,");
            sb.AppendLine("    c.companyId,");
            sb.AppendLine("    c.subject,");
            sb.AppendLine("    c.statusType as status,");
            sb.AppendLine("    c.priority,");
            sb.AppendLine("    c.createdTime,");
            sb.AppendLine("    c.lastUpdate");
            sb.AppendLine("FROM c");
            sb.AppendLine("WHERE");
            sb.AppendLine($"    c.collectionType = '{CollectionTypeGuardian.ZohoTicket}'");
            sb.AppendLine($"    AND c.companyId = '{clientId}'");
            sb.AppendLine($"    AND c.createdTime > '{DateTime.Now.AddDays(-30).ToString(GuardianGlobals.FormatDate)}'");

            CrudSecondaryData<ZohoTicket> CrudGuardianRaws = new();
            CrudGuardianRaws.SetContainerName($"{CollectionTypeGuardian.ZohoTicket}");
            List<ZohoTicket> Tickets = await CrudGuardianRaws.Get(sb.ToString());
            Tickets = [.. Tickets.OrderByDescending(q => q.CreatedTime)];

            var tickets = Tickets.Select(t => new ZohoTicketItem
            {
                Id = t.Id,
                Subject = t.Subject,
                Status = t.Status,
                Priority = t.Priority,
                Timestamp = t.CreatedTime,
                CreatedTime = t.CreatedTime,
                UpdatedTime = t.LastUpdate
            }).ToList();

            var total = tickets.Count;

            var summary = Tickets
                .Where(a => !string.IsNullOrWhiteSpace(a.Status))
                .GroupBy(a => a.Status)
                .Select(g => new ZohoTicketSummary
                {
                    Status = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(g => g.Count)
                .ToList();

            ZohoTicketResult ZohoTicketResult = new()
            {
                Summary = summary,
                Tickets = tickets,
                Total = total
            };

            return ZohoTicketResult;
        }
    }
}
