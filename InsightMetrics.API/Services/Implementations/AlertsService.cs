using InsightMetrics.API.Models.Alert;
using InsightMetrics.API.Repositories.Interfaces;
using InsightMetrics.API.Services.Interfaces;

namespace InsightMetrics.API.Services.Implementations
{
    /// <summary>
    /// Service implementation for handling alert-related operations.
    /// </summary>
    public class AlertsService(IAlertRepository alertRepository) : IAlertsService
    {
        /// <summary>
        /// Repository interface for accessing alert data.
        /// </summary>
        private readonly IAlertRepository _alertRepository = alertRepository;

        /// <summary>
        /// Retrieves detailed alert information for a specific client.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>An <see cref="AlertResponse"/> containing detailed alert information.</returns>
        public async Task<AlertResponse> GetAlertDetailsAsync(string clientId)
        {
            return await _alertRepository.GetAlertDetailsAsync(clientId);
        }

        /// <summary>
        /// Retrieves a summary of alerts for a specific client.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>An <see cref="AlertSummaryResponse"/> representing a summary of alerts.</returns>
        public async Task<AlertSummaryResponse> GetSummaryAsync(string clientId)
        {
            return await _alertRepository.GetSummaryAsync(clientId);
        }
    }
}
