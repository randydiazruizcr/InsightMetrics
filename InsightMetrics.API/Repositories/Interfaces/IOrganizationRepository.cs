using InsightMetrics.API.Models.Organization;

namespace InsightMetrics.API.Repositories.Interfaces
{
    public interface IOrganizationRepository
    {
        /// <summary>
        /// Retrieves a list of organizations with display names and time zones.
        /// </summary>
        /// <returns>
        /// A list of <see cref="OrganizationResponse"/> representing organizations and their display information.
        /// </returns>
        Task<List<OrganizationResponse>> GetOrganizationsAsync();
    }
}
