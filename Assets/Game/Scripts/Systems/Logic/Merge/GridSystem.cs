using System.Collections.Generic;
using Game.Configs;
using Game.Models;

namespace Game.Systems.Logic.Merge
{
public class GridSystem : ISystem
{
    private readonly MergeConfig _config;
    private readonly MergeModel _model;

    public GridSystem(MergeConfig config, MergeModel model)
    {
        _config = config;
        _model = model;
    }

    public void Start()
    {
        _model.Grid = new MergeModel.GridCell[_config.GridSizeX, _config.GridSizeY];
        var capacity = _config.GridSizeX * _config.GridSizeY;
        _model.FreeCells = new List<int>(capacity);
        for (int i = 0; i < capacity; i++)
        {
            _model.FreeCells.Add(i);
        }
    }

    public void Update()
    {
        
    }

    public void Stop()
    {
        _model.Grid = null;
        _model.FreeCells = null;
    }
}
}