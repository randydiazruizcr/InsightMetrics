using ForsyteIT.CosmosAPI.Models.Guardian;
using InsightMetrics.API.Models.Metric;

namespace InsightMetrics.API.Repositories.Interfaces
{
    public interface ISecureScoreRepository
    {
        Task<SecureScoreResponse> GetLastSecureScoreAsync(string clientId);
    }
}
