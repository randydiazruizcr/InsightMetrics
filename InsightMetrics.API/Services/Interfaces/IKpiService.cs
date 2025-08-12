using ForsyteIT.Guardian.Models.DashBoardInformation;
using InsightMetrics.API.Models.KpiMetric;

namespace InsightMetrics.API.Services.Interfaces
{
    public interface IKpiService
    {
        /// <summary>
        /// Retrieves customer KPI metrics from the dashboard collection.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a 
        /// <see cref="CustomerDashboardMetrics"/> object with the client's KPI metrics.
        /// If no record is found, an empty <see cref="CustomerDashboardMetrics"/> is returned.
        /// </returns>
        Task<KpiMetricsResponse> GetKpiMetricsAsync(string clientId);
    }
}
