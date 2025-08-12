
using InsightMetrics.API.Models.Account;

namespace InsightMetrics.API.Repositories.Interfaces
{
    public interface IUserActivityRepository
    {
        /// <summary>
        /// Retrieves the user activity summary for a specific client.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains an <see cref="AccountReportResponse"/> with user activity summary data.
        /// </returns>
        Task<AccountReportResponse> GetUserActivitySummaryAsync(string clientId);
    }
}
