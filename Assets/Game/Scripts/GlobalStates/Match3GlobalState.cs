using Game.Systems;

namespace Game.GlobalStates
{
public sealed class Match3GlobalState : IGlobalState
{
    private readonly ISystem[] _systems;

    public Match3GlobalState()
    {
        _systems = new ISystem[]
        {
            
        };
    }

    public void Enter()
    {
        foreach (var system in _systems)
        {
            system.Start();
        }
    }
    
    public void Update()
    {
        foreach (var system in _systems)
        {
            system.Update();
        }
    }

    public void Exit()
    {
        foreach (var system in _systems)
        {
            system.Stop();
        }
    }
}
}