using EF10.RedactInlineConstants;
using EF10.RedactInlineConstants.Entities;
using Microsoft.EntityFrameworkCore;

// When logging executed SQL, EF does not log parameter values by default,
// since these may contain sensitive or personally-identifiable information (PII);
// EnableSensitiveDataLogging() can be used to enable logging parameter values
// in diagnostic or debugging scenarios (see documentation).
// However, EF sometimes inlines parameters into the SQL statement rather than sending them separately;
// in those scenarios, the potentially sensitive values were logged. EF10 no longer does this,
// redacting such inlined parameters by default and replacing them with a question mark character (?).

using var dbContext = new StudentDbContext();

if (!await dbContext.Students.AnyAsync())
{
    dbContext.Students.AddRange(
        new Student { Name = "Doe", FirstName = "John", BirthDay = new DateOnly(2000, 1, 1) },
        new Student { Name = "Smith", FirstName = "Jane", BirthDay = new DateOnly(1999, 5, 15) },
        new Student { Name = "Brown", FirstName = "Sam", BirthDay = new DateOnly(2001, 3, 22) },
        new Student { Name = "Johnson", FirstName = "Emily", BirthDay = new DateOnly(2002, 7, 30) },
        new Student { Name = "Davis", FirstName = "Michael", BirthDay = new DateOnly(1998, 11, 5) },
        new Student { Name = "Wilson", FirstName = "Sarah", BirthDay = new DateOnly(2000, 9, 12) },
        new Student { Name = "Miller", FirstName = "David", BirthDay = new DateOnly(1999, 12, 3) },
        new Student { Name = "Garcia", FirstName = "Maria", BirthDay = new DateOnly(2001, 6, 18) },
        new Student { Name = "Martinez", FirstName = "Carlos", BirthDay = new DateOnly(2000, 4, 25) },
        new Student { Name = "Anderson", FirstName = "Lisa", BirthDay = new DateOnly(1998, 8, 7) },
        new Student { Name = "Taylor", FirstName = "Robert", BirthDay = new DateOnly(2002, 2, 14) },
        new Student { Name = "Thomas", FirstName = "Jennifer", BirthDay = new DateOnly(1999, 10, 21) },
        new Student { Name = "Jackson", FirstName = "Christopher", BirthDay = new DateOnly(2001, 1, 9) },
        new Student { Name = "White", FirstName = "Amanda", BirthDay = new DateOnly(2000, 11, 28) },
        new Student { Name = "Harris", FirstName = "Matthew", BirthDay = new DateOnly(1998, 3, 16) },
        new Student { Name = "Martin", FirstName = "Ashley", BirthDay = new DateOnly(2002, 5, 4) },
        new Student { Name = "Thompson", FirstName = "Daniel", BirthDay = new DateOnly(1999, 7, 11) },
        new Student { Name = "Lee", FirstName = "Jessica", BirthDay = new DateOnly(2001, 9, 23) },
        new Student { Name = "Clark", FirstName = "Joshua", BirthDay = new DateOnly(2000, 12, 1) },
        new Student { Name = "Robinson", FirstName = "Michelle", BirthDay = new DateOnly(1998, 4, 19) }
    );
    await dbContext.SaveChangesAsync();
}

int[] ids1 = [1, 2, 3, 4, 5, 6, 7, 8];
var results1 = await dbContext.Students.Where(x => ids1.Contains(x.Id)).ToListAsync();
Console.WriteLine($"Found {results1.Count} students.");
Console.WriteLine();

int[] ids2 = [1, 2];
var results2 = await dbContext.Students.Where(x => ids2.Contains(x.Id)).ToListAsync();
Console.WriteLine($"Found {results2.Count} students.");
Console.WriteLine();

int[] ids3 = [1, 2, 3, 4];
var results3 = await dbContext.Students.Where(x => ids3.Contains(x.Id)).ToListAsync();
Console.WriteLine($"Found {results3.Count} students.");
Console.WriteLine();

int[] ids4 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11];
var results4 = await dbContext.Students.Where(x => ids4.Contains(x.Id)).ToListAsync();
Console.WriteLine($"Found {results4.Count} students.");
Console.WriteLine();

Console.ReadKey();