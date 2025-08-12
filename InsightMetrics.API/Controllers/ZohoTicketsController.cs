using InsightMetrics.API.Models.Zoho;
using InsightMetrics.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace InsightMetrics.API.Controllers
{
    /// <summary>
    /// Controller to manage Zoho Desk tickets for clients.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ZohoTicketsController(IZohoDeskService zohoDeskService) : ControllerBase
    {
        private readonly IZohoDeskService _zohoDeskService = zohoDeskService;

        /// <summary>
        /// Retrieves tickets from Zoho Desk for a specified client.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>A list of tickets associated with the client.</returns>
        [HttpGet("tickets")]
        [SwaggerOperation(
            Summary = "Get Zoho Desk tickets by client ID",
            Description = "Fetches a list of support tickets from Zoho Desk for the specified client.",
            OperationId = "GetZohoTickets",
            Tags = new[] { "ZohoTickets" }
        )]
        [ProducesResponseType(typeof(ZohoTicketResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetTicketsAsync([FromQuery] string clientId)
        {
            var result = await _zohoDeskService.GetTicketsAsync(clientId);
            return Ok(result);
        }
    }
}
