using System;
using UnityEngine;

namespace Game.Configs
{
[CreateAssetMenu(fileName = "MergeConfig", menuName = "Game/Configs/MergeConfig", order = 0)] [Serializable]
public sealed class MergeConfig : ScriptableObject
{
    [field: SerializeField, Min(0)] public int GridSizeX { get; private set; }
    [field: SerializeField, Min(0)] public int GridSizeY { get; private set; }
    [field: SerializeField, Min(0)] public float SpawnTime { get; private set; }
    [field: SerializeField, Min(0)] public int MergeLevels { get; private set; }
    [field: SerializeField] public int[] MergePoints { get; private set; }
    [field: Space, Header("Grid view settings")]
    [field: SerializeField, Min(0)] public float CellSize { get; private set; }
    [field: SerializeField, Min(0)] public float GapFromScreenEdge { get; private set; }
    [field: SerializeField, Min(0)] public float BorderThickness { get; private set; }
    [field: Space, Header("Items view settings")]
    [field: SerializeField, Min(0)] public float ItemSize { get; private set; }
    [field: SerializeField, Min(0)] public float ItemDragSize { get; private set; }
    [field: SerializeField, Min(0)] public int ItemLayerOrder { get; private set; }
    [field: SerializeField, Min(0)] public int ItemDragLayerOrder { get; private set; }
}
}