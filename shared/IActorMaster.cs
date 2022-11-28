using Dapr.Actors;

namespace shared;
public interface IActorMaster : IActor
{
    Task<int> OrchestrateWork(Guid id);
}
