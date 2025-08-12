using TimeZoneConverter;

namespace InsightMetrics.API.Utils
{
    /// <summary>
    /// Provides helper methods for handling time zone conversions based on the operating system.
    /// </summary>
    public struct TimezoneHelper
    {
        /// <summary>
        /// Converts a Windows time zone ID to its IANA equivalent if running on a non-Windows OS.
        /// Defaults to "Eastern Standard Time" if the input is null.
        /// </summary>
        /// <param name="TimeZonedId">
        /// The Windows time zone ID to convert. If null, defaults to "Eastern Standard Time".
        /// </param>
        /// <returns>
        /// A string representing the time zone ID, converted to IANA format if applicable.
        /// </returns>
        /// <remarks>
        /// This method uses the TimeZoneConverter (TZConvert) library to ensure cross-platform compatibility.
        /// </remarks>
        public static string TimeZoneBaseOnOs(string TimeZonedId)
        {
            TimeZonedId ??= "Eastern Standard Time";
            if (TZConvert.KnownWindowsTimeZoneIds.Any(q => q == TimeZonedId))
            {
#pragma warning disable S6575 // Use "TimeZoneInfo.FindSystemTimeZoneById" without converting the timezones with "TimezoneConverter"
                TimeZonedId = TZConvert.WindowsToIana(TimeZonedId);
#pragma warning restore S6575 // Use "TimeZoneInfo.FindSystemTimeZoneById" without converting the timezones with "TimezoneConverter"
            }
            return TimeZonedId;
        }
    }
}
