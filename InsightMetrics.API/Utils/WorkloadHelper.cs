using ForsyteIT.CosmosAPI.Models.Guardian.Classes.Csam;

namespace InsightMetrics.API.Utils
{
    /// <summary>
    /// Provides helper methods for handling deployment workload types.
    /// </summary>
    public struct WorkloadHelper
    {
        /// <summary>
        /// Gets a user-friendly description for a given <see cref="DeploymentType"/>.
        /// </summary>
        /// <param name="workload">The deployment type enum value.</param>
        /// <returns>A descriptive string for the given workload.</returns>
        public static string GetWorkloadDescription(DeploymentType Workload)
        {
            return Workload switch
            {
                DeploymentType.ConditionalAccess => "Conditional Access Policies",
                DeploymentType.DisasterRecovery => "Disaster Recovery Planning",
                DeploymentType.Sentinel => "Microsoft Sentinel Configuration",
                DeploymentType.DefenderforEndpoint => "Endpoint Protection Setup",
                DeploymentType.Intune => "Device Management with Intune",
                DeploymentType.DefenderforIdentity => "Identity Threat Protection",
                DeploymentType.DefenderforCloudApps => "Cloud App Security Integration",
                DeploymentType.GeneralAAD => "General Azure AD Configuration",
                DeploymentType.DefenderforOffice365 => "Office 365 Security Policies",
                DeploymentType.AzureADIdentityProtection => "Azure AD Risk-Based Access",
                DeploymentType.SSPR => "Self-Service Password Reset",
                DeploymentType.PIM => "Privileged Identity Management",
                DeploymentType.M365Defender => "Microsoft 365 Defender Setup",
                DeploymentType.MicrosoftSentinel => "Advanced Sentinel Setup",
                DeploymentType.DefenderforCloud => "Cloud Infrastructure Security",
                DeploymentType.GeneralGuardian365 => "General Guardian 365 Onboarding",
                DeploymentType.Customer => "Customer-Specific Implementation",
                _ => "Unknown Workload"
            };
        }
    }
}
