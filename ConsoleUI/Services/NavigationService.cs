using ConsoleUI.Interfaces;

namespace ConsoleUI.Services;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider _serviceProvider;
    public NavigationService(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public void NavigateTo<T>() where T : IView
    {
        var view = _serviceProvider.GetRequiredService<T>();
        view?.Render();
    }
}
