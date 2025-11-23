namespace Game.GlobalStates
{
public interface IGlobalState
{
    public void Enter();
    public void Update();
    public void Exit();
}
}