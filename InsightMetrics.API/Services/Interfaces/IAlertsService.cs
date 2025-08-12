using InsightMetrics.API.Models.Alert;

namespace InsightMetrics.API.Services.Interfaces
{
    /// <summary>
    /// Defines methods for retrieving alert-related data, including details and summary metrics.
    /// </summary>
    public interface IAlertsService
    {
        /// <summary>
        /// Retrieves detailed alert information for a specified client.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains an <see cref="AlertResponse"/> object with alert details for the client.
        /// </returns>
        Task<AlertResponse> GetAlertDetailsAsync(string clientId);

        /// <summary>
        /// Retrieves a summary of alerts for a specified client.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains an <see cref="AlertSummaryResponse"/> object with summarized alert information.
        /// </returns>
        Task<AlertSummaryResponse> GetSummaryAsync(string clientId);   
    }
}
