public class RunState : InterruptedState
{
    public override string AnimatorTrigger { get { return "Run"; } }

    public RunState(IMoveStateMachine stateMachine) : base(stateMachine) { }

    protected override void OnEnter()
    {
        Mover.SetPlaneSpeed(Stats.RunSpeed);
    }

    public override void StopRun()
    {
        StateMachine.SwitchState<WalkState>();
    }

    public override void Crouch()
    {
        StateMachine.SwitchState<FastCrouchState>();
    }

    public override void Dash()
    {
        StateMachine.SwitchState<RollState>();
    }

    public override void Jump()
    {
        StateMachine.SwitchState<MoveJumpState>();
    }

    public override void StopMove()
    {
        StateMachine.SwitchState<IdleState>();
    }
}