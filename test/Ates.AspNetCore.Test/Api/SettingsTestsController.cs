// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ates.AspNetCore.Test.Api;

using Ates.AspNetCore.Test.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

[Route("api/[controller]")]
[ApiController]
public class SettingsTestsController : ControllerBase
{
    private readonly IOptions<MailServiceSettings> mailServiceSettings;

    public SettingsTestsController(IOptions<MailServiceSettings> mailServiceSettings)
    {
        this.mailServiceSettings = mailServiceSettings;
    }

    // GET api/<SettingsTestsController>/5
    [HttpGet("get")]
    public IActionResult Get()
    {
        return Ok(mailServiceSettings.Value.MailAddress + " " + mailServiceSettings.Value.MailPassword);
    }
}
