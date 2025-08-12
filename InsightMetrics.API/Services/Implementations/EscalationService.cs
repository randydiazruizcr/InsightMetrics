using InsightMetrics.API.Models.Escalation;
using InsightMetrics.API.Repositories.Interfaces;
using InsightMetrics.API.Services.Interfaces;

namespace InsightMetrics.API.Services.Implementations
{
    /// <summary>
    /// Service implementation for escalation-related operations.
    /// </summary>
    public class EscalationService(IEscalationRepository escalationRepository) : IEscalationService
    {
        private readonly IEscalationRepository _escalationRepository = escalationRepository;

        /// <summary>
        /// Retrieves escalation ticket details for a specified client, including escalation summary,
        /// status breakdown, and timing information (business vs off hours).
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>
        /// An <see cref="EscalationResponse"/> object containing escalation tickets,
        /// status breakdowns, and timing metrics.
        /// </returns>
        public async Task<EscalationResponse> GetEscalationDetailsAsync(string clientId)
        {
            return await _escalationRepository.GetEscalationDetailsAsync(clientId);
        }
    }
}
