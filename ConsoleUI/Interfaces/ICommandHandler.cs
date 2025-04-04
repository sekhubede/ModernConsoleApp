namespace ConsoleUI.Interfaces;

public interface ICommandHandler
{
    Task ExecuteAsync(string command);
}
