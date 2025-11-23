using Game.Utils;
using UnityEngine.EventSystems;

namespace Game.Input
{
public sealed class MergeInput
{
    public ItemPointerDownAction ItemPointerDown;
    public ItemPointerUpAction ItemPointerUp;
    public bool IsExit;

    public void Reset()
    {
        ItemPointerDown.IsDown = false;
        ItemPointerUp.IsUp = false;
        IsExit = false;
    }

    public struct ItemPointerDownAction
    {
        public bool IsDown;
        public Index2 ItemIndex;
    }
    
    public struct ItemPointerUpAction
    {
        public bool IsUp;
        public Index2 ItemIndex;
        public PointerEventData EventData;
    }
}
}