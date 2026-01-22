using EF10.VectorSearchSupportForSqlServer2025.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF10.VectorSearchSupportForSqlServer2025;

internal class FirstNamesDbContext : DbContext
{
    public DbSet<FirstName> FirstNames { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.\\SQLDEV;Database=EF10Vector;Integrated Security=true;Trusted_Connection=True;Encrypt=false");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FirstName>()
            .Property(b => b.Embedding)
            .HasColumnType("vector(768)");
    }
}