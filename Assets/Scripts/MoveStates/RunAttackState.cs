public class RunAttackState : UninterruptedState
{
    public override string AnimatorStateName => "RunAttack";

    public RunAttackState(IPlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    protected override void Enter()
    {
        StateMachine.Mover.SetPlaneSpeed(0);
    }

    protected override void Complete()
    {
        Exit();
    }
}