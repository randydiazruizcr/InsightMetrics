using ForsyteIT.CosmosAPI.CRUDS.CMI;
using ForsyteIT.CosmosAPI.Models.CMI;
using ForsyteIT.CosmosAPI.Models.Guardian;
using ForsyteIT.CosmosAPI.Repository.Containers;
using ForsyteIT.Guardian.Logic.Handlers;
using InsightMetrics.API.Models.Organization;
using InsightMetrics.API.Repositories.Interfaces;
using InsightMetrics.API.Utils;

namespace InsightMetrics.API.Repositories.Implementations
{
    /// <summary>
    /// Repository responsible for fetching and formatting organization-related data.
    /// </summary>
    public class OrganizationRepository : IOrganizationRepository
    {
        /// <summary>
        /// Retrieves a list of organizations with display names and time zones.
        /// </summary>
        /// <returns>
        /// A list of <see cref="OrganizationResponse"/> representing organizations and their display information.
        /// </returns>
        public async Task<List<OrganizationResponse>> GetOrganizationsAsync()
        {

            List<SCRoot> ScRoots = await HandleScRoots.GetScRoots();

            CrudCmi<Company> CrudCmi = new();
            CrudCmi.SetContainerName($"{LapiContainers.Companies}");
            List<OrganizationResponse> OrganizationResponses = [];
            foreach (SCRoot company in ScRoots)
            {
                OrganizationResponses.Add(new OrganizationResponse()
                {
                    Id = company.CompanyId,
                    DisplayName = company.DisplayName,
                    TimeZone = TimezoneHelper.TimeZoneBaseOnOs((company.BusinessTime ?? new()).TimeZone),
                });
            }
            return OrganizationResponses;
        }
    }
}
