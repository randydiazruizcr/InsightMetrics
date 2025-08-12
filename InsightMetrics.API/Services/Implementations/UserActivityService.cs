using InsightMetrics.API.Models.Account;
using InsightMetrics.API.Repositories.Interfaces;
using InsightMetrics.API.Services.Interfaces;

namespace InsightMetrics.API.Services.Implementations
{
    /// <summary>
    /// Provides services related to user activity summaries.
    /// </summary>
    public class UserActivityService(IUserActivityRepository userActivityRepository) : IUserActivityService
    {
        private readonly IUserActivityRepository _userActivityRepository = userActivityRepository;

        /// <summary>
        /// Retrieves the user activity summary for a specific client.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains an <see cref="AccountReportResponse"/> with user activity summary data.
        /// </returns>
        public async Task<AccountReportResponse> GetUserActivitySummaryAsync(string clientId)
        {
            return await _userActivityRepository.GetUserActivitySummaryAsync(clientId);
        }
    }
}
