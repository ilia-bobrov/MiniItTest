using Game.Configs;
using Game.Ev;
using Game.Models;
using Game.Utils;
using UnityEngine;

namespace Game.Systems.Logic.Merge
{
public class SpawnSystem : ISystem
{
    private readonly MergeConfig _config;
    private readonly MergeModel _model;
    private readonly Events _events;

    public SpawnSystem(MergeConfig config, MergeModel model, Events events)
    {
        _config = config;
        _model = model;
        _events = events;
    }

    public void Start()
    {
        _model.SpawnTimer = _config.SpawnTime;
    }

    public void Update()
    {
        if (_model.SpawnTimer > 0)
        {
            _model.SpawnTimer -= Time.deltaTime;
        }
        
        if (_model.SpawnTimer <= 0 && _model.FreeCells.Count > 0)
        {
            _model.SpawnTimer = _config.SpawnTime;
            var randomIndex = Random.Range(0, _model.FreeCells.Count);
            var randomValue = _model.FreeCells[randomIndex];
            
            var lastValue = _model.FreeCells[^1];
            _model.FreeCells[randomIndex] = lastValue;
            _model.FreeCells[^1] = randomValue;
            _model.FreeCells.RemoveAt(_model.FreeCells.Count - 1);
            
            var index = ArrayUtils.NumberToIndex2DArray(randomValue, _model.GridSize.x);
            _model.Grid[index.x, index.y].Level = 1;

            _events.MergeEvents.Spawn = new MergeEvents.SpawnEvent
            {
                IsSpawned = true,
                Cell = index
            };
        }
    }

    public void Stop()
    {
        
    }
}
}