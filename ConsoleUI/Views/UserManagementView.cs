using ConsoleUI.Interfaces;
using Core.Interfaces;
using Spectre.Console;

namespace ConsoleUI.Views;

public class UserManagementView : IView
{
    private readonly IUserService _userService;
    private readonly INavigationService _navigationService;

    public UserManagementView(IUserService userService, INavigationService navigation)
    {
        _userService = userService;
        _navigationService = navigation;
    }

    public async Task RenderAsync()
    {
        while (true)
        {
            AnsiConsole.Markup("[bold blue]\nUser Management:[/]");
            Console.WriteLine("\n1. Add User");
            Console.WriteLine("2. List Users");
            Console.WriteLine("3. Back to Main Menu");
            Console.WriteLine("Select an option: ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Enter user name: ");
                    var name = Console.ReadLine();
                    await _userService.AddUserAsync(name);
                    break;
                case "2":
                    await _userService.ListUsersAsync();
                    break;
                case "3":
                    await _navigationService.NavigateToAsync<MainView>();
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
