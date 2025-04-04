namespace ConsoleUI.Interfaces;

public interface INavigationService
{
    Task NavigateToAsync<T>() where T : IView;
}
