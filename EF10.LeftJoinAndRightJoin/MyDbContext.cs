using EF10.LeftJoinAndRightJoin.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF10.LeftJoinAndRightJoin;

internal class MyDbContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=.\\SQLDEV;Database=EF10LeftJoinRightJoin;Integrated Security=true;Trusted_Connection=True;Encrypt=false";
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