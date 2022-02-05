using Microsoft.AspNetCore.Mvc;

namespace RoleBot.API.Controllers;

[Route("/api/[controller]/[action]")]
[ApiController]
public class SignInController : ControllerBase
{
    [HttpPost]
    public IActionResult Auth(string code)
    {
        return Ok("Yer");
    }
}