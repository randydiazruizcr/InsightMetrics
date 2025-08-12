using ForsyteIT.CosmosAPI.CRUDS.Guardian;
using ForsyteIT.CosmosAPI.Models.CollectionTypes;
using ForsyteIT.CosmosAPI.Models.Guardian;
using InsightMetrics.API.Models.Compliance;
using InsightMetrics.API.Repositories.Interfaces;
using InsightMetrics.API.Utils;

namespace InsightMetrics.API.Repositories.Implementations
{
    public class ComplianceRepository : IComplianceRepository
    {
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
            CrudDeploymentTracking CrudDeploymentTracking = new();
            List<DeploymentTracking> Tasks = await CrudDeploymentTracking.Get(q => q.CollectionType == CollectionTypeGuardian.DeploymentTracking && q.CompanyId == clientId);
            var Total = Tasks.Count;
            var TaskDetails = Tasks.Select(t => new TaskDetail
            {
                Id = t.Id,
                Name = t.Item,
                Workload = WorkloadHelper.GetWorkloadDescription(t.Workload),
                Status = t.Status,
                OnboardingRequirement = t.OnboardingRequirement,
                Notes = t.Notes,
                CreatedTime = t.Date,
                UpdatedTime = t.LastUpdate
            }).ToList();

            var GroupedByStatus = Tasks
                .Where(d => !string.IsNullOrEmpty(d.Status))
                .GroupBy(d => d.Status)
                .Select(g => new StatusCount
                {
                    Status = g.Key,
                    Count = g.Count()
                })
                .ToList();

            var Result = new ComplianceScoreResponse()
            {
                GroupedByStatus = GroupedByStatus,
                Tasks = TaskDetails,
                Total = Total
            };

            return Result;
        }
    }
}
