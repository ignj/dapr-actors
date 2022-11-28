using Dapr.Actors;
using Dapr.Actors.Client;
using Dapr.Actors.Runtime;
using shared;

namespace receiver;
public class ActorMaster : Actor, IActorMaster
{
    public ActorMaster(ActorHost host) : base(host) { }

    public async Task<int> OrchestrateWork(Guid id)
    {
        List<Task<int>> taskList = new();

        for (var i = 0; i < 10; i++)
        {
            // result += await ActorProxy.Create<IActorSlave>(ActorId.CreateRandom(), "ActorSlave").DoWork(i);

            var index = i;
            var task = new Task<int>(() => ActorProxy.Create<IActorSlave>(ActorId.CreateRandom(), "ActorSlave").DoWork(index).Result);

            task.Start();

            taskList.Add(task);
        }

        var results = await Task.WhenAll(taskList.ToArray());

        Logger.LogInformation("Result is {State}", results.Sum());

        return results.Sum();
    }
}