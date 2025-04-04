using DataAccess.Data;
using DataAccess.Entities;
using Infrastructure.Events;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class UserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        EventBus.PublishSuccess($"User '{user.Name}' added to database!");
    }

    public async Task<List<User>> GetUsersAsync() => await _context.Users.ToListAsync();
}
