using Keycloak.AuthServices.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace JWT.Authentication.Authorization.Controllers;

[ApiController]
[Route("users")]
[OpenApiTag("users", Description = "Manage users.")]
[ProtectedResource("users")]
public class UserController : ControllerBase
{
    [HttpGet("profile")]
    [OpenApiOperation("[user:profile]", "")]
    [ProtectedResource("users", "user:profile")]
    public async Task<IActionResult> GetProfile(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return Ok("Your profile");
    }
}
