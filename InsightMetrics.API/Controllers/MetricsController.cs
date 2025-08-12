using ForsyteIT.CosmosAPI.Models.Guardian;
using InsightMetrics.API.Models.Metric;
using InsightMetrics.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace InsightMetrics.API.Controllers
{
    /// <summary>
    /// Provides Secure Score metrics for clients.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MetricsController(ISecureScoreService secureScoreService) : ControllerBase
    {
        private readonly ISecureScoreService _secureScoreService = secureScoreService ?? throw new ArgumentNullException(nameof(secureScoreService));

        /// <summary>
        /// Retrieves the latest Secure Score for the specified client.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>The latest Secure Score record for the client.</returns>
        [HttpGet("latest")]
        [SwaggerOperation(
            Summary = "Get latest Secure Score by client ID",
            Description = "Returns the most recent Secure Score entry for a given client ID.",
            OperationId = "GetLastSecureScore",
            Tags = new[] { "SecureScore" }
        )]
        [ProducesResponseType(typeof(SecureScoreResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetLastSecureScore([FromQuery] string clientId)
        {
            try
            {
                var result = await _secureScoreService.GetLastSecureScoreAsync(clientId);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception Exception)
            {
                return BadRequest(Exception.Message);
            }
            
        }
    }
}
