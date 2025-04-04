using ConsoleUI.Interfaces;
using ConsoleUI.Views;

namespace ConsoleUI.Commands;

public class CommandHandler : ICommandHandler
{
    private readonly INavigationService _navigationService;

    public CommandHandler(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public void Execute(string command)
    {
        switch (command.ToLower())
        {
            case "1":
                _navigationService.NavigateTo<UserManagementView>();
                break;
            case "2":
                Console.WriteLine("Exiting application...");
                break;
            default:
                Console.WriteLine("Invalid option. Try again.");
                break;
        }
    }
}
