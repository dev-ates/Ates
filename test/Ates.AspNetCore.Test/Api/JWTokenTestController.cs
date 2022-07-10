namespace Ates.AspNetCore.Test.Api;

using Ates.AspNetCore.JWToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class JWTokenTestController : ControllerBase
{
    private readonly JWTAuthenticationManager jWTAuthenticationManager;

    public JWTokenTestController(JWTAuthenticationManager jWTAuthenticationManager)
    {
        this.jWTAuthenticationManager = jWTAuthenticationManager;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate(String username, String password)
    {
        var token = this.jWTAuthenticationManager.Authenticate(username, password);

        if (token == null)
            return Unauthorized();

        return Ok(token);
    }

    [HttpGet("deneme")]
    public IActionResult Deneme()
    {
        return Ok("Başarılı.......");
    }
}
