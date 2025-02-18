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


    [HttpGet("read")]
    public async Task<IActionResult> Read(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return Ok("Read profile");
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return Ok("Create profile");
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return Ok("Update profile");
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return Ok("Delete profile");
    }
}
