using System.Runtime.CompilerServices;

// ASP.NET Core now supports returning a ServerSentEvents result using the TypedResults.ServerSentEvents API.
// This feature is supported in both Minimal APIs and controller-based apps.
// Server - Sent Events is a server push technology that allows a server to send a stream of event messages
// to a client over a single HTTP connection.
// In .NET the event messages are represented as SseItem<T> objects, which may contain an event type,
// an ID, and a data payload of type T.
// The TypedResults class has a new static method called ServerSentEvents that can be used to return
// a ServerSentEvents result. The first parameter to this method is an IAsyncEnumerable<SseItem<T>>
// that represents the stream of event messages to be sent to the client.

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/health", (CancellationToken cancellationToken) =>
{
    var realtimeHeartRate = GetHeartRate(cancellationToken);
    return TypedResults.ServerSentEvents(realtimeHeartRate, eventType: "heartRate");
});

app.Run();

async IAsyncEnumerable<HeartRateRecord> GetHeartRate([EnumeratorCancellation] CancellationToken cancellationToken)
{
    while (!cancellationToken.IsCancellationRequested)
    {
        var heartRate = Random.Shared.Next(50, 120);
        yield return new HeartRateRecord(heartRate);
        await Task.Delay(1000, cancellationToken);
    }
}

internal record HeartRateRecord(int HeartRate);