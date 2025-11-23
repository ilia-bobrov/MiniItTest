using Game.Utils;

namespace Game.Ev
{
public sealed class MergeEvents
{
    public SpawnEvent Spawn;
    public MergeIntentionEvent MergeIntention;
    public MergeEvent Merge;
    public DragStartEvent DragStart;
    public DragStopEvent DragStop;
    
    public void Reset()
    {
        Spawn.IsSpawned = false;
        MergeIntention.IsIntention = false;
        Merge.IsMerged = false;
        DragStart.IsStart = false;
        DragStop.IsStop = false;
    }

    public struct SpawnEvent
    {
        public bool IsSpawned;
        public Index2 Cell;
    }
    
    public struct MergeIntentionEvent
    {
        public bool IsIntention;
        public Index2 MergingCell;
        public Index2 TargetCell;
    }
    
    public struct MergeEvent
    {
        public bool IsMerged;
        public Index2 MergingCell;
        public Index2 TargetCell;
        public int MergeLevel;
        public int NewLevel;
    }
    
    public struct DragStartEvent
    {
        public bool IsStart;
        public Index2 ItemIndex;
    }
    
    public struct DragStopEvent
    {
        public bool IsStop;
        public Index2 ItemIndex;
    }
}
}