using InsightMetrics.API.Models.Compliance;
using InsightMetrics.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace InsightMetrics.API.Controllers
{
    /// <summary>
    /// Provides compliance-related metrics and reports for clients.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ComplianceController(IComplianceService complianceService) : ControllerBase
    {
        private readonly IComplianceService _complianceService = complianceService;

        /// <summary>
        /// Retrieves the compliance score for a given client.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>A JSON object representing the compliance score.</returns>
        [HttpGet("score")]
        [SwaggerOperation(
            Summary = "Get compliance score by client ID",
            Description = "Returns the compliance score of the specified client based on internal metrics.",
            OperationId = "GetComplianceScore",
            Tags = new[] { "Compliance" }
        )]
        [ProducesResponseType(typeof(ComplianceScoreResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetComplianceScoreAsync([FromQuery] string clientId)
        {
            var result = await _complianceService.GetComplianceScoreAsync(clientId);
            return Ok(result);
        }
    }
}
