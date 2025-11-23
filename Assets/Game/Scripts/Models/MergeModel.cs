using System.Collections.Generic;
using Game.Utils;

namespace Game.Models
{
public sealed class MergeModel
{
    private GridCell[,] _grid;
    public GridCell[,] Grid
    {
        get => _grid;
        set
        {
            _grid = value;
            if (value == null) 
                return;
            
            GridSize = new Index2 (_grid.GetLength(0), _grid.GetLength(1));
            GridTotalSize = _grid.GetLength(0) * _grid.GetLength(1);
        }
    }
    
    public Index2 GridSize { get; private set; }
    public int GridTotalSize { get; private set; }
    public List<int> FreeCells;
    public int RecordScore;
    public int CurrentScore;
    public float SpawnTimer;

    public struct GridCell
    {
        public int Level;
    }
}
}