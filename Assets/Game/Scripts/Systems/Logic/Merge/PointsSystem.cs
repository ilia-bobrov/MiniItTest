using Game.Configs;
using Game.Ev;
using Game.Models;
using Game.Utils;

namespace Game.Systems.Logic.Merge
{
public class PointsSystem : ISystem
{
    private readonly MergeConfig _config;
    private readonly MergeModel _model;
    private readonly Events _events;

    public PointsSystem(MergeConfig config, MergeModel model, Events events)
    {
        _config = config;
        _model = model;
        _events = events;
    }

    public void Start()
    {
        _model.CurrentScore = 0;
    }

    public void Update()
    {
        var ev = _events.MergeEvents.Merge;
        if (!ev.IsMerged)
            return;

        var mergeLevel = ev.MergeLevel;
        var points = _config.MergePoints[mergeLevel - 1];
        _model.CurrentScore += points;
    }

    public void Stop() { }
}
}