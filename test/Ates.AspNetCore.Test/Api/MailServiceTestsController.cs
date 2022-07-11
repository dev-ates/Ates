namespace Ates.AspNetCore.Test.Api;

using Ates.AspNetCore.MailService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class MailServiceTestsController : ControllerBase
{
    private readonly IVerificationMailService verificationMailService;

    public MailServiceTestsController(IVerificationMailService verificationMailService)
    {
        this.verificationMailService = verificationMailService;
    }
    
    [HttpGet("get")]
    public async Task<IActionResult> GetAsync()
    {
        await this.verificationMailService.SendMail("D3n3M3", "aliateees@gmail.com");

        return Ok();
    }
}
