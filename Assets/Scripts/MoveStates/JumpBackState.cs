public class JumpBackState : UninterruptedState
{
    public override string AnimatorStateName { get { return "JumpBack"; } }

    private IPlayerMoveStats _stats;

    public JumpBackState(IPlayerStateMachine stateMachine, IPlayerMoveStats stats) : base(stateMachine) 
    { 
        _stats = stats;
    }

    protected override void Enter()
    {
        StateMachine.Mover.SetPlaneSpeed(-_stats.JumpBackForce);
    }

    protected override void Complete()
    {
        Exit();
    }
}