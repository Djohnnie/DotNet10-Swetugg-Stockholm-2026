using EF10.CustomDefaultConstraintNames.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF10.CustomDefaultConstraintNames;

internal class StudentDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=.\\SQLDEV;Database=EF10DefaultConstraints;Integrated Security=true;Trusted_Connection=True;Encrypt=false";
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .Property(p => p.BirthDay).HasDefaultValueSql("GETDATE()", "DF_Student_BirthDate");
        modelBuilder.UseNamedDefaultConstraints();
    }
}