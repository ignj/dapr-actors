using Dapr.Actors;

namespace shared;
public interface IActorSlave : IActor
{
    Task<int> DoWork(int i);
}