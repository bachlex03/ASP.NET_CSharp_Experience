using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Authentication.Authorization.Controllers;

//[Authorize]
[ApiController()]
[Route("users")]
public class UserController : ControllerBase
{
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
