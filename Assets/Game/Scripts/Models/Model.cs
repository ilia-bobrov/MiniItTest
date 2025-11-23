using Game.GlobalStates;

namespace Game.Models
{
public sealed class Model
{
    public readonly MergeModel MergeModel = new();
    
    public EGlobalState GlobalState;
}
}