using InsightMetrics.API.Models.Device;
using InsightMetrics.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace InsightMetrics.API.Controllers
{
    /// <summary>
    /// Provides endpoints to retrieve device-related compliance data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController(IDeviceService devicesService) : ControllerBase
    {
        private readonly IDeviceService _devicesService = devicesService;

        /// <summary>
        /// Retrieves the list of non-compliant devices for a specific client.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>A list of non-compliant devices.</returns>
        [HttpGet("non-compliant")]
        [SwaggerOperation(
            Summary = "Get non-compliant devices by client ID",
            Description = "Returns a list of devices that do not meet compliance standards for the specified client.",
            OperationId = "GetNonCompliantDevices",
            Tags = new[] { "Devices" }
        )]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.OK)] // Replace with actual DTO type
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetNonCompliantDevicesAsync([FromQuery] DeviceRequest DeviceRequest)
        {
            var result = await _devicesService.GetNonCompliantDevicesAsync(DeviceRequest);
            return Ok(result);
        }
    }
}
