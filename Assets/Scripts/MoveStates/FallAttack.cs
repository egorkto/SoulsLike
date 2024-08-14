public class FallAttack : UninterruptedState
{
    public override string AnimatorStateName => "FallAttack";

    private bool _landed;

    public FallAttack(IPlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Land()
    {
        _landed = true;
    }

    protected override void Enter()
    {
        StateMachine.Mover.SetPlaneSpeed(0);
        _landed = false;
    }

    protected override void Complete()
    {
        if(_landed)
            StateMachine.SwitchState<IdleState>();
        else
            StateMachine.SwitchState<FallState>();
    }
}