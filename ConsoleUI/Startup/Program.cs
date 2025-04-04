var services = ConfigureServices();
var serviceProvider = services.BuildServiceProvider();

static IServiceCollection ConfigureServices()
{
    var services = new ServiceCollection();

    // Register Core Services
    services.AddSingleton<IUserService, UserService>();

    // Register UI Services


    // Register Infrastructure Services
}
