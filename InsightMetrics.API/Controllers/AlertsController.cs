using InsightMetrics.API.Models.Alert;
using InsightMetrics.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace InsightMetrics.API.Controllers
{
    /// <summary>
    /// Controller for managing alert-related endpoints.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AlertsController(IAlertsService alertsService) : ControllerBase
    {
        private readonly IAlertsService _alertsService = alertsService;

        /// <summary>
        /// Retrieves detailed alert data for a specified client.
        /// </summary>
        /// <param name="clientId">The ID of the client to retrieve alert details for.</param>
        /// <returns>A list of alert detail records.</returns>
        [HttpGet("details")]
        [SwaggerOperation(
            Summary = "Get alert details by client ID",
            Description = "Retrieves a detailed list of alerts for the specified client.",
            OperationId = "GetAlertDetails",
            Tags = new[] { "Alerts" }
        )]
        [ProducesResponseType(typeof(AlertResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAlertDetailsAsync([FromQuery] string clientId)
        {
            var result = await _alertsService.GetAlertDetailsAsync(clientId);
            return Ok(result);
        }

        /// <summary>
        /// Gets a summary of tuning-related alerts for a specific client.
        /// </summary>
        /// <param name="clientId">The identifier of the client.</param>
        /// <returns>A summary object containing tuning information.</returns>
        [HttpGet("summary")]
        [SwaggerOperation(
            Summary = "Get tuning summary by client ID",
            Description = "Retrieves a summary of metric tuning alerts for the specified client.",
            OperationId = "GetTuningSummary",
            Tags = new[] { "Alerts" }
        )]
        [ProducesResponseType(typeof(AlertSummaryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetSummaryAsync([FromQuery] string clientId)
        {
            var result = await _alertsService.GetSummaryAsync(clientId);
            return Ok(result);
        }
    }
}
