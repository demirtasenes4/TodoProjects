using Microsoft.EntityFrameworkCore;
using TodoWebApi.Models;

namespace TodoWebApi.Context;

public sealed class TodoApiContextDb : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=QUADESH;Initial Catalog=TodoApiDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>().HasKey(t => t.Id);
        modelBuilder.Entity<Todo>().HasIndex(t => t.Work).IsUnique();

        modelBuilder.Entity<Todo>().HasData(
            new Todo { Id = 1, Work = "Get to work", IsCompleted = false },
            new Todo { Id = 2, Work = "Pick up groceries", IsCompleted = false },
            new Todo { Id = 3, Work = "Go home", IsCompleted = false },
            new Todo { Id = 4, Work = "Fall asleep", IsCompleted = false },
            new Todo { Id = 5, Work = "Get up", IsCompleted = true },
            new Todo { Id = 6, Work = "Brush teeth", IsCompleted = true },
            new Todo { Id = 7, Work = "Take a shower", IsCompleted = true },
            new Todo { Id = 8, Work = "Check e-mail", IsCompleted = true },
            new Todo { Id = 9, Work = "Walk dog", IsCompleted = true },
            new Todo { Id = 10, Work = "Throw out trash", IsCompleted = false });
    }
}
