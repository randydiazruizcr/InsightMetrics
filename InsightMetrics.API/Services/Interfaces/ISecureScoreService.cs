using ForsyteIT.CosmosAPI.Models.Guardian;
using InsightMetrics.API.Models.Metric;

namespace InsightMetrics.API.Services.Interfaces
{
    public interface ISecureScoreService
    {
        Task<SecureScoreResponse> GetLastSecureScoreAsync(string clientId);
    }
}
