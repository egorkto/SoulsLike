public class IdleCrouchState : InterruptedState
{
    public override string AnimatorStateName { get { return "IdleCrouch"; } }

    public IdleCrouchState(IPlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void OnEnter()
    {
        StateMachine.Mover.SetPlaneSpeed(0);
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