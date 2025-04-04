using Infrastructure.Interfaces;
using Serilog;

namespace Infrastructure.Services;

public class LoggerService : ILoggerService
{
    private readonly ILogger _logger;

    public LoggerService()
    {
        _logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .CreateLogger();
    }

    public void LogInformation(string message) => _logger.Information(message);
    public void LogWarning(string message) => _logger.Warning(message);
    public void LogError(string message) => _logger.Error(message);
    public void LogCritical(string message) => _logger.Fatal(message);
    public void LogDebug(string message) => _logger.Debug(message);
}
