using System.Collections.Generic;
using System.Numerics;
using Game.Ev;
using Game.GlobalStates;
using Game.Input;
using Game.Models;
using Game.View.Merge;
using UnityEngine;
using UnityEngine.EventSystems;
using Vector3 = UnityEngine.Vector3;

namespace Game.Systems.Logic.Merge
{
public class InputSystem : ISystem
{
    private readonly PlayerInput _playerInput;
    private readonly Events _events;
    private readonly MergeViewModel _mergeViewModel;
    private readonly List<RaycastResult> _cachedResults = new();

    public InputSystem(PlayerInput playerInput, Events events, MergeViewModel mergeViewModel)
    {
        _playerInput = playerInput;
        _events = events;
        _mergeViewModel = mergeViewModel;
    }

    public void Start() { }

    public void Update()
    {
        var pointerDownAction = _playerInput.MergeInput.ItemPointerDown;
        if (pointerDownAction.IsDown)
        {
            if (!_mergeViewModel.IsDrag)
            {
                _events.MergeEvents.DragStart = new MergeEvents.DragStartEvent
                {
                    IsStart = true,
                    ItemIndex = pointerDownAction.ItemIndex
                };
            }
        }

        var pointerUpAction = _playerInput.MergeInput.ItemPointerUp;
        if (pointerUpAction.IsUp)
        {
            if (_mergeViewModel.IsDrag)
            {
                EventSystem.current.RaycastAll(pointerUpAction.EventData, _cachedResults);
                foreach (var raycastResult in _cachedResults)
                {
                    if (raycastResult.gameObject.TryGetComponent<ItemView>(out var itemView) && itemView.Index != pointerUpAction.ItemIndex)
                    {
                        _events.MergeEvents.MergeIntention = new MergeEvents.MergeIntentionEvent
                        {
                            IsIntention = true,
                            MergingCell = pointerUpAction.ItemIndex,
                            TargetCell = itemView.Index
                        };
                    
                        break;
                    }
                }
            
                _events.MergeEvents.DragStop = new MergeEvents.DragStopEvent
                {
                    IsStop = true,
                    ItemIndex = pointerUpAction.ItemIndex
                };
            }
        }

        if (_playerInput.MergeInput.IsExit)
        {
            _events.ChangeGlobalState = new Events.ChangeGlobalStateEvent
            {
                IsChange = true,
                State = EGlobalState.MainMenu
            };
        }
    }

    public void Stop() { }
}
}