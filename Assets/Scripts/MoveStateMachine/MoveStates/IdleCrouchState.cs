public class IdleCrouchState : InterruptedState
{
    public override string AnimatorTrigger { get { return "IdleCrouch"; } }

    public IdleCrouchState(IMoveStateMachine stateMachine) : base(stateMachine) { }

    protected override void OnEnter()
    {
        Mover.SetPlaneSpeed(0);
    }

    protected override bool TryTransition()
    {
        if (StateMachine.IsMoving)
        {
            StartMove();
            return true;
        }
        return false;
    }

    public override void StartMove()
    {
        StateMachine.SwitchState<CrouchState>();
    }

    public override void Crouch()
    {
        StateMachine.SwitchState<IdleState>();
    }

    public override void Jump()
    {
        StateMachine.SwitchState<JumpState>();
    }

    public override void Dash()
    {
        StateMachine.SwitchState<JumpBackState>();
    }
}