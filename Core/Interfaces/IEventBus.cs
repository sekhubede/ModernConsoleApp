namespace Core.Interfaces;
public interface IEventBus
{
    event Action<string>? OnSuccess;
    event Action<string>? OnFailure;

    void PublishSuccess(string message);
    void PublishFailure(string message);
    void PublishData<T>(string eventName, T data);
    void Subscribe<T>(string eventName, Action<T> handler);
    void Unsubscribe<T>(string eventName, Action<T> handler);
}