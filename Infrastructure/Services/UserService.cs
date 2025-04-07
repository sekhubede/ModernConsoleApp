using Core.Interfaces;
using Core.Models;
using DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IEventBus _eventBus;

    public UserService(IServiceProvider serviceProvider, IEventBus eventBus)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        _eventBus = eventBus;
    }

    public async Task AddUserAsync(string name)
    {
        // Simulate some async work
        await Task.Delay(100);

        using var scope = _serviceProvider.CreateScope();
        var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();

        if (string.IsNullOrWhiteSpace(name))
        {
            _eventBus.PublishFailure("User name cannot be empty.");
            return;
        }

        await userRepository.AddUserAsync(new User { Name = name});
        _eventBus.PublishSuccess($"User '{name}' added successfully.");
    }

    public async Task ListUsersAsync()
    {
        // Simulate some async work
        await Task.Delay(100);

        using var scope = _serviceProvider.CreateScope();
        var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();

        // Retrieve users from the repository
        var users = await userRepository.GetUsersAsync();
        
        _eventBus.PublishSuccess("Retrieving users completed");
        _eventBus.PublishData("UserList", users);
    }
}
