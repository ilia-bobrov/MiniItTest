using Game.Configs;
using Game.Ev;
using Game.Input;
using Game.Models;
using UnityEngine;

namespace Game.Systems.View.Merge
{
public class MergeScreenViewSystem : ISystem
{
    private readonly MergeViewModel _viewModel;
    private readonly Events _events;
    private readonly Assets _assets;
    private readonly Canvas _canvas;
    private readonly PlayerInput _playerInput;
    private readonly MergeModel _model;

    public MergeScreenViewSystem(MergeViewModel viewModel, Events events, Assets assets, Canvas canvas, PlayerInput playerInput, MergeModel model)
    {
        _viewModel = viewModel;
        _events = events;
        _assets = assets;
        _canvas = canvas;
        _playerInput = playerInput;
        _model = model;
    }

    public void Start()
    {
        _viewModel.MergeScreenView = Object.Instantiate(_assets.MergeScreenView, _canvas.transform);
        _viewModel.MergeScreenView.Init(_playerInput);
        _viewModel.MergeScreenView.SetScore(0);
        _viewModel.MergeScreenView.SetRecord(_model.RecordScore);
    }

    public void Update()
    {
        var ev = _events.MergeEvents.Merge;
        if (!ev.IsMerged)
            return;

        _viewModel.MergeScreenView.SetScore(_model.CurrentScore);
    }

    public void Stop()
    {
        _viewModel.MergeScreenView.Destroy();
        _viewModel.MergeScreenView = null;
    }
}
}