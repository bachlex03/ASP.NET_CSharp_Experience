namespace Keycloak.Api.Models;

public record Workspace(string Name, int? MembersCount = default);