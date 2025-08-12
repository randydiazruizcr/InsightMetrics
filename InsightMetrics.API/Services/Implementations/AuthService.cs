using InsightMetrics.API.Models.Auth;
using InsightMetrics.API.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InsightMetrics.API.Services.Implementations
{
    /// <summary>
    /// Interface for authentication service, responsible for token generation
    /// </summary>
    public class AuthService(JwtSettings JwtSettings) : IAuthService
    {
        private readonly JwtSettings _JwtSettings = JwtSettings ?? throw new ArgumentNullException(nameof(JwtSettings));

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
        public Task<ServiceResult<object>> GenerateTokenAsync(TokenRequest tokenRequest)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(tokenRequest.Email))
            {
                return Task.FromResult(ServiceResult<object>.Fail($"The email is requeried"));
            }

            try
            {
                var key = _JwtSettings.Key;
                var issuer = _JwtSettings.Issuer;
                var audience = _JwtSettings.Audience;
                var expireMinutes = int.Parse(_JwtSettings.ExpiryMinutes.ToString() ?? "60");
                // Generate claims
                var Claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, tokenRequest.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                // Secure the key and credentials
                var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

                // Create token with UTC expiration time
                var Token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: Claims,
                    expires: DateTime.UtcNow.AddMinutes(expireMinutes),
                    signingCredentials: Creds
                );

                var response = new TokenResponse()
                {
                    TokenType = "Bearer",
                    ExpiresIn = expireMinutes * 60,
                    ExtExpiresIn = expireMinutes * 60,
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(Token),
                };

                // Return response
                return Task.FromResult(ServiceResult<object>.Ok("Registration completed successfully.", response));
            }
            catch (Exception Exception)
            {
                return Task.FromResult(ServiceResult<object>.Fail($"An error occurred during registration: {Exception.Message}"));
            }
        }
    }
}
