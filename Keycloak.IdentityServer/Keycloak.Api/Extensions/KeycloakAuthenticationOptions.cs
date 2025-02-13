using Keycloak.AuthServices.Common;

namespace Keycloak.Api.Extensions;

/// <summary>
/// Defines a set of options used to perform authentication
/// </summary>
public class KeycloakAuthenticationOptions : KeycloakInstallationOptions
{
    /// <summary>
    /// Default section name. => "Keycloak" key
    /// </summary>
    public const string Section = ConfigurationConstants.ConfigurationPrefix;

    /// <summary>
    /// Gets or sets the audience for the authentication. Takes priority over Resource.
    /// </summary>
    public string? Audience { get; set; }

    /// <summary>
    /// Gets or sets the claim type used for roles. => "role" claim'name key
    /// </summary>
    public string RoleClaimType { get; set; } = KeycloakConstants.RoleClaimType;

    /// <summary>
    /// Gets or sets the claim type used for the name. => "preferred_username" claim'name key
    /// </summary>
    public string NameClaimType { get; set; } = KeycloakConstants.NameClaimType;

    /// <summary>
    /// Gets the OpenId Connect URL to discover OAuth2 configuration values.
    /// </summary>
    /// <example>
    /// KeycloakUrlRealm = "http://localhost:8080/realms/Test/"
    /// OpenIdConnectConfigurationPath = ".well-known/openid-configuration"
    /// => OpenIdConnectUrl = "http://localhost:8080/realms/Test/.well-known/openid-configuration"
    /// </example>
    public string? OpenIdConnectUrl =>
        string.IsNullOrWhiteSpace(this.KeycloakUrlRealm) ? default : $"{this.KeycloakUrlRealm}{KeycloakConstants.OpenIdConnectConfigurationPath}";

    /// <summary>
    /// Gets or sets the roles mapping from access_token mapping
    /// </summary>
    public bool DisableRolesAccessTokenMapping { get; set; }
}
