using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace BozoCord.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SystemController : ControllerBase
{
    [HttpGet("version")]
    public IActionResult GetVersion()
    {
        var version = Assembly.GetExecutingAssembly().GetName().Version;
        return Ok(new
        {
            Version = version?.ToString() ?? "0.0.0",
            Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
        });
    }
} 