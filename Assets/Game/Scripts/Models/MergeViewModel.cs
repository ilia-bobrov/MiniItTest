using System.Collections.Generic;
using Game.Utils;
using Game.View.Merge;
using UnityEngine;

namespace Game.Models
{
public sealed class MergeViewModel
{
    public GridView GridView;
    public Dictionary<Index2, ItemView> InactiveItems;
    public Dictionary<Index2, ItemView> ActiveItems;
    
    public bool IsDrag => DragItem is not null;
    public ItemView DragItem;
    public Vector2 DragOriginItemPosition;
    
    public MergeScreenView MergeScreenView;
}
}