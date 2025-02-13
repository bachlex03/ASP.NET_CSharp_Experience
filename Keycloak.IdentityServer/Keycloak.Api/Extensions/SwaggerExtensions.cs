using Keycloak.AuthServices.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Options;
using NSwag;
using NSwag.AspNetCore;
using NSwag.Generation.Processors.Security;

namespace Keycloak.Api.Extensions;

public static class SwaggerExtensions
{
    public static void AddApplicationSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddOpenApiDocument((document, sp) =>
        {
            var keycloakOptions = sp.GetRequiredService<IOptionsMonitor<KeycloakAuthenticationOptions>>()?.Get(JwtBearerDefaults.AuthenticationScheme)!;

            document.Title = "Keycloak API";

            document.AddSecurity(
                OpenIdConnectDefaults.AuthenticationScheme,
                [],
                new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.OpenIdConnect,
                    OpenIdConnectUrl = "http://localhost:8080/realms/Test/.well-known/openid-configuration",
                }
            );

            document.AddSecurity(
                JwtBearerDefaults.AuthenticationScheme,
                [],
                new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                }
            );

            //document.AddSecurity(
            //    "Keycloak",
            //    [],
            //    new OpenApiSecurityScheme
            //    {
            //        Type = OpenApiSecuritySchemeType.OAuth2,
            //        Flows = new OpenApiOAuthFlows
            //        {
            //            Implicit = new OpenApiOAuthFlow
            //            {
            //                AuthorizationUrl = $"http://localhost:8080/realms/Test/protocol/openid-connect/auth",
            //                Scopes = new Dictionary<string, string>
            //                {
            //                    { "openid", "openid" },
            //                    { "profile", "profile" },
            //                    { "email", "email" },
            //                    { "roles", "roles" },
            //                },
            //            },
            //            Password = new OpenApiOAuthFlow
            //            {
            //                TokenUrl = $"http://localhost:8080/realms/Test/protocol/openid-connect/token",
            //                Scopes = new Dictionary<string, string>
            //                {
            //                    { "openid", "openid" },
            //                    { "profile", "profile" },
            //                    { "email", "email" },
            //                    { "roles", "roles" },
            //                },
            //            }
            //        }
            //    }
            //);

            document.OperationProcessors.Add(new OperationSecurityScopeProcessor(OpenIdConnectDefaults.AuthenticationScheme));
            document.OperationProcessors.Add(new OperationSecurityScopeProcessor(JwtBearerDefaults.AuthenticationScheme));
            //document.OperationProcessors.Add(new OperationSecurityScopeProcessor("Keycloak"));

        });
    }

    public static void UseApplicationSwaggerSettings(
        this SwaggerUiSettings ui,
        IConfiguration configuration
    )
    {
        var keycloakOptions = configuration.GetKeycloakOptions<KeycloakAuthenticationOptions>()!;

        ui.OAuth2Client = new OAuth2ClientSettings
        {
            ClientId = keycloakOptions.Resource,
            ClientSecret = keycloakOptions?.Credentials?.Secret,
        };
    }
}
