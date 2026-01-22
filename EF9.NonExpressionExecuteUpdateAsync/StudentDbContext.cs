using EF9.NonExpressionExecuteUpdateAsync.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF9.NonExpressionExecuteUpdateAsync;

internal class StudentDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=.\\SQLDEV;Database=EF10NonExpressionExecuteUpdateAsync;Integrated Security=true;Trusted_Connection=True;Encrypt=false";
        optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.LogTo(ConsoleWriteLine);
    }

    private void ConsoleWriteLine(string message)
    {
        if (message.StartsWith("info"))
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = color;
        }
    }
}