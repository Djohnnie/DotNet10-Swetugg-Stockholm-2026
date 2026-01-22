using EF10.ComplexTypesImprovements.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF10.ComplexTypesImprovements;

internal class ShopDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=.\\SQLDEV;Database=EF10ComplexTypesImprovements;Integrated Security=true;Trusted_Connection=True;Encrypt=false";
        optionsBuilder.UseSqlServer(connectionString, options =>
        {
            options.UseCompatibilityLevel(170);
        });
        optionsBuilder.LogTo(ConsoleWriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ComplexProperty(p => p.ShippingAddress);
            entity.ComplexProperty(p => p.BillingAddress);
            entity.ComplexProperty(p => p.BusinessInfo, b => b.ToJson());
        });
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