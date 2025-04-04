using ConsoleUI.Commands;
using ConsoleUI.Interfaces;
using ConsoleUI.Services;
using ConsoleUI.Views;
using Core.Interfaces;
using Infrastructure.Services;
using Serilog;

var services = ConfigureServices();
var serviceProvider = services.BuildServiceProvider();

// Start the application
var mainView = serviceProvider.GetService<MainView>();
await mainView.RenderAsync();

static IServiceCollection ConfigureServices()
{
    var services = new ServiceCollection();

    // Register Core Contracts
    services.AddSingleton<IUserService, UserService>();
    services.AddSingleton<ILoggerService, LoggerService>(provider =>
    {
        var logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        return new LoggerService(logger);
    });

    // Register UI Services
    services.AddSingleton<INavigationService, NavigationService>();
    services.AddSingleton<ICommandHandler, CommandHandler>();

    // Register Views
    services.AddSingleton<MainView>();
    services.AddSingleton<UserManagementView>();

    return services;
}
