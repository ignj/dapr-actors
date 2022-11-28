using Dapr.Actors.Runtime;
using shared;

namespace receiver;
public class ActorSlave : Actor, IActorSlave
{
    public ActorSlave(ActorHost host) : base(host) { }

    public async Task<int> DoWork(int i)
    {
        Logger.LogInformation("Running Actor {i}", i);

        // await StateManager.AddOrUpdateStateAsync(
        //     "MasterState",
        //     1,
        //     (key, currentState) => currentState + 1
        // );

        var rnd = new Random();

        await Task.Delay(rnd.Next(1000, 10000));

        Logger.LogInformation("Closing Actor {i}", i);

        return rnd.Next(0, 100);
    }
}