using Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Core.Events;
public class EventBus : IEventBus
{
    public event Action<string>? OnSuccess = delegate { };
    public event Action<string>? OnFailure = delegate { };

    // Dictionary to store event handlers for different event types
    private readonly Dictionary<string, List<Delegate>> _eventHandlers = new();

    public void PublishSuccess(string message) =>
        OnSuccess?.Invoke(message);

    public void PublishFailure(string message) =>
        OnFailure?.Invoke(message);

    public void PublishData<T>(string eventName, T data)
    {
        if (_eventHandlers.TryGetValue(eventName, out var handlers))
        {
            foreach (var handler in handlers)
            {
                if (handler is Action<T> typedHandler)
                {
                    typedHandler(data);
                }
            }
        }
    }

    public bool IsSubscribed<T>(string eventName, Action<T> handler)
    {
        if (_eventHandlers.TryGetValue(eventName, out var handlers))
        {
            return handlers.Contains(handler);
        }
        return false;
    }

    public void Subscribe<T>(string eventName, Action<T> handler)
    {
        // Check if the handler is already subscribed
        if (IsSubscribed(eventName, handler))
        {
            return; // Already subscribed, don't add again
        }

        if (!_eventHandlers.ContainsKey(eventName))
        {
            _eventHandlers[eventName] = new List<Delegate>();
        }

        _eventHandlers[eventName].Add(handler);
    }

    public void Unsubscribe<T>(string eventName, Action<T> handler)
    {
        if (_eventHandlers.TryGetValue(eventName, out var handlers))
        {
            handlers.Remove(handler);

            // Remove the event entirely if no handlers remain
            if (handlers.Count == 0)
            {
                _eventHandlers.Remove(eventName);
            }
        }
    }
}