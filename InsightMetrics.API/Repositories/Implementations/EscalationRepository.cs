using ForsyteIT.CosmosAPI.CRUDS.Guardian;
using ForsyteIT.CosmosAPI.Models.CollectionTypes;
using ForsyteIT.CosmosAPI.Models.Guardian;
using ForsyteIT.CosmosAPI.Models.Guardian.SecondaryData.Zoho;
using ForsyteIT.Guardian.Logic.Handlers;
using ForsyteIT.Guardian.Models;
using InsightMetrics.API.Models.Escalation;
using InsightMetrics.API.Repositories.Interfaces;
using System.Text;

namespace InsightMetrics.API.Repositories.Implementations
{
    /// <summary>
    /// Repository implementation for retrieving and analyzing escalation ticket data from Zoho.
    /// </summary>
    public class EscalationRepository : IEscalationRepository
    {
        private static readonly string[] stringArray = ["system", "api", "email", "webform"];

        /// <summary>
        /// Retrieves escalation ticket details for a specified client, including escalation summary,
        /// status breakdown, and timing information (business vs off hours).
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>
        /// An <see cref="EscalationResponse"/> object containing escalation tickets,
        /// status breakdowns, and timing metrics.
        /// </returns>
        public async Task<EscalationResponse> GetEscalationDetailsAsync(string clientId)
        {
            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("    c.id,");
            sb.AppendLine("    c.companyId,");
            sb.AppendLine("    c.subject,");
            sb.AppendLine("    c.status,");
            sb.AppendLine("    c.statusType,");
            sb.AppendLine("    c.priority,");
            sb.AppendLine("    null AS product,");
            sb.AppendLine("    c.source.type,");           
            sb.AppendLine("    c.closedTime AS resolvedTime,");
            sb.AppendLine("    c.createdTime,");
            sb.AppendLine("    c.lastUpdate");
            sb.AppendLine("FROM c");
            sb.AppendLine("WHERE");
            sb.AppendLine($"    c.collectionType = '{CollectionTypeGuardian.ZohoTicket}'");
            sb.AppendLine($"    AND c.companyId = '{clientId}'");
            sb.AppendLine($"    AND c.createdTime > '{DateTime.Now.AddDays(-30).ToString(GuardianGlobals.FormatDate)}'");
            sb.AppendLine("     AND c.category = 'Escalation'");
            sb.AppendLine("ORDER BY c.createdTime DESC");

            CrudSecondaryData<ZohoTicket> CrudGuardianRaws = new();
            CrudGuardianRaws.SetContainerName($"{CollectionTypeGuardian.ZohoTicket}");
            List<ZohoTicket> Tickets = await CrudGuardianRaws.Get(sb.ToString());
            Tickets = [.. Tickets.OrderByDescending(q => q.CreatedTime)];

            var Escalations = Tickets
                .Select(ticket =>
                {
                    var automatedSources = stringArray;
                    return new Escalation
                    {
                        Id = ticket.Id,
                        EscalationName = ticket.Subject,
                        Severity = string.IsNullOrWhiteSpace(ticket.Priority) ? "None" : ticket.Priority,
                        Status = ticket.StatusType,
                        Method = automatedSources.Contains(ticket.Source.Type?.ToLower()) ? "Automated" : "Manual",
                        FalsePositive = ticket.Status?.ToLower().Contains("false positive", StringComparison.CurrentCultureIgnoreCase) == true,
                        Product = null,
                        CreatedTime = ticket.CreatedTime,
                        UpdatedTime = ticket.LastUpdate,
                        ResolvedTime = ticket.ClosedTime
                    };
                })
                .OrderByDescending(e => e.CreatedTime)
                .ToList();

            int Total = Escalations.Count;

            var BreakDown = Escalations
                .GroupBy(e => e.Status)
                .Select(g => new EscalationBreakDown
                {
                    Status = g.Key,
                    Count = g.Count(),
                })
                .ToList();

            int BusinessHours = 0;
            int OffHours = 0;

            SCRoot SCRoot = await HandleScRoots.GetScRoot(clientId);

            DateTime defaultStart = DateTime.Today.AddHours(8);
            DateTime defaultEnd = DateTime.Today.AddHours(17);
            TimeZoneInfo timeZone = TimeZoneInfo.Utc;

            if (SCRoot.BusinessTime is not null && SCRoot.BusinessTime.TimeZone is not null)
            {
                timeZone = TimeZoneInfo.FindSystemTimeZoneById(SCRoot.BusinessTime.TimeZone);
                defaultStart = SCRoot.BusinessTime.StartTime;
                defaultEnd = SCRoot.BusinessTime.EndTime;
            }

            TimeSpan startTimeOfDay = defaultStart.TimeOfDay;
            TimeSpan endTimeOfDay = defaultEnd.TimeOfDay;

            foreach (Escalation escalation in Escalations)
            {
                DateTime ticketLocalTime = TimeZoneInfo.ConvertTimeFromUtc(escalation.CreatedTime, timeZone);
                TimeSpan alertTimeOfDay = ticketLocalTime.TimeOfDay;

                if (alertTimeOfDay < startTimeOfDay || alertTimeOfDay > endTimeOfDay)
                {
                    OffHours++;
                }
                else
                {
                    BusinessHours++;
                }
            }

            return new EscalationResponse
            {
                Escalated = new EscalatedSummary
                {
                    Total = Total,
                },
                BreakDown = BreakDown,
                Escalations = Escalations,
                Timing = new EscalatedTimming()
                {
                    HandledSOC = Total,
                    BusinessHours = BusinessHours,
                    OffHours = OffHours
                }
            };
        }
    }
}
