using ForsyteIT.Guardian.Logic.Cruds;
using ForsyteIT.Guardian.Models.Report;
using ForsyteIT.Guardian.Models.Types.Enums;
using InsightMetrics.API.Models.Account;
using InsightMetrics.API.Repositories.Interfaces;

namespace InsightMetrics.API.Repositories.Implementations
{
    public class UserActivityRepository : IUserActivityRepository
    {
        /// <summary>
        /// Retrieves the user activity summary for a specific client.
        /// </summary>
        /// <param name="clientId">The unique identifier of the client.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains an <see cref="AccountReportResponse"/> with user activity summary data.
        /// </returns>
        public async Task<AccountReportResponse> GetUserActivitySummaryAsync(string clientId)
        {
            CrudAccountReport crudAccountReport = new();
            List<AccountReport> accountReports = await crudAccountReport.Get(q => q.CollectionType == InternalGuardianCollectionType.AccountReport && q.CompanyId == clientId);
            AccountReportResponse accountReportResponse = new();
            foreach (AccountReport accountReport in accountReports)
            {
                accountReportResponse.MemberAccounts = accountReport.MemberAccounts;
                accountReportResponse.MemberAccountsEnable = accountReport.MemberAccountsEnable;
                accountReportResponse.MemberAccountsDisable = accountReport.MemberAccountsDisable;
                accountReportResponse.GuestAccounts = accountReport.GuestAccounts;
                accountReportResponse.GuestAccountsEnable = accountReport.GuestAccountsEnable;
                accountReportResponse.GuestAccountsDisable = accountReport.GuestAccountsDisable;
                accountReportResponse.AccountsDisable = accountReport.AccountsDisable;
                accountReportResponse.AccountsEnable = accountReport.AccountsEnable;
                accountReportResponse.TotalAccounts = accountReport.TotalAccounts;
            }
            return accountReportResponse;
        }
    }
}
