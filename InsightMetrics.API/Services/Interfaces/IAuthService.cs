using InsightMetrics.API.Models.Auth;

namespace InsightMetrics.API.Services.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Generates a JWT token for the provided user credentials.
        /// </summary>
        /// <param name="tokenRequest">The token request containing user credentials, typically an email.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a <see cref="ServiceResult{T}"/> with a <see cref="TokenResponse"/> if successful,
        /// or an error message if the operation fails.
        /// </returns>
        /// <remarks>
        /// This method constructs a JWT token using the provided settings and signs it using HMAC SHA-256.
        /// </remarks>
        Task<ServiceResult<object>> GenerateTokenAsync(TokenRequest tokenRequest);
    }
}
