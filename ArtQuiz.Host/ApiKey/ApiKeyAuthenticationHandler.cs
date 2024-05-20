using System.Security.Claims;
using System.Text.Encodings.Web;
using ArtQuiz.Application.Queries.GetUserByApiKeyQuery;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using OneOf;
using UseCases;

// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Logging;

namespace ArtQuiz.Host.ApiKey
{
    class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private const string API_KEY_HEADER = "Api-Key";

        private readonly IQueryExecutor _queryExecutor;

        public ApiKeyAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IQueryExecutor queryExecutor) : base(options, logger, encoder, clock)
        {
            _queryExecutor = queryExecutor;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey(API_KEY_HEADER))
                return AuthenticateResult.Fail("Header Not Found.");

            string apiKeyToValidate = Request.Headers[API_KEY_HEADER];
            
            var validationResult = (await _queryExecutor.Execute(new GetUserByApiKeyQuery(apiKeyToValidate)))
                .Match(
                    success => AuthenticateResult.Success(CreateTicket(success.Value.User)),
                    notFound => AuthenticateResult.Fail("Invalid key.")
                );

            return validationResult;
        }

        private AuthenticationTicket CreateTicket(IdentityUser user)
        {
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return ticket;
        }
    }
}