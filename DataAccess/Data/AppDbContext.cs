using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=app.db;");
    }
}
