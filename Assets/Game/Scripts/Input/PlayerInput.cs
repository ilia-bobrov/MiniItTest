using UnityEngine;

namespace Game.Input
{
public sealed class PlayerInput
{
    public readonly MainMenuInput MainMenu = new();
    public readonly MergeInput MergeInput = new();
    
    public Vector2 PointerScreenPosition;
    
    private readonly InputActions _inputActions;
    
    public PlayerInput(InputActions inputActions)
    {
        _inputActions = inputActions;
    }

    public void Update()
    {
        PointerScreenPosition = _inputActions.Player.Pointer.ReadValue<Vector2>();
    }

    public void Reset()
    {
        MainMenu.Reset();
        MergeInput.Reset();
    }
}
}