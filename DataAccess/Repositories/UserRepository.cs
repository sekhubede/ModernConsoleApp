using Core.Interfaces;
using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddUserAsync(Core.Models.User user)
    {
        var entityUser = new User
        {
            Id = user.Id,
            Name = user.Name
        };
        await _context.Users.AddAsync(entityUser);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Core.Models.User>> GetUsersAsync()
    { 
        var entityUsers = await _context.Users.ToListAsync();
        return entityUsers.Select(u => new Core.Models.User
        {
            Id = u.Id,
            Name = u.Name
        }).ToList();
    }
}
