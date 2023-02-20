using Microsoft.AspNetCore.Mvc;

namespace sub.Controllers;

[ApiController]
[Route("[controller]")]
public class ProcessController : ControllerBase
{
    private readonly ILogger<ProcessController> _logger;

    public ProcessController(ILogger<ProcessController> logger)
    {
        _logger = logger;
    }

    [HttpPost("/pubsubtest")]
    public void RunProcess([FromBody] object body)
    {
        _logger.LogInformation($"Processing for {body.ToString()}");
    }
}
