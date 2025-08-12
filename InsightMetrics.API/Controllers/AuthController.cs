using InsightMetrics.API.Models;
using InsightMetrics.API.Models.Auth;
using InsightMetrics.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace InsightMetrics.API.Controllers
{
    /// <summary>
    /// Controller for handling authentication-related actions such as generating tokens, sending OTPs, and verifying OTPs.
    /// </summary>
    [Route("api/auth")]
    [ApiController]
    public class AuthController(IAuthService AuthService, IWebHostEnvironment IWebHostEnvironment) : ControllerBase
    {
        private readonly IAuthService _AuthService = AuthService ?? throw new ArgumentNullException(nameof(AuthService));
        private readonly IWebHostEnvironment _WebHostEnvironment = IWebHostEnvironment ?? throw new ArgumentNullException(nameof(IWebHostEnvironment));
#if DEBUG
        /// <summary>
        /// Authenticates a user and generates a JWT token (development only).
        /// </summary>
        /// <param name="tokenRequest">The request body containing user credentials.</param>
        /// <returns>A JWT token if authentication is successful, otherwise an error response.</returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        [SwaggerOperation(
            Summary = "Authenticate user and return JWT (DEV only)",
            Description = "Generates a JWT token for development/testing purposes using provided credentials.",
            OperationId = "AuthenticateDev",
            Tags = new[] { "Auth" }
        )]
        [Produces("application/json")]
        [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAuthenticateAsync([FromBody] TokenRequest TokenRequest)
        {
            if (!_WebHostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var result = await _AuthService.GenerateTokenAsync(TokenRequest);
            if (!result.Success)
            {
                return BadRequest(new ErrorResponse()
                {
                    Error = true,
                    ErrorDescription = result.Message ?? string.Empty,
                    Timestamp = DateTime.UtcNow,
                    TraceId = Guid.NewGuid().ToString(),
                    Email = User.FindFirstValue(ClaimTypes.Email)
                });
            }
            return Ok(result);
        }
#endif
    }
}
