// In web apps, JSON Patch is commonly used in a PATCH operation to perform partial updates of a resource.
// Rather than sending the entire resource for an update,
// clients can send a JSON Patch document containing only the changes.
// Patching reduces payload size and improves efficiency.
// This release introduces a new implementation of Microsoft.AspNetCore.JsonPatch
// based on System.Text.Json serialization. This feature:
// Aligns with modern .NET practices by leveraging the System.Text.Json library, which is optimized for .NET.
// Provides improved performance and reduced memory usage compared to
// the legacy Newtonsoft.Json-based implementation.

using Microsoft.AspNetCore.JsonPatch.SystemTextJson;
using System.Text.Json;
using System.Text.Json.Serialization;

var person = new Person
{
    FirstName = "Johnny",
    LastName = "Hooyberghs",
    Email = "johnny@hooyberghs.be",
    PhoneNumbers = [new() { Number = "+32 498 76 54 32", Type = PhoneNumberType.Mobile }],
    Address = new Address
    {
        Street = "Stationstraat 1",
        City = "Mechelen"
    }
};

var jsonPatch = """
[
  { "op": "replace", "path": "/FirstName", "value": "Jane" },
  { "op": "remove", "path": "/Email"},
  { "op": "add", "path": "/Address/ZipCode", "value": "2800" },
  {
    "op": "add",
    "path": "/PhoneNumbers/-",
    "value": { "Number": "+32 3 844 33 77", "Type": "Work" }
  }
]
""";

var patchDoc = JsonSerializer.Deserialize<JsonPatchDocument<Person>>(jsonPatch);
patchDoc!.ApplyTo(person);
Console.WriteLine(JsonSerializer.Serialize(person));

Console.ReadKey();

class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public List<PhoneNumber> PhoneNumbers { get; set; }
    public Address Address { get; set; }
}

class PhoneNumber
{
    public string Number { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PhoneNumberType Type { get; set; }
}

enum PhoneNumberType
{
    Mobile,
    Home,
    Work
}

class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
}