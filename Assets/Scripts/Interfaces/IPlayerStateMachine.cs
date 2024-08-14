public interface IPlayerStateMachine
{
    public StatesView View { get; }
    public IPlayerMover Mover { get; }
    public IPlayerRotator Rotator { get; }
    public void SwitchState<T>() where T : PlayerState;
}