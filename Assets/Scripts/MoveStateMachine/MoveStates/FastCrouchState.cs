internal class FastCrouchState : InterruptedState
{
    public override string AnimatorTrigger { get { return "FastCrouch"; } }

    public FastCrouchState(IMoveStateMachine stateMachine) : base(stateMachine) { }

    protected override void OnEnter()
    {
        Mover.SetPlaneSpeed(Stats.FastCrouchSpeed);
    }

    public override void StopMove()
    {
        StateMachine.SwitchState<IdleCrouchState>();
    }

    public override void StopRun()
    {
        StateMachine.SwitchState<CrouchState>();
    }

    public override void Crouch()
    {
        StateMachine.SwitchState<RunState>();
    }

    public override void Jump()
    {
        StateMachine.SwitchState<MoveJumpState>();
    }

    public override void Dash()
    {
        StateMachine.SwitchState<RollState>();
    }
}