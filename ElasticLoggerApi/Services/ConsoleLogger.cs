using System.Runtime.CompilerServices;

namespace ElasticLoggerApi.Services;

public class ConsoleLogger : ILogger
{
    private readonly ILogger<ConsoleLogger> logger;

    public ConsoleLogger(ILogger<ConsoleLogger> logger) => this.logger = logger;

    public void DbError(Exception ex, bool detailed, [CallerMemberName] string caller = null, [CallerLineNumber] int? line = null)
    {
        var methodName = ex.TargetSite == null ? "Unknown method" : $"{caller}, Ln. {line}";

        if (detailed)
            logger.LogError($"{methodName} | {ex} | Inner exception message: {ex.InnerException?.Message}");
        else
            logger.LogError($"{methodName} | {ex.Message}");
    }

    public void Debug(string txt)
    {
        logger.LogInformation(txt);
    }
}
