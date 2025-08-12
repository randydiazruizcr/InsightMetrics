using InsightMetrics.API.Models.Organization;
using InsightMetrics.API.Repositories.Interfaces;
using InsightMetrics.API.Services.Interfaces;

namespace InsightMetrics.API.Services.Implementations
{
    public class OrganizationService(IOrganizationRepository organizationRepository) : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository = organizationRepository ?? throw new ArgumentNullException(nameof(organizationRepository));

        /// <summary>
        /// Retrieves a list of organizations with display names and time zones.
        /// </summary>
        /// <returns>
        /// A list of <see cref="OrganizationResponse"/> representing organizations and their display information.
        /// </returns>
        public async Task<List<OrganizationResponse>> GetOrganizationsAsync()
        {
            List<OrganizationResponse> OrganizationResponse = await _organizationRepository.GetOrganizationsAsync();
            return OrganizationResponse;
        }
    }
}
