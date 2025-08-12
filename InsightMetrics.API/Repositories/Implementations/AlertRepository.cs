using ForsyteIT.CosmosAPI.CRUDS.Guardian;
using ForsyteIT.CosmosAPI.Models.CollectionTypes;
using ForsyteIT.CosmosAPI.Repository.Containers;
using ForsyteIT.Guardian.Logic.Cruds.DashboardInformation;
using ForsyteIT.Guardian.Models;
using ForsyteIT.Guardian.Models.DashBoardInformation;
using ForsyteIT.Guardian.Models.Types.Enums;
using InsightMetrics.API.Models.Alert;
using InsightMetrics.API.Repositories.Interfaces;
using System.Text;

namespace InsightMetrics.API.Repositories.Implementations
{
    public class AlertRepository : IAlertRepository
    {
        /// <summary>
        /// Retrieves detailed alert information for a specific client.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>An <see cref="AlertResponse"/> containing detailed alert information.</returns>
        public async Task<AlertResponse> GetAlertDetailsAsync(string clientId)
        {
            var sb = new StringBuilder();

            sb.AppendLine("SELECT");
            sb.AppendLine("    c.AlertJson.id,");
            sb.AppendLine("    c.AlertJson.title,");
            sb.AppendLine("    c.AlertJson.category,");
            sb.AppendLine("    c.AlertJson.status,");
            sb.AppendLine("    c.AlertJson.severity,");
            sb.AppendLine("    c.AlertJson.productName,");
            sb.AppendLine("    c.AlertJson.createdDateTime,");
            sb.AppendLine("    c.AlertJson.lastUpdateDateTime");
            sb.AppendLine("FROM c");
            sb.AppendLine("WHERE");
            sb.AppendLine($"    c.collectionType = '{CollectionTypeGuardian.RawSecurity}'");
            sb.AppendLine($"    AND c.companyId = '{clientId}'");
            sb.AppendLine($"    AND c.AlertJson.createdDateTime > '{DateTime.Now.AddDays(-30).ToString(GuardianGlobals.FormatDate)}'");
            CrudGuardian<Alert> CrudGuardianRaws = new();
            CrudGuardianRaws.SetContainerName($"{G365Containers.RawSecurityV2}");
            List<Alert> Alert = await CrudGuardianRaws.Get(sb.ToString());
            Alert = [.. Alert.OrderByDescending(q => q.CreatedDateTime)];

            var TopCategories = Alert
              .Where(a => !string.IsNullOrEmpty(a.Category))
              .GroupBy(a => a.Category)
              .Select(g => new TopAlertCategory { Category = g.Key, Count = g.Count() })
              .OrderByDescending(g => g.Count)
              .Take(5)
              .ToList();

            var SeverityByDay = Alert
                 .Where(a => !string.IsNullOrEmpty(a.Severity))
                 .GroupBy(a => a.CreatedDateTime.Date)
                 .Select(g => new DailySeverityGroup
                 {
                     Date = g.Key,
                     Severities = [.. g
                         .GroupBy(a => a.Severity)
                         .Select(sg => new SeverityCount
                         {
                             Severity = sg.Key,
                             Count = sg.Count()
                         })
                         .OrderByDescending(s => s.Count)]
                 })
                 .OrderBy(g => g.Date)
                 .ToList();

            var Result = new AlertResponse()
            {
                Alerts = Alert,
                Total = Alert.Count,
                TopCategories = TopCategories,
                DailySeverityGroup = SeverityByDay
            };

            return Result;
        }

        /// <summary>
        /// Retrieves a summary of alerts for a specific client.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>An <see cref="AlertSummaryResponse"/> representing a summary of alerts.</returns>
        public async Task<AlertSummaryResponse> GetSummaryAsync(string clientId)
        {
            CrudCustomerDashBoardAlertTunning CrudCustomerDashBoardAlertTunning = new();
            List<CustomerDashBoardAlertTunning> CustomerDashBoardAlertTunnings = await CrudCustomerDashBoardAlertTunning.Get(q => q.CompanyId == clientId
                && q.CollectionType == InternalGuardianCollectionType.CustomerDashBoardAlertTunning);

            var Result = new AlertSummaryResponse
            {
                RawAlerts = CustomerDashBoardAlertTunnings.Sum(x => x.NumberAlerts),
                TunedOut = CustomerDashBoardAlertTunnings.Sum(x => x.NumberAlertsSuppression),
                Remaining = CustomerDashBoardAlertTunnings.Sum(x => x.RemainingSuppression),
                PostTuningAlerts = CustomerDashBoardAlertTunnings.Sum(x => x.AlertsResolved),
                HandledAutomatically = CustomerDashBoardAlertTunnings.Sum(x => x.AlertsAutoResolved),
                Escalated = CustomerDashBoardAlertTunnings.Sum(x => x.AlertsManuallyResolved)
            };

            return Result;
        }
    }
}
