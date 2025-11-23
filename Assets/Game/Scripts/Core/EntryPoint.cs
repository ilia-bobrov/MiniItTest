using Game.Configs;
using Game.Input;
using UnityEngine;

namespace Game.Core
{
public sealed class UnityEntry : MonoBehaviour
{
    [SerializeField] private Config _config;
    [SerializeField] private Assets _assets;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Camera _camera;
    
    private Game _game;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        
        var inputActions = new InputActions();
        inputActions.Player.Enable();
        
        _game = new Game(inputActions, _assets, _config, _canvas, _camera);
        _game.Start();
    }

    private void Update()
    { 
        _game.Update();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            _game.Pause();
        }
        else
        {
            _game.Unpause();
        }
    }
    
    private void OnApplicationQuit()
    {
        _game.Stop();
    }
}
}