using ForsyteIT.CosmosAPI.Models.Guardian;
using InsightMetrics.API.Models.Metric;
using InsightMetrics.API.Repositories.Interfaces;
using InsightMetrics.API.Services.Interfaces;

namespace InsightMetrics.API.Services.Implementations
{
    public class SecureScoreService(ISecureScoreRepository secureScoreRepository) : ISecureScoreService
    {
        private readonly ISecureScoreRepository _secureScoreService = secureScoreRepository ?? throw new ArgumentNullException(nameof(secureScoreRepository));
        
        public async Task<SecureScoreResponse> GetLastSecureScoreAsync(string clientId)
        {
            return await _secureScoreService.GetLastSecureScoreAsync(clientId);
        }
    }
}
