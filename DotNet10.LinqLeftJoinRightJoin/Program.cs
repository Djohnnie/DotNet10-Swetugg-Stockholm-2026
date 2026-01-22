// .NET 10 adds first-class LINQ support for LeftJoin and RightJoin operations.

List<Person> people =
[
    new Person { Id = 1, Name = "Johnny" },
    new Person { Id = 2, Name = "Koen" },
    new Person { Id = 3, Name = "Marie" }
];

List<Address> addresses =
[
    new Address { PersonId = 1, City = "Mechelen" },
    new Address { PersonId = 2, City = "Kontich" },
    new Address { PersonId = 4, City = "Antwerpen" }
];

var leftJoinResult = people.LeftJoin(addresses,
    person => person.Id,
    address => address.PersonId,
    (person, address) => new
    {
        person.Name,
        City = address?.City ?? "Unknown"
    });

foreach (var item in leftJoinResult)
{
    Console.WriteLine($"{item.Name} lives in {item.City}");
}

Console.WriteLine();

var rightJoinResult = people.RightJoin(addresses,
    person => person.Id,
    address => address.PersonId,
    (person, address) => new
    {
        Name = person?.Name ?? "Unknown",
        address.City
    });

foreach (var item in rightJoinResult)
{
    Console.WriteLine($"{item.Name} lives in {item.City}");
}

Console.ReadKey();

class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Address
{
    public int PersonId { get; set; }
    public string City { get; set; }
}