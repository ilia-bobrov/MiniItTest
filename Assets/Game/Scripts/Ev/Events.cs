using Game.GlobalStates;

namespace Game.Ev
{
public sealed class Events
{
    public readonly MergeEvents MergeEvents =  new();
    
    public bool IsExitApp;
    public ChangeGlobalStateEvent ChangeGlobalState;

    public void Reset()
    {
        MergeEvents.Reset();
        IsExitApp = false;
        ChangeGlobalState.IsChange = false;
    }
    
    public struct ChangeGlobalStateEvent
    {
        public bool IsChange;
        public EGlobalState State;
    }
}
}