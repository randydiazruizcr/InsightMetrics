using InsightMetrics.API.Models.Device;
using InsightMetrics.API.Repositories.Interfaces;
using InsightMetrics.API.Services.Interfaces;

namespace InsightMetrics.API.Services.Implementations
{
    /// <summary>
    /// Service implementation for device-related operations.
    /// </summary>
    public class DeviceService(IDeviceRepository DeviceRepository) : IDeviceService
    {
        private readonly IDeviceRepository _DeviceRepository = DeviceRepository;

        /// <summary>
        /// Retrieves a list of non-compliant devices for a specific client.
        /// </summary>
        /// <param name="DeviceRequest">The unique identifier of the client.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a collection
        /// of non-compliant devices as an <see cref="object"/> (consider specifying a more precise type).
        /// </returns>
        public async Task<DevicesResponse> GetNonCompliantDevicesAsync(DeviceRequest DeviceRequest)
        {
            return await _DeviceRepository.GetNonCompliantDevicesAsync(DeviceRequest);
        }
    }
}
