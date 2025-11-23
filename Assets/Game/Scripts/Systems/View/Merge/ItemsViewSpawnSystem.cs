using System.Collections.Generic;
using Game.Configs;
using Game.Ev;
using Game.Input;
using Game.Models;
using Game.Utils;
using Game.View.Merge;
using UnityEngine;

namespace Game.Systems.View.Merge
{
public class ItemsViewSpawnSystem : ISystem
{
    private readonly MergeConfig _config;
    private readonly Assets _assets;
    private readonly MergeModel _model;
    private readonly MergeViewModel _viewModel;
    private readonly Events _events;
    private readonly PlayerInput _playerInput;

    public ItemsViewSpawnSystem(MergeConfig config, Assets assets, MergeModel model, MergeViewModel viewModel,
        Events events, PlayerInput playerInput)
    {
        _config = config;
        _assets = assets;
        _model = model;
        _viewModel = viewModel;
        _events = events;
        _playerInput = playerInput;
    }

    public void Start()
    {
        _viewModel.InactiveItems = new Dictionary<Index2, ItemView>(_model.GridTotalSize);
        _viewModel.ActiveItems = new Dictionary<Index2, ItemView>(_model.GridTotalSize);

        for (int i = 0; i < _model.GridSize.y; i++)
        {
            for (int j = 0; j < _model.GridSize.x; j++)
            {
                var itemView = Object.Instantiate(_assets.ItemView, _viewModel.GridView.transform);
                itemView.Init(new Index2(j, i), _playerInput);
                itemView.SetActive(false);
                itemView.SetSize(_config.ItemSize);
                itemView.SetLayerOrder(_config.ItemLayerOrder);
                _viewModel.InactiveItems.Add(itemView.Index, itemView);
            }
        }
    }

    public void Update()
    {
        var ev = _events.MergeEvents.Spawn;
        if (ev.IsSpawned)
        {
            var itemView = _viewModel.InactiveItems[ev.Cell];
            _viewModel.InactiveItems.Remove(ev.Cell);
            itemView.SetActive(true);
            var level = _model.Grid[ev.Cell.x, ev.Cell.y].Level;
            itemView.SetSprite(_assets.ItemSprites[level - 1]);
            var posX = _model.GridSize.x * _config.CellSize / 2 * -1 + _config.CellSize / 2 + _config.CellSize * ev.Cell.x;
            var posY = _model.GridSize.y * _config.CellSize / 2 * -1 + _config.CellSize / 2 + _config.CellSize * ev.Cell.y;
            itemView.SetLocalPosition(new Vector2(posX, posY));
            _viewModel.ActiveItems.Add(itemView.Index, itemView);
        }
    }

    public void Stop()
    {
        foreach (var itemView in _viewModel.InactiveItems.Values)
        {
            itemView.Destroy();
        }
        
        foreach (var itemView in _viewModel.ActiveItems.Values)
        {
            itemView.Destroy();
        }
        
        _viewModel.InactiveItems = null;
        _viewModel.ActiveItems = null;
    }
}
}