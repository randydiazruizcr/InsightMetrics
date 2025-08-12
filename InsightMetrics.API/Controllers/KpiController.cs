using ForsyteIT.Guardian.Models.DashBoardInformation;
using InsightMetrics.API.Models.KpiMetric;
using InsightMetrics.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace InsightMetrics.API.Controllers
{
    /// <summary>
    /// Provides KPI-related metrics for clients.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class KpiController(IKpiService kpiService) : ControllerBase
    {
        private readonly IKpiService _kpiService = kpiService;

        /// <summary>
        /// Retrieves KPI metrics for a given client including MTTD, MTTR, SLA compliance, and 30-day averages.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>Key performance indicators for the specified client.</returns>
        [HttpGet("metrics")]
        [SwaggerOperation(
            Summary = "Get KPI metrics by client ID",
            Description = "Fetches key performance indicators (MTTD, MTTR, SLA compliance, 30-day trends) for the specified client.",
            OperationId = "GetKpiMetrics",
            Tags = new[] { "KPI" }
        )]
        [ProducesResponseType(typeof(KpiMetricsResponse), (int)HttpStatusCode.OK)] // Replace 'object' with actual DTO
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetKpiMetrics([FromQuery] string clientId)
        {
            var result = await _kpiService.GetKpiMetricsAsync(clientId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
