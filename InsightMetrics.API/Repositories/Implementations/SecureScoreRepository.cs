using ForsyteIT.CosmosAPI.CRUDS.Guardian;
using ForsyteIT.CosmosAPI.Models.CollectionTypes;
using ForsyteIT.CosmosAPI.Models.Guardian;
using ForsyteIT.CosmosAPI.Repository.Containers;
using InsightMetrics.API.Models.Metric;
using InsightMetrics.API.Repositories.Interfaces;
using System.Text;

namespace InsightMetrics.API.Repositories.Implementations
{
    public class SecureScoreRepository : ISecureScoreRepository
    {
        public async Task<SecureScoreResponse> GetLastSecureScoreAsync(string clientId)
        {
            var queryBuilder = new StringBuilder();

            queryBuilder.AppendLine("SELECT TOP 1 *");
            queryBuilder.AppendLine("FROM c");
            queryBuilder.AppendLine($"WHERE c.companyId = '{clientId}'");
            queryBuilder.AppendLine($"AND c.collectionType = '{CollectionTypeGuardian.SecureScore}'");
            queryBuilder.AppendLine("ORDER BY c.date DESC");

            CrudGuardian<SecureScore> CrudGuardianRaws = new();
            CrudGuardianRaws.SetContainerName($"{G365Containers.SecureScore}");
            List<SecureScore> SecureScores = await CrudGuardianRaws.Get(queryBuilder.ToString());

            var secureScore = SecureScores?.FirstOrDefault();
            if (secureScore == null || secureScore.GraphSecureScore == null)
            {
                return new SecureScoreResponse(); 
            }

            double currentScore = secureScore.GraphSecureScore.Value<double?>("currentScore") ?? 0;
            double maxScore = secureScore.GraphSecureScore.Value<double?>("maxScore") ?? 0;
            DateTime createdDateTime = secureScore.GraphSecureScore.Value<DateTime?>("createdDateTime") ?? DateTime.MinValue;

            return new SecureScoreResponse
            {
                Id = secureScore.Id,
                CurrentScore = currentScore,
                MaxScore = maxScore,
                CreatedDateTime = createdDateTime
            };
        }
    }
}
