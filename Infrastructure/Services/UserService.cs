using Core.Interfaces;
using Core.Models;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly List<User> _users = new();
    private readonly ILoggerService _logger;

    public UserService(ILoggerService logger)
    {
        _logger = logger;
    }

    public void AddUser(string name)
    {
        _users.Add(new User { name = name });
        _logger.LogInformation($"User '{name}' added successfully!");
        Console.WriteLine("User '{name}' added successfully!");
    }

    public void ListUsers()
    {
        _logger.LogInformation("Listing users...");
        Console.WriteLine("\nUser List:");
        _users.ForEach(user => Console.WriteLine($"- {user.name}"));
    }
}
