namespace Core.Interfaces;

public interface ILoggerService
{
    void LogInformation(string message);
    void LogWarning(string message);
    void LogError(string message);
    void LogCritical(string message);
    void LogDebug(string message);
}
