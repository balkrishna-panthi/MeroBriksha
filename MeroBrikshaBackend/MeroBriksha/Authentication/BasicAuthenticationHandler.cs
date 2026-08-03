using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // Check if Authorization header exists
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(
                    AuthenticateResult.Fail("Missing Authorization header"));
            }

            try
            {
                var authHeader = Request.Headers["Authorization"].ToString();

                // Expected format:
                // Authorization: Basic YWRtaW46MTIzNA==
                if (!authHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
                {
                    return Task.FromResult(
                        AuthenticateResult.Fail("Invalid authentication scheme"));
                }

                // Remove "Basic "
                var encodedCredentials = authHeader.Substring("Basic ".Length).Trim();

                // Decode Base64
                var credentialBytes = Convert.FromBase64String(encodedCredentials);
                var credentials = Encoding.UTF8.GetString(credentialBytes);

                // Split username:password
                var parts = credentials.Split(':', 2);

                if (parts.Length != 2)
                {
                    return Task.FromResult(
                        AuthenticateResult.Fail("Invalid Authorization header"));
                }

                var username = parts[0];
                var password = parts[1];

                // Validate credentials
                // Replace this with database validation later
                if (username != "admin" || password != "1234")
                {
                    return Task.FromResult(
                        AuthenticateResult.Fail("Invalid username or password"));
                }

                // Create claims
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, username)
                };

                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return Task.FromResult(
                    AuthenticateResult.Success(ticket));
            }
            catch (FormatException)
            {
                return Task.FromResult(
                    AuthenticateResult.Fail("Invalid Base64 string"));
            }
            catch (Exception ex)
            {
                return Task.FromResult(
                    AuthenticateResult.Fail(ex.Message));
            }
        }
    }
}