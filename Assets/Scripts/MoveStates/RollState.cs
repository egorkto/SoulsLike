public class RollState : UninterruptedState
{
    public override string AnimatorStateName { get { return "Roll"; } }

    private IPlayerMoveStats _stats;

    public RollState(IPlayerStateMachine stateMachine, IPlayerMoveStats stats) : base(stateMachine) 
    { 
        _stats = stats;
    }

    protected override void Enter()
    {
        StateMachine.Mover.SetPlaneSpeed(_stats.RollForce);
    }

    protected override void Complete()
    {
        Exit();
    }
}