using UnityEngine;

public class IdleState : InterruptedState
{
    public override string AnimatorStateName => "Idle";

    public IdleState(IPlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void OnEnter()
    {
        StateMachine.Mover.SetPlaneSpeed(0);
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