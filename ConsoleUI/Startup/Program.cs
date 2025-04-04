using ConsoleUI.Commands;
using ConsoleUI.Interfaces;
using ConsoleUI.Services;
using ConsoleUI.Views;
using Core.Interfaces;
using Core.Services;
using Infrastructure.Interfaces;
using Infrastructure.Services;

var services = ConfigureServices();
var serviceProvider = services.BuildServiceProvider();

// Start the application
var mainView = serviceProvider.GetService<MainView>();
mainView.Render();

static IServiceCollection ConfigureServices()
{
    var services = new ServiceCollection();

    // Register Core Services
    services.AddSingleton<IUserService, UserService>();

    // Register UI Services
    services.AddSingleton<INavigationService, NavigationService>();
    services.AddSingleton<MainView>();
    services.AddSingleton<UserManagementView>();
    services.AddSingleton<ICommandHandler, CommandHandler>();

    // Register Infrastructure Services
    services.AddSingleton<ILoggerService, LoggerService>();

    return services;
}
