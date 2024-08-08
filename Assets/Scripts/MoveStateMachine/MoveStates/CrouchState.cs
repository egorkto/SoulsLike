internal class CrouchState : InterruptedState
{
    public override string AnimatorTrigger { get { return "Crouch"; } }

    public CrouchState(IMoveStateMachine stateMachine) : base(stateMachine) { }

    protected override void OnEnter()
    {
        Mover.SetPlaneSpeed(Stats.CrouchSpeed);
    }

    protected override bool TryTransition()
    {
        if (StateMachine.IsRunning)
        {
            StartRun();
            return true;
        }
        return false;
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