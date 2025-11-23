using Game.Configs;
using Game.Ev;
using Game.Input;
using Game.Systems;
using Game.Systems.Logic.Menu;
using Game.Systems.View;
using Game.Systems.View.Menu;
using UnityEngine;

namespace Game.GlobalStates
{
public sealed class MainMenuGlobalState : IGlobalState
{
    private readonly ISystem[] _systems;

    public MainMenuGlobalState(Assets assets, Canvas canvas, PlayerInput playerInput, Events events, BackgroundViewSystem backgroundViewSystem)
    {
        _systems = new ISystem[]
        {
            new InputSystem(playerInput, events),
            
            new MainMenuScreenViewSystem(assets, canvas, playerInput),
            backgroundViewSystem
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