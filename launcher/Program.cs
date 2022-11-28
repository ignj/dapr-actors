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

app.Run();
