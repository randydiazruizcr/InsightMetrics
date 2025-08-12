using InsightMetrics.API.Models.Compliance;
using InsightMetrics.API.Repositories.Interfaces;
using InsightMetrics.API.Services.Interfaces;

namespace InsightMetrics.API.Services.Implementations
{
    /// <summary>
    /// Service implementation for retrieving compliance-related data.
    /// </summary>
    public class ComplianceService(IComplianceRepository ComplianceRepository) : IComplianceService
    {
        private readonly IComplianceRepository _ComplianceRepository = ComplianceRepository;

        /// <summary>
        /// Retrieves the compliance score for a specific client.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a 
        /// <see cref="ComplianceScoreResponse"/> with the client's compliance score.
        /// </returns>
        public async Task<ComplianceScoreResponse> GetComplianceScoreAsync(string clientId)
        {
            return await _ComplianceRepository.GetComplianceScoreAsync(clientId);
        }
    }
}
