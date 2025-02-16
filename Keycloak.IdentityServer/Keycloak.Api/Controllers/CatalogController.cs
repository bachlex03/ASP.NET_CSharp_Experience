﻿using Keycloak.AuthServices.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Keycloak.Api.Controllers;

[ApiController]
[Route("catalogs")]
[OpenApiTag("catalogs", Description = "Manage catalogs.")]
[ProtectedResource("catalogs")]
public class CatalogController : ControllerBase
{

    [HttpGet(Name = nameof(GetProductsAsync))]
    [OpenApiOperation("[catalog:list]", "")]
    [ProtectedResource("catalogs", "catalog:list")]
    public async Task<ActionResult<IEnumerable<string>>> GetProductsAsync()
    {
        return Ok("GetProductsAsync");
    }
}
