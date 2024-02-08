using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NCU.API.METRICS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusController : ControllerBase
{
    [HttpGet] public IActionResult Ping() => Ok( new { Message = $"API is running {DateTime.Now}", Status = StatusCodes.Status200OK });
}
