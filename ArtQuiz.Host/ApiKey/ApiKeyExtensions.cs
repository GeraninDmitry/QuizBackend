using Microsoft.AspNetCore.Authentication;

namespace ArtQuiz.Host.ApiKey;

public static class ApiKeyExtensions
{
    public static AuthenticationBuilder AddApiKey(this AuthenticationBuilder builder)
    {
        return builder.AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>(
            ApiKeyDefaults.AuthenticationScheme,
            options => { }
        );
    }
}