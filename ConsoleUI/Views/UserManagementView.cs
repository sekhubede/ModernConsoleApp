using ConsoleUI.Interfaces;
using Core.Interfaces;
using Core.Models;
using Spectre.Console;

namespace ConsoleUI.Views;

public class UserManagementView : IView
{
    private readonly IUserService _userService;
    private readonly INavigationService _navigationService;
    private readonly IEventBus _eventBus;
    private bool _subscribed = false;

    public UserManagementView(IUserService userService, INavigationService navigation, IEventBus eventBus)
    {
        _userService = userService;
        _navigationService = navigation;
        _eventBus = eventBus;
    }

    private void DisplayUsers(List<User> users)
    {
        AnsiConsole.Markup("[bold green]\nUser List:[/]");

        if (users.Count == 0)
        {
            AnsiConsole.Markup("[italic]No users found.[/]\n");
            return;
        }

        users.ForEach(user =>
        {
            AnsiConsole.Markup($"- [cyan]{user.Name}[/]\n");
        });
    }

    public async Task RenderAsync()
    {
        // Subscribe to the event here
        _eventBus.Subscribe<List<User>>("UserList", DisplayUsers);

        try
        {
            while (true)
            {
                AnsiConsole.Markup("[bold blue]\nUser Management:[/]\n");
                AnsiConsole.Markup("1. [green]Add User[/]\n");
                AnsiConsole.Markup("2. [green]List Users[/]\n");
                AnsiConsole.Markup("3. [yellow]Back to Main Menu[/]\n");
                AnsiConsole.Markup("[bold]Select an option: [/]");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AnsiConsole.Markup("Enter user name: ");
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
                        AnsiConsole.Markup("[red]Invalid option. Try again.[/]\n");
                        break;
                }
            }
        }
        finally
        {
            // Unsubscribe from the event when done
            _eventBus.Unsubscribe<List<User>>("UserList", DisplayUsers);
        }
        
    }
}
