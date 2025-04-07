using Core.Interfaces;
using Serilog;

namespace Infrastructure.Services;

public class LoggerService : ILoggerService
{
    private readonly ILogger _logger;
    private readonly IEventBus _eventBus;

    public LoggerService(ILogger logger, IEventBus eventBus)
    {
       _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        eventBus.OnSuccess += LogInformation;
        eventBus.OnFailure += LogError;
    }

    public void LogInformation(string message) => _logger.Information(message);
    public void LogWarning(string message) => _logger.Warning(message);
    public void LogError(string message) => _logger.Error(message);
    public void LogCritical(string message) => _logger.Fatal(message);
    public void LogDebug(string message) => _logger.Debug(message);
}
