using ForsyteIT.Guardian.Models.DashBoardInformation;
using InsightMetrics.API.Models.KpiMetric;
using InsightMetrics.API.Repositories.Interfaces;
using InsightMetrics.API.Services.Interfaces;

namespace InsightMetrics.API.Services.Implementations
{
    public class KpiService(IKpiRepository kpiRepository) : IKpiService
    {
        private readonly IKpiRepository _kpiRepository = kpiRepository;

        /// <summary>
        /// Retrieves customer KPI metrics from the dashboard collection.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a 
        /// <see cref="CustomerDashboardMetrics"/> object with the client's KPI metrics.
        /// If no record is found, an empty <see cref="CustomerDashboardMetrics"/> is returned.
        /// </returns>
        public async Task<KpiMetricsResponse> GetKpiMetricsAsync(string clientId)
        {
            CustomerDashboardMetrics metric = await _kpiRepository.GetKpiMetricsAsync(clientId);

            var dto = new KpiMetricsResponse()
            {
                Mttd = metric.MTTD,
                Mttr = metric.MTTR,
                SlaViolationTimeMttd = metric.SlaViolationTimeMttd,
                SlaViolationTimeMttr = metric.SlaViolationTimeMttr
            };

            return dto;
        }
    }
}
