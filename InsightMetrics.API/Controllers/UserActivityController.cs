using InsightMetrics.API.Models.Account;
using InsightMetrics.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace InsightMetrics.API.Controllers
{
    /// <summary>
    /// Provides endpoints to retrieve user activity summaries for a client.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserActivityController(IUserActivityService userActivityService) : ControllerBase
    {
        private readonly IUserActivityService _userActivityService = userActivityService;

        /// <summary>
        /// Retrieves a summary of user activity for a specific client.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>A summary of user activity metrics.</returns>
        [HttpGet("summary")]
        [SwaggerOperation(
            Summary = "Get user activity summary by client ID",
            Description = "Returns a summary of user activity metrics (e.g., logins, feature usage) for the specified client.",
            OperationId = "GetUserActivitySummary",
            Tags = new[] { "UserActivity" }
        )]
        [ProducesResponseType(typeof(AccountReportResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetUserActivitySummaryAsync([FromQuery] string clientId)
        {
            var result = await _userActivityService.GetUserActivitySummaryAsync(clientId);
            return Ok(result);
        }
    }
}
