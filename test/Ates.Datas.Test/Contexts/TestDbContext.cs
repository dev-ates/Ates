namespace Ates.Datas.Test.Contexts;

using Ates.Datas.Test.Models;
using Microsoft.EntityFrameworkCore;

internal class TestDbContext : DbContext
{
    public DbSet<User> Users
    {
        get; set;
    } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            _ = optionsBuilder.UseSqlite("Filename = TestDb.db");
        }

        base.OnConfiguring(optionsBuilder);
    }
}
