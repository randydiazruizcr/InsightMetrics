
using InsightMetrics.API.Models.Device;

namespace InsightMetrics.API.Repositories.Interfaces
{
    public interface IDeviceRepository
    {
        /// <summary>
        /// Retrieves a list of non-compliant devices for a specific client.
        /// </summary>
        /// <param name="DeviceRequest">The unique identifier of the client.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a collection
        /// of non-compliant devices as an <see cref="object"/> (consider specifying a more precise type).
        /// </returns>
        Task<DevicesResponse> GetNonCompliantDevicesAsync(DeviceRequest DeviceRequest);
    }
}
