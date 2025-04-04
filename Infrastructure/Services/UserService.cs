using Core.Interfaces;
using Core.Models;
using Infrastructure.Events;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly List<User> _users = new();
    private readonly ILoggerService _logger;

    public UserService(ILoggerService logger)
    {
        _logger = logger;
    }

    public async Task AddUserAsync(string name)
    {
        // Simulate some async work
        await Task.Delay(100);

        if (string.IsNullOrWhiteSpace(name))
        {
            EventBus.PublishFailure("User name cannot be empty.");
            return;
        }

        _users.Add(new User { name = name });
        EventBus.PublishSuccess($"User '{name}' added successfully.");
    }

    public async Task ListUsersAsync()
    {
        // Simulate some async work
        await Task.Delay(100);

        _logger.LogInformation("Listing users...");
        Console.WriteLine("\nUser List:");
        _users.ForEach(user => Console.WriteLine($"- {user.name}"));
    }
}
