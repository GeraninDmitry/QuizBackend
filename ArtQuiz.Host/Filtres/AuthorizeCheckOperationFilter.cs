using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ArtQuiz.Host.Filtres
{
    internal class AuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var hasAuthorize = context.ApiDescription.CustomAttributes().OfType<AuthorizeAttribute>().Any();

            if (hasAuthorize)
            {
                var apiKeyScheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "ApiKey"
                    }
                };

                var apiKeyRequirement = new OpenApiSecurityRequirement
                {
                    { apiKeyScheme, new List<string>() }
                };

                operation.Security = new List<OpenApiSecurityRequirement> { apiKeyRequirement };
            }
        }
    }
}