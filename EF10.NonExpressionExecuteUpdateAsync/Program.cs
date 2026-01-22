using EF10.NonExpressionExecuteUpdateAsync;
using Microsoft.EntityFrameworkCore;

// The ExecuteUpdateAsync can be used to express arbitrary update operations in the database.
// In previous versions, the changes to be performed on the database rows were provided via
// an expression tree parameter; this made it quite difficult to build those changes dynamically.
// Manually creating expression trees is complicated and error-prone,
// and made this common scenario much more difficult than it should have been.
// Starting with EF 10, you can now write the following:

using var dbContext = new StudentDbContext();

for (var i = 0; i < 2; i++)
{
    await dbContext.Students.ExecuteUpdateAsync(s =>
    {
        s.SetProperty(b => b.BirthDay, new DateOnly(2000, 1, 1));
        if (i == 1)
        {
            s.SetProperty(b => b.Name, "Hooyberghs");
        }
    });
}

Console.ReadKey();