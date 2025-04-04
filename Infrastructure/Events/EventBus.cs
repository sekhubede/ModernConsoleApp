namespace Infrastructure.Events;

public static class EventBus
{
    public static event Action<string>? OnSuccess;
    public static event Action<string>? OnFailure;

    public static void PublishSuccess(string message) =>
        OnSuccess?.Invoke(message);

    public static void PublishFailure(string message) =>
        OnFailure?.Invoke(message);
}
