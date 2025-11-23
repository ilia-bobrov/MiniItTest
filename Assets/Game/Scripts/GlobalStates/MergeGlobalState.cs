using Game.Configs;
using Game.Ev;
using Game.Input;
using Game.Models;
using Game.Systems;
using Game.Systems.Logic.Merge;
using Game.Systems.View;
using Game.Systems.View.Merge;
using UnityEngine;

namespace Game.GlobalStates
{
public sealed class MergeGlobalState : IGlobalState
{
    private readonly ISystem[] _systems;

    public MergeGlobalState(MergeModel mergeModel, MergeViewModel mergeViewModel, MergeConfig mergeConfig, Assets assets,
        PlayerInput playerInput, Events events, Camera camera, Canvas canvas, BackgroundViewSystem backgroundViewSystem)
    {
        _systems = new ISystem[]
        {
            new InputSystem(playerInput, events, mergeViewModel),
            new GridSystem(mergeConfig, mergeModel),
            new SpawnSystem(mergeConfig, mergeModel, events),
            new MergeSystem(mergeConfig, mergeModel, events),
            new PointsSystem(mergeConfig, mergeModel, events),
            
            new GridViewSystem(mergeConfig, mergeModel, mergeViewModel, assets, camera),
            new ItemsViewSpawnSystem(mergeConfig, assets, mergeModel, mergeViewModel, events, playerInput),
            new ItemsViewDragSystem(mergeViewModel, events, mergeConfig, camera, playerInput),
            new ItemsViewMergeSystem(mergeViewModel, events, assets),
            new MergeScreenViewSystem(mergeViewModel, events, assets, canvas, playerInput, mergeModel),
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