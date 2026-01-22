using EF10.JsonTypeSupportForSqlServer2025;
using EF10.JsonTypeSupportForSqlServer2025.Entities;
using Microsoft.EntityFrameworkCore;

// EF 10 also fully supports the new json data type, also available
// on Azure SQL Database and on SQL Server 2025.
// While SQL Server has included JSON functionality for several versions,
// the data itself was stored in plain textual columns in the database;
// the new data type provides significant efficiency improvements and a safer way
// to store and interact with JSON.

using var dbContext = new BlogDbContext();
if (!await dbContext.Blogs.AnyAsync())
{
    dbContext.Blogs.Add(new Blog
    {
        Tags = ["Entity Framework", "EF10", "SQL", "SQL Server"],
        Details = new BlogDetails
        {
            Description = "EF 10 introduces first-class JSON type support for SQL Server 2025.",
            Viewers = 42
        }
    });

    await dbContext.SaveChangesAsync();
}

var results = await dbContext.Blogs.Where(b => b.Tags.Contains("EF10") && b.Details.Viewers > 10).ToListAsync();

foreach (var result in results)
{
    Console.WriteLine(result.Details.Description);
}

Console.ReadKey();