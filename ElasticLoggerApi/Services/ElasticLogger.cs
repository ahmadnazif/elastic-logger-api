using NLog;
using NLog.Config;
using System.Runtime.CompilerServices;

namespace ElasticLoggerApi.Services;

public class ElasticLogger : ILogger
{
    private readonly NLog.Logger debugLogger = LogManager.GetLogger("Debug");
    private readonly NLog.Logger dbErrorLogger = LogManager.GetLogger("DbError");
    private readonly NLog.Logger errorLogger = LogManager.GetLogger("Error");

    public LoggingConfiguration LoggingConfiguration { get; }

    public ElasticLogger(IConfiguration cfg)
    {
        var logList = LoggersToAdd();

        NLogConfig config = new();
        foreach (var log in logList)
            config.AddLog(log);
        LoggingConfiguration = config.FinalizeConfig();
    }

    private static List<string> LoggersToAdd()
    {
        return new()
        {
            "Debug",
            "DbError",
            "Error"
        };
    }

    public void Debug(string txt)
    {
        debugLogger.Info(txt);
    }

    public void DbError(Exception ex, bool detailed, [CallerMemberName] string caller = null, [CallerLineNumber] int? line = null)
    {
        var methodName = ex.TargetSite == null ? "Unknown method" : $"{caller}, Ln. {line}";

        if (detailed)
            dbErrorLogger.Error($"{methodName} | {ex} | Inner exception message: {ex.InnerException?.Message}");
        else
            dbErrorLogger.Error($"{methodName} | {ex.Message}");
    }

    public void Error(string txt)
    {
        errorLogger.Error(txt);
    }
}
