using InsightMetrics.API.Models.Compliance;

namespace InsightMetrics.API.Services.Interfaces
{
    public interface IComplianceService
    {
        /// <summary>
        /// Retrieves the compliance score for a specific client.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a 
        /// <see cref="ComplianceScoreResponse"/> with the client's compliance score.
        /// </returns>
        Task<ComplianceScoreResponse> GetComplianceScoreAsync(string clientId);
    }
}
