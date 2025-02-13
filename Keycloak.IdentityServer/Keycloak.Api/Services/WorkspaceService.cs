using Keycloak.Api.Models;
using Keycloak.AuthServices.Sdk.Kiota.Admin;
using Keycloak.AuthServices.Sdk.Kiota.Admin.Models;
using Keycloak.AuthServices.Sdk.Protection;
using Keycloak.AuthServices.Sdk.Protection.Models;
using Keycloak.AuthServices.Sdk.Protection.Requests;

namespace Keycloak.Api.Services;

public class WorkspaceService
{
    private readonly KeycloakAdminApiClient _keycloakAdminApiClient;

    private const string DefaultRealm = "Test";
    private static readonly string[] Scopes =
    [
        "workspace:list",
        "workspace:create",
        "workspace:read",
        "workspace:delete",
        "workspace:list-users",
        "workspace:add-user",
        "workspace:remove-user"
    ];
    private const string WorkspaceType = "urn:workspaces";

    public WorkspaceService(KeycloakAdminApiClient keycloakAdminApiClient)
    {
        _keycloakAdminApiClient = keycloakAdminApiClient;
    }

    public async Task<IEnumerable<Workspace>> ListWorkspacesAsync()
    {
        var groups = await _keycloakAdminApiClient.Admin.Realms[DefaultRealm].Groups.GetAsync();

        return groups!.Select(x => Map(x, default));
    }

    private static Workspace Map(GroupRepresentation group, int membersCount) =>
    new(group.Name!, membersCount);
}
