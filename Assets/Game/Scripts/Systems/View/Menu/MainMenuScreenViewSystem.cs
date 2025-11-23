using Game.Configs;
using Game.Input;
using Game.View.UI;
using UnityEngine;

namespace Game.Systems.View.Menu
{
public class MainMenuScreenViewSystem : ISystem
{
    private readonly Assets _assets;
    private readonly Canvas _canvas;
    private readonly PlayerInput _playerInput;
    private MainMenuScreenView _view;

    public MainMenuScreenViewSystem(Assets assets, Canvas canvas, PlayerInput playerInput)
    {
        _assets = assets;
        _canvas = canvas;
        _playerInput = playerInput;
    }
    
    public void Start()
    {
        _view = Object.Instantiate(_assets.MainMenuScreenView, _canvas.transform);
        _view.Init(_playerInput);
    }

    public void Update() { }

    public void Stop()
    {
        _view.Destroy();
        _view = null;
    }
}
}