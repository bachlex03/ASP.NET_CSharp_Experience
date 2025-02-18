using Keycloak.AuthServices.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Keycloak.Api.Controllers;

[ApiController]
[Route("catalogs")]
[OpenApiTag("catalogs", Description = "Manage catalogs.")]
[ProtectedResource("catalogs")]
public class CatalogController : ControllerBase
{

    [HttpGet("products")]
    //[OpenApiOperation("[catalog:list]", "")]
    [AllowAnonymous]
    //[OpenApiIgnore]
    public async Task<ActionResult<IEnumerable<string>>> GetProductsAsync()
    {
        await Task.CompletedTask;

        return Ok("GetProductsAsync");
    }
}
