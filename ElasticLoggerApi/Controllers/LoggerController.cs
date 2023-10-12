using ILogger = ElasticLoggerApi.Services.ILogger;
using Microsoft.AspNetCore.Mvc;

namespace ElasticLoggerApi.Controllers;

[Route("api/logger")]
[ApiController]
public class LoggerController : ControllerBase
{
    private readonly ILogger logger;

    public LoggerController(ILogger logger)
    {
        this.logger = logger;
    }

    [HttpPost("log-debug")]
    public void LogDebug([FromBody] string content)
    {
        logger.Debug(content);
    }

    [HttpPost("log-error")]
    public void LogError([FromBody] string content)
    {
        logger.Error(content);
    }
}
