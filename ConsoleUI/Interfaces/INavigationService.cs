namespace ConsoleUI.Interfaces;

public interface INavigationService
{
    void NavigateTo<T>() where T : IView;
}
