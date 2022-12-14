using Dapr.Actors;
using Dapr.Actors.Client;
using shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/trigger", async () =>
{
    var result = await ActorProxy.Create<IActorMaster>(ActorId.CreateRandom(), "ActorMaster").OrchestrateWork(Guid.NewGuid());

    Console.WriteLine($"Result was {result}");
});

app.MapGet("/trigger-count", async () =>
{
    await ActorProxy.Create<IActorMaster>(new ActorId("1"), "ActorMaster").CountNumbers();

    Console.WriteLine($"Count finished");
});

app.MapGet("/get-count", async () =>
{
    var result = await ActorProxy.Create<IActorMaster>(new ActorId("1"), "ActorMaster").GetCounter();

    Console.WriteLine($"Result was {result}");
});

app.Run();
