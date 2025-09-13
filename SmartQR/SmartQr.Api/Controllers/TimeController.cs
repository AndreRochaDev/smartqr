using Microsoft.AspNetCore.Mvc;

namespace SmartQr.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TimeController : ControllerBase
{
    private readonly ILogger<TimeController> _logger;

    public TimeController(ILogger<TimeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("qrcode-timebased-url", Name = "GetTimeBasedWikipedia")]
    public ActionResult<string> GetWikipediaUrl()
    {
        var currentHour = DateTime.Now.Hour;
        
        if (currentHour < 13) // Before 1 PM (13:00)
        {
            return Ok("https://en.wikipedia.org/wiki/Morning");
        }
        else // Equal or after 1 PM (13:00)
        {
            return Ok("https://en.wikipedia.org/wiki/Noon");
        }
    }
}