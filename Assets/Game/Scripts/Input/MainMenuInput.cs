namespace Game.Input
{
public sealed class MainMenuInput
{
    public bool IsExit;
    public bool IsMatch3;
    public bool IsMerge;
    public bool IsArkanoid;
        
    public void Reset()
    {
        IsExit = false;
        IsMatch3 = false;
        IsMerge = false;
        IsArkanoid = false;
    }
}
}