using ConsoleUI.Commands;
using ConsoleUI.Interfaces;
using ConsoleUI.Services;
using ConsoleUI.Views;
using Core.Interfaces;
using Infrastructure.Services;

var services = ConfigureServices();
var serviceProvider = services.BuildServiceProvider();

// Start the application
var mainView = serviceProvider.GetService<MainView>();
mainView.Render();

static IServiceCollection ConfigureServices()
{
    var services = new ServiceCollection();

    // Register Core Contracts
    services.AddSingleton<IUserService, UserService>();
    services.AddSingleton<ILoggerService, LoggerService>();

    // Register UI Services
    services.AddSingleton<INavigationService, NavigationService>();
    services.AddSingleton<ICommandHandler, CommandHandler>();

    // Register Views
    services.AddSingleton<MainView>();
    services.AddSingleton<UserManagementView>();

    return services;
}
