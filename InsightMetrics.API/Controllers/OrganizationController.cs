using InsightMetrics.API.Models.Organization;
using InsightMetrics.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace InsightMetrics.API.Controllers
{
    /// <summary>
    /// Handles organization-related operations such as retrieving organization data and identifiers.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController(IOrganizationService organizationService) : ControllerBase
    {
        private readonly IOrganizationService _organizationService = organizationService;

        /// <summary>
        /// Retrieves all organization IDs (with optional filters).
        /// </summary>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all organization IDs",
            Description = "Returns a list of all organization IDs, with optional filters for updatedSince and includeDeleted.",
            OperationId = "GetOrganizationIds",
            Tags = new[] { "Organization" }
        )]
        [ProducesResponseType(typeof(List<OrganizationResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetOrganizationsAsync()
        {
            var result = await _organizationService.GetOrganizationsAsync();
            return Ok(result);
        }
    }
}
