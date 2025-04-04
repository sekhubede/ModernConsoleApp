namespace Core.Interfaces;

public interface IUserService
{
    Task AddUserAsync(string name);
    Task ListUsersAsync();
}
