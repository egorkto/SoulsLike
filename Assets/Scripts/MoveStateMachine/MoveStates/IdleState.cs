public class IdleState : InterruptedState
{
    public override string AnimatorTrigger { get { return "Idle"; } }

    public IdleState(IMoveStateMachine stateMachine) : base(stateMachine) { }

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
        StateMachine.SwitchState<WalkState>();
    }

    public override void Crouch()
    {
        StateMachine.SwitchState<IdleCrouchState>();
    }

    public override void Dash()
    {
        StateMachine.SwitchState<JumpBackState>();
    }

    public override void Jump()
    {
        StateMachine.SwitchState<JumpState>();
    }

    public override void Attack()
    {
        StateMachine.SwitchState<ComboAttack1State>();
    }

    public override void Interact()
    {
        StateMachine.SwitchState<RemoveWeaponState>();
    }
}