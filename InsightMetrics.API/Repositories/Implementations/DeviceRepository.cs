using ForsyteIT.CosmosAPI.Classes;
using ForsyteIT.CosmosAPI.Utils;
using ForsyteIT.Guardian.Logic.Cruds;
using ForsyteIT.Guardian.Models.Report;
using ForsyteIT.Guardian.Models.Types.Enums;
using InsightMetrics.API.Models.Device;
using InsightMetrics.API.Repositories.Interfaces;
using System.Text;

namespace InsightMetrics.API.Repositories.Implementations
{
    public class DeviceRepository : IDeviceRepository
    {
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
            DevicesResponse DevicesResponse = new();
            CrudDeviceReport CrudDeviceReport = new();
            CrudClientDevice CrudClientDevice = new();
            List<DeviceReport> DeviceReports = await CrudDeviceReport.Get($"SELECT TOP 1 * FROM c WHERE c.companyId = '{DeviceRequest.ClientId}' AND c.collectionType = '{InternalGuardianCollectionType.DeviceReport}' ORDER BY c.date DESC");
            if (DeviceReports.Count > 0)
            {
                DeviceReport DeviceReport = DeviceReports[0];
                DevicesResponse.DeviceReport = new()
                {
                    ClientName = DeviceReport.ClientName,
                    CreatedDateTime = DeviceReport.Date,
                    LastUpdateDateTime = DeviceReport.LastUpdate,
                    NoSupportedDevices = DeviceReport.NoSupportedDevices,
                    SupportedDevices = DeviceReport.SupportedDevices
                };
                string QueryDevices = GetQueryDevices(DeviceRequest);
                if (!string.IsNullOrEmpty(DeviceRequest.ContinuationToken))
                {
                    DeviceRequest.ContinuationToken = Validations.DecodeBase64(DeviceRequest.ContinuationToken);
                }
                GetItemsResponse<ClientDevice> ClientDevices = await CrudClientDevice.GetByQuery(QueryDevices, DeviceRequest.ContinuationToken, 10000);
                for (int i = 0; i < ClientDevices.Objects.Count; i++)
                {
                    DevicesResponse.Devices.Add(new ClientDeviceResponse
                    {
                        Id = ClientDevices.Objects[i].Id,
                        AadDeviceId = ClientDevices.Objects[i].AadDeviceId,
                        DefenderDeviceId = ClientDevices.Objects[i].DefenderDeviceId,
                        GraphDeviceId = ClientDevices.Objects[i].GraphDeviceId,
                        DeviceName = !string.IsNullOrEmpty(ClientDevices.Objects[i].DefenderDeviceName) ? ClientDevices.Objects[i].DefenderDeviceName : ClientDevices.Objects[i].GraphDeviceName,
                        OsPlatform = !string.IsNullOrEmpty(ClientDevices.Objects[i].DefenderOsPlatform) ? ClientDevices.Objects[i].DefenderOsPlatform : ClientDevices.Objects[i].GraphOperatingSystem,
                        OsVersion = !string.IsNullOrEmpty(ClientDevices.Objects[i].DefenderOsVersion) ? ClientDevices.Objects[i].DefenderOsVersion : ClientDevices.Objects[i].GraphOperatingSystemVersion,
                        OsProcessor = ClientDevices.Objects[i].DefenderOsProcessor,
                        Version = !string.IsNullOrEmpty(ClientDevices.Objects[i].DefenderVersion) ? ClientDevices.Objects[i].DefenderVersion : ClientDevices.Objects[i].GraphOperatingSystemVersion,
                        HealthStatus = ClientDevices.Objects[i].HealthStatus,
                        OnboardingStatus = ClientDevices.Objects[i].OnboardingStatus,
                        ExposureLevel = ClientDevices.Objects[i].ExposureLevel,
                        ManagedBy = ClientDevices.Objects[i].ManagedBy,
                        IsCompliant = ClientDevices.Objects[i].IsCompliant,
                        IsManaged = ClientDevices.Objects[i].IsManaged,
                        Supported = ClientDevices.Objects[i].Supported,
                        LastSeen = ClientDevices.Objects[i].LastSeen,
                        FirstSeen = ClientDevices.Objects[i].FirstSeen
                    });
                }
                DevicesResponse.ContinuationToken = !string.IsNullOrEmpty(ClientDevices.ResponseContinuation) ? Validations.EncondeBase64(ClientDevices.ResponseContinuation) : ClientDevices.ResponseContinuation;

            }
            return DevicesResponse;
        }


        private protected string GetQueryDevices(DeviceRequest DeviceRequest)
        {
            StringBuilder StringBuilder = new();
            StringBuilder.Append("SELECT ");
            StringBuilder.Append("c.id,");
            StringBuilder.Append("c.aadDeviceId,");
            StringBuilder.Append("c.defenderDeviceId ,");
            StringBuilder.Append("c.defenderDeviceName ,");
            StringBuilder.Append("c.defenderOsPlatform ,");
            StringBuilder.Append("c.defenderOsVersion ,");
            StringBuilder.Append("c.defenderOsProcessor ,");
            StringBuilder.Append("c.defenderVersion ,");
            StringBuilder.Append("c.graphDeviceId ,");
            StringBuilder.Append("c.graphDeviceName ,");
            StringBuilder.Append("c.graphOperatingSystem ,");
            StringBuilder.Append("c.graphOperatingSystemVersion ,");
            StringBuilder.Append("c.healthStatus ,");
            StringBuilder.Append("c.onboardingStatus ,");
            StringBuilder.Append("c.exposureLevel ,");
            StringBuilder.Append("c.managedBy ,");
            StringBuilder.Append("c.isCompliant ,");
            StringBuilder.Append("c.isManaged ,");
            StringBuilder.Append("c.supported ,");
            StringBuilder.Append("c.firstSeen ,");
            StringBuilder.Append("c.lastSeen ");
            StringBuilder.Append($"FROM c WHERE c.companyId = '{DeviceRequest.ClientId}' AND c.collectionType = '{InternalGuardianCollectionType.ClientDevice}'");
            bool Supported = DeviceRequest.DeviceType == DeviceType.Supported;
            StringBuilder.Append($" AND c.supported = {Supported.ToString().ToLower()} ORDER BY c.date DESC");
            return StringBuilder.ToString();
        }
    }
}
