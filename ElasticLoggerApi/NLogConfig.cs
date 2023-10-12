using NLog.Config;
using NLog.Targets;
using NLog;
using LogLevel = NLog.LogLevel;
using NLog.Targets.ElasticSearch;

namespace ElasticLoggerApi;

public class NLogConfig
{
    private const string logLayout = "${longdate} | ${logger} || ${message}";
    private const string dateFormat = "${date:format=yyyyMMdd}";
    private readonly LoggingConfiguration logConfig;

    public NLogConfig()
    {
        logConfig = new LoggingConfiguration();
    }

    public void AddLog(string logName)
    {
        var target = new ElasticSearchTarget
        {
            Name = "Elastic",
            Index = $"{logName}{dateFormat}",
            Uri = "http://localhost:9200",
            Layout = logLayout
        };

        logConfig.AddTarget(target);
        logConfig.AddRule(LogLevel.Debug, LogLevel.Error, target, logName);
    }

    public LoggingConfiguration FinalizeConfig() => LogManager.Configuration = logConfig;
}
