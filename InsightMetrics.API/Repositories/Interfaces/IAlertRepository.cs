using InsightMetrics.API.Models.Alert;

namespace InsightMetrics.API.Repositories.Interfaces
{
    public interface IAlertRepository
    {
        /// <summary>
        /// Retrieves detailed alert information for a specific client.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>An <see cref="AlertResponse"/> containing detailed alert information.</returns>
        Task<AlertResponse> GetAlertDetailsAsync(string clientId);

        /// <summary>
        /// Retrieves a summary of alerts for a specific client.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>An <see cref="AlertSummaryResponse"/> representing a summary of alerts.</returns>
        Task<AlertSummaryResponse> GetSummaryAsync(string clientId);
    }
}
