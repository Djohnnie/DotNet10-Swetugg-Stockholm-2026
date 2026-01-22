using EF10.ComplexTypesImprovements;
using EF10.ComplexTypesImprovements.Entities;
using Microsoft.EntityFrameworkCore;

// Complex types are used to model types which are contained within your entity types
// and have no identity of their own; while entity types are (usually) mapped to a database table,
// complex types can be mapped to columns in their container table ("table splitting"),
// or to a single JSON column. Complex types introduce document modeling techniques,
// which can bring substantial performance benefits as traditional JOINs are avoided,
// and can make your database modeling much simpler and more natural.

using var dbContext = new ShopDbContext();

if (!await dbContext.Customers.AnyAsync())
{
    var address = new Address
    {
        Street = "Stationstraat 1",
        City = "Mechelen",
        ZipCode = "2800"
    };

    var businessInfo = new BusinessInfo
    {
        CompanyName = "Involved NV",
        Country = "Belgium",
        TaxId = "BE0544984305"
    };

    dbContext.Customers.Add(new Customer
    {
        Name = "John Doe",
        BusinessInfo = businessInfo,
        ShippingAddress = address
    });

    dbContext.Customers.Add(new Customer
    {
        Name = "Jane Smith",
        BusinessInfo = businessInfo,
        BillingAddress = address,
        ShippingAddress = address
    });

    await dbContext.SaveChangesAsync();
}

Console.ReadKey();