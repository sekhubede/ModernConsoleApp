using ConsoleUI.Interfaces;

namespace ConsoleUI.Services;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider _serviceProvider;
    public NavigationService(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public async Task NavigateToAsync<T>() where T : IView
    {
        var view = _serviceProvider.GetRequiredService<T>();
        await view?.RenderAsync();
    }
}
