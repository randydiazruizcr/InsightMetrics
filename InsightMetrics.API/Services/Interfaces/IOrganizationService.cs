
using InsightMetrics.API.Models.Organization;

namespace InsightMetrics.API.Services.Interfaces
{
    public interface IOrganizationService
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
