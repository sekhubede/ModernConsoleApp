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

    public void Render()
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
                    _userService.AddUser(name);
                    break;
                case "2":
                    _userService.ListUsers();
                    break;
                case "3":
                    _navigationService.NavigateTo<MainView>();
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
