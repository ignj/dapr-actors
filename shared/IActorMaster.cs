using Dapr.Actors;

namespace shared;
public interface IActorMaster : IActor
{
    Task<int> OrchestrateWork(Guid id);

    Task CountNumbers();

    Task<int> GetCounter();
}
