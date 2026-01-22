using System.Text.Json;
using System.Text.Json.Serialization;

// When you use source generators for JSON serialization, the generated context throws when cycles are serialized or deserialized.
// Now you can customize this behavior by specifying the ReferenceHandler in the JsonSourceGenerationOptionsAttribute.

var me = new Employee
{
    Name = "Johnny"
};
me.Manager = me;

var serialized1 = JsonSerializer.Serialize(me, new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve });
Console.WriteLine(serialized1);
var serialized2 = JsonSerializer.Serialize(me, EmployeeJsonSerializerContext.Default.Employee);
Console.WriteLine(serialized2);

Console.ReadKey();

[JsonSourceGenerationOptions(ReferenceHandler = JsonKnownReferenceHandler.Preserve)]
[JsonSerializable(typeof(Employee))]
internal partial class EmployeeJsonSerializerContext : JsonSerializerContext
{
}

class Employee
{
    public string Name { get; set; }
    public Employee Manager { get; set; }
}