using System.Runtime.CompilerServices;

namespace ElasticLoggerApi.Services;

public interface ILogger
{
    void Debug(string txt);
    void DbError(Exception ex, bool detailed, [CallerMemberName] string caller = null, [CallerLineNumber] int? line = null);
    void Error(string txt);
}
