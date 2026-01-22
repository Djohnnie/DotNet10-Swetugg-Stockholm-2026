using EF9.NonExpressionExecuteUpdateAsync;
using EF9.NonExpressionExecuteUpdateAsync.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

// The ExecuteUpdateAsync can be used to express arbitrary update operations in the database.
// In previous versions, the changes to be performed on the database rows were provided via
// an expression tree parameter; this made it quite difficult to build those changes dynamically.
// Manually creating expression trees is complicated and error-prone,
// and made this common scenario much more difficult than it should have been.
// Starting with EF 10, you can now write the following:

using var dbContext = new StudentDbContext();

for (var i = 0; i < 2; i++)
{
    //await dbContext.Students.ExecuteUpdateAsync(s =>
    //{
    //    s.SetProperty(b => b.BirthDay, new DateOnly(2000, 1, 1));
    //    if (i == 1)
    //    {
    //        s.SetProperty(b => b.Name, "Hooyberghs");
    //    }
    //});

    // Base setters: Update the BirthDay only
    Expression<Func<SetPropertyCalls<Student>, SetPropertyCalls<Student>>> setters =
        s => s.SetProperty(x => x.BirthDay, new DateOnly(2000, 1, 1));

    // Conditionally add SetProperty(b => b.Name, "Hooyberghs") to setters, based on the value of 'i'.
    if (i == 1)
    {
        var studentParameter = Expression.Parameter(typeof(Student), "x");

        setters = Expression.Lambda<Func<SetPropertyCalls<Student>, SetPropertyCalls<Student>>>(
            Expression.Call(
                instance: setters.Body,
                methodName: nameof(SetPropertyCalls<Student>.SetProperty),
                typeArguments: [typeof(string)],
                arguments:
                [
                    Expression.Lambda<Func<Student, string>>(Expression.Property(studentParameter, nameof(Student.Name)), studentParameter),
                    Expression.Constant("Hooyberghs")
                ]),
            setters.Parameters);
    }

    await dbContext.Students.ExecuteUpdateAsync(setters);
}

Console.ReadKey();