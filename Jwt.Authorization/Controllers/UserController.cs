using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Authentication.Authorization.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpGet("read")]
    public async Task<IActionResult> GetMe(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return Ok("Read profile");
    }
}
