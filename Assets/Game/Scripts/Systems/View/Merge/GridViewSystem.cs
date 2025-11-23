using Game.Configs;
using Game.Models;
using Game.View.Merge;
using UnityEngine;

namespace Game.Systems.View.Merge
{
public class GridViewSystem : ISystem
{
    private readonly MergeConfig _config;
    private readonly MergeModel _model;
    private readonly MergeViewModel _viewModel;
    private readonly Assets _assets;
    private readonly Camera _camera;

    public GridViewSystem(MergeConfig config, MergeModel model, MergeViewModel viewModel, Assets assets, Camera camera)
    {
        _config = config;
        _model = model;
        _viewModel = viewModel;
        _assets = assets;
        _camera = camera;
    }
    
    public void Start()
    {
        _viewModel.GridView = Object.Instantiate(_assets.GridView);
        
        var maxHeight = _camera.orthographicSize * 2;
        var maxWidth = maxHeight * _camera.aspect;
        maxHeight -= _config.GapFromScreenEdge * 2;
        maxWidth -= _config.GapFromScreenEdge * 2;

        var gridSize = _model.GridSize;
        var desiredWidth = _config.CellSize * gridSize.x + _config.BorderThickness * 2;
        var desiredHeight = _config.CellSize * gridSize.y + _config.BorderThickness * 2;
        float widthMult = desiredWidth > maxWidth ? maxWidth / desiredWidth : 1;
        float heightMult = desiredHeight > maxHeight  ? maxHeight / desiredHeight : 1;
        var containerSizeMult = widthMult > heightMult ? heightMult : widthMult;

        _viewModel.GridView.Init(containerSizeMult, gridSize.x, gridSize.y, desiredWidth, desiredHeight,
            _config.CellSize, _config.BorderThickness);
    }

    public void Update() { }

    public void Stop()
    {
        _viewModel.GridView.Destroy();
        _viewModel.GridView = null;
    }
}
}