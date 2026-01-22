using System.Text.Json;
using System.Text.Json.Nodes;

string json = """{ "Length": 1, "Length": -1 }""";
Console.WriteLine(JsonSerializer.Deserialize<Vector>(json)!.Length);

var options = new JsonSerializerOptions { AllowDuplicateProperties = false };
EatException(() => JsonSerializer.Deserialize<Vector>(json, options));
EatException(() => JsonSerializer.Deserialize<JsonObject>(json, options));
EatException(() => JsonSerializer.Deserialize<Dictionary<string, int>>(json, options));

var documentOptions = new JsonDocumentOptions { AllowDuplicateProperties = false };
EatException(() => JsonDocument.Parse(json, documentOptions));

static void EatException(Action action)
{
    try
    {
        action();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
    }
}

record Vector(int Length);