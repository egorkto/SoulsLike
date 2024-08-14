using UnityEngine;

public class WalkState : InterruptedState
{
    public override string AnimatorStateName { get { return "Walk"; } }

    private IPlayerMoveStats _stats;

    public WalkState(IPlayerStateMachine stateMachine, IPlayerMoveStats stats) : base(stateMachine) 
    { 
        _stats = stats;
    }

    public override void OnEnter()
    {
        StateMachine.Mover.SetPlaneSpeed(_stats.WalkSpeed);
    }

    public override void StartRun()
    {
        StateMachine.SwitchState<RunState>();
    }

    public override void Crouch()
    {
        StateMachine.SwitchState<CrouchState>();
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

    public override void Attack()
    {
        StateMachine.SwitchState<ComboAttack1State>();
    }
}
