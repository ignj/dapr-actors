using receiver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddActors(options =>
{
    options.Actors.RegisterActor<ActorMaster>();
    options.Actors.RegisterActor<ActorSlave>();
});

var app = builder.Build();

app.MapControllers();
app.MapActorsHandlers();

app.Run();
