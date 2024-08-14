internal class FastCrouchState : InterruptedState
{
    public override string AnimatorStateName { get { return "FastCrouch"; } }

    private IPlayerMoveStats _stats;

    public FastCrouchState(IPlayerStateMachine stateMachine, IPlayerMoveStats stats) : base(stateMachine) 
    { 
        _stats = stats;
    }

    public override void OnEnter()
    {
        StateMachine.Mover.SetPlaneSpeed(_stats.FastCrouchSpeed);
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