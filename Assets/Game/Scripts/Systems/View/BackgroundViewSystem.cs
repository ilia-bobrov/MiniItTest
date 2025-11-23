using Game.Configs;
using Game.GlobalStates;
using Game.Models;
using Game.View;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Game.Systems.View
{
public class BackgroundViewSystem : ISystem
{
    private readonly Model _model;
    private readonly Assets _assets;
    private readonly Config _config;
    private readonly Camera _camera;
    private BackgroundView _view;

    public BackgroundViewSystem(Model model, Assets assets, Config config, Camera camera)
    {
        _model = model;
        _assets = assets;
        _config = config;
        _camera = camera;
    }
    
    public void Start()
    {
        _view = Object.Instantiate(_assets.BackgroundView);
        var cameraSize = _camera.orthographicSize * 2;
        _view.SetSize(cameraSize * _camera.aspect + 1f, cameraSize + 1f);
        
        switch (_model.GlobalState)
        {
            case EGlobalState.MainMenu:
                Set(_config.Background.MainMenuMainColor,
                    _config.Background.MainMenuSpriteColor,
                    _assets.BackgroundSprites.MainMenuSprite);
                break;
            case EGlobalState.Match3:
                Set(_config.Background.Match3MainColor, 
                    _config.Background.Match3SpriteColor,
                    _assets.BackgroundSprites.Match3Sprite);
                break;
            case EGlobalState.Merge:
                Set(_config.Background.MergeMainColor, 
                    _config.Background.MergeSpriteColor,
                    _assets.BackgroundSprites.MergeSprite);
                break;
            case EGlobalState.Arkanoid:
                Set(_config.Background.ArkanoidMainColor, 
                    _config.Background.ArkanoidSpriteColor,
                    _assets.BackgroundSprites.ArkanoidSprite);
                break;
            default:
                Set(_config.Background.MainMenuMainColor, 
                    _config.Background.MainMenuSpriteColor,
                    _assets.BackgroundSprites.MainMenuSprite);
                break;
        }
    }

    private Vector2 GetVelocity()
    {
        var x = Random.Range(_config.Background.MinVelocity.x, _config.Background.MaxVelocity.x);
        x *= Random.value > 0.5f ? -1 : 1;
        var y = Random.Range(_config.Background.MinVelocity.y, _config.Background.MaxVelocity.y);
        y *= Random.value > 0.5f ? -1 : 1;
        return new Vector2(x, y);
    }

    private void Set(Color mainColor, Color spriteColor, Texture texture)
    {
        _view.SetData(mainColor, spriteColor, texture, GetVelocity());
    }

    public void Update() { }

    public void Stop()
    {
        _view.Destroy();
        _view = null;
    }
}
}