﻿using ConsoleUI.Interfaces;
using Spectre.Console;

namespace ConsoleUI.Views;

public class MainView : IView
{
    private readonly INavigationService _navigationService;
    private readonly ICommandHandler _commandHandler;

    public MainView(INavigationService navigationService, ICommandHandler commandHandler)
    {
        _navigationService = navigationService;
        _commandHandler = commandHandler;
    }

    public async Task RenderAsync()
    {
        while (true)
        {
            AnsiConsole.Markup("[bold green]\nMain Menu:[/]");
            Console.WriteLine("\n1. Manage Users");
            Console.WriteLine("2. Exit");
            Console.WriteLine("Select an option: ");

            var input = Console.ReadLine();

            if (input == "2")
            {
                Console.WriteLine("\nExiting application...");
                Environment.Exit(0);
            }

            if (!string.IsNullOrEmpty(input))
                await _commandHandler.ExecuteAsync(input);
        }
    }
}
