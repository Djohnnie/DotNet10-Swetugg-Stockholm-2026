using EF10.LeftJoinAndRightJoin;
using EF10.LeftJoinAndRightJoin.Entities;
using Microsoft.EntityFrameworkCore;

// LEFT JOIN is a common and useful operation when working with EF Core.
// In previous versions, implementing LEFT JOIN in LINQ was quite complicated,
// requiring SelectMany, GroupJoin and DefaultIfEmpty operations in a particular configuration.
// .NET 10 adds first-class LINQ support for LeftJoin method, making those queries much simpler to write.
// EF Core recognizes the new method, so it can be used in EF LINQ queries instead of the old construct.

using var dbContext = new MyDbContext();

if (!await dbContext.People.AnyAsync())
{
    List<Person> people =
    [
        new Person { Name = "Johnny" },
        new Person { Name = "Koen" },
        new Person { Name = "Marie" }
    ];

    dbContext.People.AddRange(people);
    await dbContext.SaveChangesAsync();
}

if (!await dbContext.Addresses.AnyAsync())
{
    List<Address> addresses =
    [
        new Address { PersonId = 1, City = "Mechelen" },
        new Address { PersonId = 2, City = "Kontich" },
        new Address { PersonId = 4, City = "Antwerpen" }
    ];

    dbContext.Addresses.AddRange(addresses);
    await dbContext.SaveChangesAsync();
}

var leftJoinResult = await dbContext.People.LeftJoin(dbContext.Addresses,
    person => person.Id,
    address => address.PersonId,
    (person, address) => new
    {
        person.Name,
        City = address.City ?? "Unknown"
    }).ToListAsync();

foreach (var item in leftJoinResult)
{
    Console.WriteLine($"{item.Name} lives in {item.City}");
}

Console.WriteLine();

var rightJoinResult = await dbContext.People.RightJoin(dbContext.Addresses,
    person => person.Id,
    address => address.PersonId,
    (person, address) => new
    {
        Name = person.Name ?? "Unknown",
        address.City
    }).ToListAsync();

foreach (var item in rightJoinResult)
{
    Console.WriteLine($"{item.Name} lives in {item.City}");
}

Console.ReadKey();