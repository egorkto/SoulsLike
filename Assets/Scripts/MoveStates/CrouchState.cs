internal class CrouchState : InterruptedState
{
    public override string AnimatorStateName { get { return "Crouch"; } }

    private IPlayerMoveStats _stats;

    public CrouchState(IPlayerStateMachine stateMachine, IPlayerMoveStats stats) : base(stateMachine) 
    { 
        _stats = stats;
    }

    public override void OnEnter()
    {
        StateMachine.Mover.SetPlaneSpeed(_stats.CrouchSpeed);
    }

    public override void StopMove()
    {
        StateMachine.SwitchState<IdleCrouchState>();
    }

    public override void StartRun()
    {
        StateMachine.SwitchState<FastCrouchState>();
    }

    public override void Crouch()
    {
        StateMachine.SwitchState<WalkState>();
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