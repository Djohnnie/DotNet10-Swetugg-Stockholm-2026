using EF10.JsonTypeSupportForSqlServer2025.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF10.JsonTypeSupportForSqlServer2025;

internal class BlogDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=.\\SQLDEV;Database=EF10Json;Integrated Security=true;Trusted_Connection=True;Encrypt=false";
        optionsBuilder.UseSqlServer(connectionString, options =>
        {
            options.UseCompatibilityLevel(170);
        });
        optionsBuilder.LogTo(ConsoleWriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>().ComplexProperty(b => b.Details, b => b.ToJson());
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