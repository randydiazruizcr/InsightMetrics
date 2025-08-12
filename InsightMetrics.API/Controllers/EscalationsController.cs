using InsightMetrics.API.Models.Escalation;
using InsightMetrics.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace InsightMetrics.API.Controllers
{
    /// <summary>
    /// Provides escalation timing and breakdown data for clients.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EscalationsController(IEscalationService escalationsService) : ControllerBase
    {
        private readonly IEscalationService _escalationsService = escalationsService;

        [HttpGet("details")]
        [SwaggerOperation(
            Summary = "Get escalation details by client ID",
            Description = "Returns both escalation timing and breakdown information for the specified client.",
            OperationId = "GetEscalationDetailsAsync",
            Tags = new[] { "Escalations" }
        )]
        [ProducesResponseType(typeof(EscalationResponse), (int)HttpStatusCode.OK)] // Replace with actual DTO
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetEscalationDetailsAsync([FromQuery] string clientId)
        {
            var result = await _escalationsService.GetEscalationDetailsAsync(clientId);
            return Ok(result);
        }
    }
}
