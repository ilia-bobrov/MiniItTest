using System.Collections.Generic;
using Game.Configs;
using Game.Ev;
using Game.GlobalStates;
using Game.Input;
using Game.Models;
using Game.Systems.View;
using UnityEngine;

namespace Game.Core
{
public sealed class Game
{
    private readonly Model _model = new();
    private readonly ViewModel _viewModel = new();
    private readonly Events _events = new();
    private readonly Dictionary<EGlobalState, IGlobalState> _states;
    private readonly PlayerInput _playerInput;
    private IGlobalState _currentState;

    public Game(InputActions inputActions, Assets assets, Config config, Canvas canvas, Camera camera)
    {
        _playerInput = new PlayerInput(inputActions);
        _currentState = new DummyGlobalState();
        var backgroundViewSystem = new BackgroundViewSystem(_model, assets, config, camera);
        _states = new Dictionary<EGlobalState, IGlobalState>
        {
            { EGlobalState.Dummy, _currentState },
            { EGlobalState.MainMenu, new MainMenuGlobalState(assets, canvas, _playerInput, _events, backgroundViewSystem) },
            { EGlobalState.Match3, new Match3GlobalState() },
            { EGlobalState.Merge, new MergeGlobalState(_model.MergeModel, _viewModel.MergeModel, config.MergeConfig, 
                assets, _playerInput, _events, camera, canvas, backgroundViewSystem) },
            { EGlobalState.Arkanoid, new ArkanoidGlobalState() },
        };
    }

    public void Start()
    {
        SwitchState(EGlobalState.MainMenu);
    }

    public void Update()
    {
        _playerInput.Update();
        _currentState.Update();
        if(CheckExit())
            return;
        
        _playerInput.Reset();
        
        var changeStateEv = _events.ChangeGlobalState;
        while(changeStateEv.IsChange && _model.GlobalState != changeStateEv.State)
        {
            SwitchState(changeStateEv.State);
            _events.Reset();
            _currentState.Update();
            if(CheckExit())
                return;
            changeStateEv = _events.ChangeGlobalState;
        }
        
        _events.Reset();
    }

    private void SwitchState(EGlobalState state)
    {
        _currentState.Exit();
        _model.GlobalState = state;
        _currentState = _states[state];
        _currentState.Enter();
    }

    private bool CheckExit()
    {
        if (_events.IsExitApp)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
            return true;
        }
        
        return false;
    }

    public void Pause() { }

    public void Unpause() { }

    public void Stop()
    { 
        _currentState.Exit();
    }
}
}
