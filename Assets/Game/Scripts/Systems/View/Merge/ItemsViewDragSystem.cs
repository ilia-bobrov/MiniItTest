using Game.Configs;
using Game.Ev;
using Game.Models;
using UnityEngine;
using PlayerInput = Game.Input.PlayerInput;

namespace Game.Systems.View.Merge
{
public class ItemsViewDragSystem : ISystem
{
    private readonly MergeViewModel _mergeViewModel;
    private readonly Events _events;
    private readonly MergeConfig _mergeConfig;
    private readonly Camera _camera;
    private readonly PlayerInput _playerInput;

    public ItemsViewDragSystem(MergeViewModel mergeViewModel, Events events, MergeConfig mergeConfig, Camera camera, 
        PlayerInput playerInput)
    {
        _mergeViewModel = mergeViewModel;
        _events = events;
        _mergeConfig = mergeConfig;
        _camera = camera;
        _playerInput = playerInput;
    }

    public void Start() { }

    public void Update()
    {
        var dragStartEv = _events.MergeEvents.DragStart;
        if (dragStartEv.IsStart && !_mergeViewModel.IsDrag)
        {
            var itemView = _mergeViewModel.ActiveItems[dragStartEv.ItemIndex];
            itemView.SetSize(_mergeConfig.ItemDragSize);
            itemView.SetLayerOrder(_mergeConfig.ItemDragLayerOrder);
            _mergeViewModel.DragItem = itemView;
            _mergeViewModel.DragOriginItemPosition = itemView.GetPosition();
        }
        
        if (_mergeViewModel.IsDrag)
        {
            var dragStopEv = _events.MergeEvents.DragStop;
            if (dragStopEv.IsStop)
            {
                var itemView = _mergeViewModel.DragItem;
                itemView.SetSize(_mergeConfig.ItemSize);
                itemView.SetLayerOrder(_mergeConfig.ItemLayerOrder);
                itemView.SetPosition(_mergeViewModel.DragOriginItemPosition);
                _mergeViewModel.DragItem = null;
            }
            else
            {
                var worldPos = _camera.ScreenToWorldPoint(_playerInput.PointerScreenPosition);
                _mergeViewModel.DragItem.SetPosition(worldPos);
            }
        }
    }

    public void Stop()
    {
        _mergeViewModel.DragItem = null;
    }
}
}