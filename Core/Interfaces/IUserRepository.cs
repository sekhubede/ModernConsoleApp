using Core.Models;

namespace Core.Interfaces;

public interface IUserRepository
{
    Task AddUserAsync(User user);
    Task<List<User>> GetUsersAsync();
}
