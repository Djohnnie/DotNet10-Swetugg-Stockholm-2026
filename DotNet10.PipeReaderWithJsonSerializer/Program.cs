using System.IO.Pipelines;
using System.Text.Json;

// JsonSerializer.Deserialize now supports PipeReader, complementing the existing PipeWriter support.
// Previously, deserializing from a PipeReader required converting it to a Stream,
// but the new overloads eliminate that step by integrating PipeReader directly into the serializer.
// As a bonus, not having to convert from what you're already holding can yield some efficiency benefits.

var pipe = new Pipe();

// Producer writes to the pipe in chunks.
var producerTask = Task.Run(async () =>
{
    async static IAsyncEnumerable<Chunk> GenerateResponse()
    {
        yield return new Chunk("The quick brown fox", DateTime.Now);
        await Task.Delay(1000);
        yield return new Chunk(" jumps over", DateTime.Now);
        await Task.Delay(1000);
        yield return new Chunk(" the lazy dog.", DateTime.Now);
    }

    await JsonSerializer.SerializeAsync(pipe.Writer, GenerateResponse());
    await pipe.Writer.CompleteAsync();
});

// Consumer reads from the pipe and outputs to console.
var consumerTask = Task.Run(async () =>
{
    var thinkingString = "...";
    var clearThinkingString = new string("\b\b\b");
    var lastTimestamp = DateTime.MinValue;

    // Read response to end.
    Console.Write(thinkingString);

    await foreach (var chunk in JsonSerializer.DeserializeAsyncEnumerable<Chunk>(pipe.Reader))
    {
        Console.Write(clearThinkingString);
        Console.Write(chunk.Message);
        Console.Write(thinkingString);
        lastTimestamp = DateTime.Now;
    }

    Console.Write(clearThinkingString);
    Console.WriteLine($" Last message sent at {lastTimestamp}.");

    await pipe.Reader.CompleteAsync();
});

await producerTask;
await consumerTask;

record Chunk(string Message, DateTime Timestamp);