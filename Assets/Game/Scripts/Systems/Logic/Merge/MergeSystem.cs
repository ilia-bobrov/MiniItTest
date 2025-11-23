using Game.Configs;
using Game.Ev;
using Game.Models;
using Game.Utils;
using UnityEngine;

namespace Game.Systems.Logic.Merge
{
public class MergeSystem : ISystem
{
    private readonly MergeConfig _config;
    private readonly MergeModel _model;
    private readonly Events _events;

    public MergeSystem(MergeConfig config, MergeModel model, Events events)
    {
        _config = config;
        _model = model;
        _events = events;
    }

    public void Start() { }

    public void Update()
    {
        var ev = _events.MergeEvents.MergeIntention;
        if (!ev.IsIntention)
            return;
        
        var mergingCellIndex = ev.MergingCell;
        var mergingCell = _model.Grid[mergingCellIndex.x, mergingCellIndex.y];
        if (mergingCell.Level == 0)
            return;
            
        var targetCellIndex = ev.TargetCell;
        var targetCell = _model.Grid[targetCellIndex.x, targetCellIndex.y];
        if (targetCell.Level == 0)
            return;
        
        if(mergingCell.Level != targetCell.Level)
            return;

        _model.Grid[mergingCellIndex.x, mergingCellIndex.y].Level = 0;
        _model.FreeCells.Add(ArrayUtils.IndexToNumber2DArray(mergingCellIndex, _model.GridSize.x));
        
        var oldLevel = targetCell.Level;
        var newLevel = oldLevel + 1;
        if (newLevel > _config.MergeLevels)
        {
            _model.Grid[targetCellIndex.x, targetCellIndex.y].Level = 0;
            _model.FreeCells.Add(ArrayUtils.IndexToNumber2DArray(targetCellIndex, _model.GridSize.x));
            newLevel = 0;
        }
        else
        {
            _model.Grid[targetCellIndex.x, targetCellIndex.y].Level = newLevel;
        }

        _events.MergeEvents.Merge = new MergeEvents.MergeEvent
        {
            IsMerged = true,
            MergingCell = mergingCellIndex,
            TargetCell = targetCellIndex,
            MergeLevel = oldLevel,
            NewLevel = newLevel
        };
    }

    public void Stop() { }
}
}