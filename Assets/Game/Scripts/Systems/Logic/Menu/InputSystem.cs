using Game.Core;
using Game.Ev;
using Game.GlobalStates;
using Game.Input;

namespace Game.Systems.Logic.Menu
{
public class InputSystem : ISystem
{
    private readonly PlayerInput _playerInput;
    private readonly Events _events;

    public InputSystem(PlayerInput playerInput, Events events)
    {
        _playerInput = playerInput;
        _events = events;
    }
    
    public void Start() { }

    public void Update()
    {
        if (_playerInput.MainMenu.IsExit)
        {
            _events.IsExitApp = true;
        }
        else if (_playerInput.MainMenu.IsArkanoid)
        {
            
        }
        else if (_playerInput.MainMenu.IsMatch3)
        {
            
        }
        else if (_playerInput.MainMenu.IsMerge)
        {
            _events.ChangeGlobalState = new Events.ChangeGlobalStateEvent
            {
                IsChange = true,
                State = EGlobalState.Merge
            };
        }
    }

    public void Stop() { }
}
}