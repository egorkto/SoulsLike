public interface IMoveStateMachine
{
    public PlayerMover Mover { get; }
    public StateAnimator Animator { get; }
    public IPlayerMoveStats Stats { get; }
    public bool IsRunning { get; }
    public bool IsMoving { get; }
    public void SwitchState<T>() where T : PlayerState;
}