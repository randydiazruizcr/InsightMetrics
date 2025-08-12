using InsightMetrics.API.Models.Escalation;

namespace InsightMetrics.API.Services.Interfaces
{
    public interface IEscalationService
    {
        /// <summary>
        /// Retrieves escalation ticket details for a specified client, including escalation summary,
        /// status breakdown, and timing information (business vs off hours).
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>
        /// An <see cref="EscalationResponse"/> object containing escalation tickets,
        /// status breakdowns, and timing metrics.
        /// </returns>
        Task<EscalationResponse> GetEscalationDetailsAsync(string clientId);
    }
}
