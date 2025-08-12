using ForsyteIT.Guardian.Logic.Cruds.DashboardInformation;
using ForsyteIT.Guardian.Models.DashBoardInformation;
using ForsyteIT.Guardian.Models.Types.Enums;
using InsightMetrics.API.Repositories.Interfaces;

namespace InsightMetrics.API.Repositories.Implementations
{
    /// <summary>
    /// Repository implementation for retrieving KPI metrics data.
    /// </summary>
    public class KpiRepository : IKpiRepository
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
        public async Task<CustomerDashboardMetrics> GetKpiMetricsAsync(string clientId)
        {
            CrudCustomerDashboardMetrics CrudCustomerDashboardMetrics = new();
            List<CustomerDashboardMetrics> CustomerDashboardMetrics = await CrudCustomerDashboardMetrics.Get(q => 
                q.CollectionType == InternalGuardianCollectionType.CustomerDashboardMetrics 
                && q.CompanyId == clientId);
            return CustomerDashboardMetrics.FirstOrDefault() ?? new CustomerDashboardMetrics();
        }
    }
}
