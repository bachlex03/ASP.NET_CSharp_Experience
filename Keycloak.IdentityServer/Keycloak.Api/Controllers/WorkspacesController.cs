using Keycloak.Api.Services;
using Keycloak.AuthServices.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Keycloak.Api.Controllers;

#region WorkspaceAPI

[ApiController]
[Route("workspaces")]
[OpenApiTag("Workspaces", Description = "Manage workspaces.")]
[ProtectedResource("workspaces")]
public class WorkspacesController : ControllerBase
{
    private readonly WorkspaceService _workspaceService;

    public WorkspacesController(WorkspaceService workspaceService)
    {
        _workspaceService = workspaceService;
    }

    [HttpGet(Name = nameof(GetWorkspacesAsync))]
    [OpenApiOperation("[workspace:list]", "")]
    [ProtectedResource("workspaces", "workspace:list")]
    public async Task<ActionResult<IEnumerable<string>>> GetWorkspacesAsync()
    {
            var workspaces = await _workspaceService.ListWorkspacesAsync();
        //try
        //{
        //}
        //catch(Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}

        return Ok("GetWorkspacesAsync");
    }
}

#endregion WorkspaceAPI