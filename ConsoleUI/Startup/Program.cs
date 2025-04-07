using ConsoleUI.Commands;
using ConsoleUI.Interfaces;
using ConsoleUI.Services;
using ConsoleUI.Views;
using Core.Events;
using Core.Interfaces;
using DataAccess.Data;
using DataAccess.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var services = ConfigureServices();
var serviceProvider = services.BuildServiceProvider();

// Apply migrations to ensure the database exists with the proper schema
using (var scope = serviceProvider.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated(); // This will create the database and tables
}

// Add this to ensure LoggerSrevice is instantiated
serviceProvider.GetRequiredService<ILoggerService>();

// Start the application
var mainView = serviceProvider.GetService<MainView>();
await mainView.RenderAsync();

static IServiceCollection ConfigureServices()
{
    var services = new ServiceCollection();

    // Register Data Access Layer
    services.AddDbContext<AppDbContext>(options =>
           options.UseSqlite("Data Source=app.db"));

    // Register DataAccess Repositories
    services.AddScoped<IUserRepository, UserRepository>();

    // Register Core Contracts
    services.AddSingleton<IEventBus, EventBus>();
    services.AddSingleton<IUserService, UserService>();
    services.AddSingleton<ILoggerService, LoggerService>(provider =>
    {
        var logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        var eventBus = provider.GetRequiredService<IEventBus>();
        return new LoggerService(logger, eventBus);
    });

    // Register UI Services
    services.AddSingleton<INavigationService, NavigationService>();
    services.AddSingleton<ICommandHandler, CommandHandler>();

    // Register Views
    services.AddSingleton<MainView>();
    services.AddSingleton<UserManagementView>();

    return services;
}