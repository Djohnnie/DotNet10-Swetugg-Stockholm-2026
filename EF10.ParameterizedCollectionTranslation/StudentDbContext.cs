using EF10.ParameterizedCollectionTranslation.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF10.ParameterizedCollectionTranslation;

internal class StudentDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=.\\SQLDEV;Database=EF10ParameterizedCollection;Integrated Security=true;Trusted_Connection=True;Encrypt=false";
        optionsBuilder.UseSqlServer(connectionString, options =>
        {
            options.UseParameterizedCollectionMode(ParameterTranslationMode.MultipleParameters);
        });
        optionsBuilder.LogTo(ConsoleWriteLine);
        optionsBuilder.EnableSensitiveDataLogging();
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