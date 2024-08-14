public class RunState : InterruptedState
{
    public override string AnimatorStateName { get { return "Run"; } }

    private IPlayerMoveStats _stats;

    public RunState(IPlayerStateMachine stateMachine, IPlayerMoveStats stats) : base(stateMachine) 
    { 
        _stats = stats;
    }

    public override void OnEnter()
    {
        StateMachine.Mover.SetPlaneSpeed(_stats.RunSpeed);
    }

    public override void StopRun()
    {
        StateMachine.SwitchState<WalkState>();
    }

    public override void Crouch()
    {
        StateMachine.SwitchState<FastCrouchState>();
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
        StateMachine.SwitchState<RunAttackState>();
    }
}