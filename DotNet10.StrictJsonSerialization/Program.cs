using System.Text.Json;

string json1 = """{ "Length": 1, "Length": -1 }""";
string json2 = """{ "Length": 1, "Unmapped": 42 }""";
string json3 = """{ "length": 1 }""";
string json4 = """{ "Text": null }""";
string json5 = """{ "Text": null }""";

Console.WriteLine(JsonSerializer.Deserialize<Vector1>(json1, JsonSerializerOptions.Default)!.Length);
Console.WriteLine(JsonSerializer.Deserialize<Vector1>(json2, JsonSerializerOptions.Default)!.Length);
Console.WriteLine(JsonSerializer.Deserialize<Vector1>(json3, JsonSerializerOptions.Default)!.Length);
Console.WriteLine(JsonSerializer.Deserialize<Vector1>(json4, JsonSerializerOptions.Default)!.Length);
Console.WriteLine(JsonSerializer.Deserialize<Vector2>(json5, JsonSerializerOptions.Default)!.Length);

// Disables the JsonSerializerOptions.AllowDuplicateProperties setting.
EatException(() => JsonSerializer.Deserialize<Vector1>(json1, JsonSerializerOptions.Strict));

// Applies the JsonUnmappedMemberHandling.Disallow policy.
EatException(() => JsonSerializer.Deserialize<Vector1>(json2, JsonSerializerOptions.Strict));

// Preserves case sensitive property binding.
EatException(() => JsonSerializer.Deserialize<Vector1>(json3, JsonSerializerOptions.Strict));

// Enables the JsonSerializerOptions.RespectNullableAnnotations setting.
EatException(() => JsonSerializer.Deserialize<Vector1>(json4, JsonSerializerOptions.Strict));

// Enables the JsonSerializerOptions.RespectRequiredConstructorParameters setting.
EatException(() => JsonSerializer.Deserialize<Vector2>(json5, JsonSerializerOptions.Strict));

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

class Vector1
{
    public int Length { get; set; }
    public string Text { get; set; } = "default";
}

record Vector2(int Length, string Text = "default");