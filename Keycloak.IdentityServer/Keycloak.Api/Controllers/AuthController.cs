using Keycloak.AuthServices.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace JWT.Authentication.Authorization.Controllers;

[ApiController]
[Route("auth")]
[OpenApiTag("Auth", Description = "Authentication.")]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return Ok();
    }
}
