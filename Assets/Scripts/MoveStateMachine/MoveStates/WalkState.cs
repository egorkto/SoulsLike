using UnityEngine;

public class WalkState : InterruptedState
{
    public override string AnimatorTrigger { get { return "Walk"; } }

    public WalkState(IMoveStateMachine stateMachine) : base(stateMachine) { }

    protected override void OnEnter()
    {
        Mover.SetPlaneSpeed(Stats.WalkSpeed);
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
}
