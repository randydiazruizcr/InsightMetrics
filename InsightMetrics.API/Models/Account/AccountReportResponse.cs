using Newtonsoft.Json;

namespace InsightMetrics.API.Models.Account
{
    public class AccountReportResponse
    {
        [JsonProperty(PropertyName = "memberAccounts", NullValueHandling = NullValueHandling.Ignore)]
        public int MemberAccounts { get; set; }

        [JsonProperty(PropertyName = "memberAccountsEnable", NullValueHandling = NullValueHandling.Ignore)]
        public int MemberAccountsEnable { get; set; }

        [JsonProperty(PropertyName = "memberAccountsDisable", NullValueHandling = NullValueHandling.Ignore)]
        public int MemberAccountsDisable { get; set; }

        [JsonProperty(PropertyName = "guestAccounts", NullValueHandling = NullValueHandling.Ignore)]
        public int GuestAccounts { get; set; }

        [JsonProperty(PropertyName = "guestAccountsEnable", NullValueHandling = NullValueHandling.Ignore)]
        public int GuestAccountsEnable { get; set; }

        [JsonProperty(PropertyName = "guestAccountsDisable", NullValueHandling = NullValueHandling.Ignore)]
        public int GuestAccountsDisable { get; set; }

        [JsonProperty(PropertyName = "accountsEnable", NullValueHandling = NullValueHandling.Ignore)]
        public int AccountsEnable { get; set; }

        [JsonProperty(PropertyName = "accountsDisable", NullValueHandling = NullValueHandling.Ignore)]
        public int AccountsDisable { get; set; }

        [JsonProperty(PropertyName = "totalAccounts", NullValueHandling = NullValueHandling.Ignore)]
        public int TotalAccounts { get; set; }
    }
}
