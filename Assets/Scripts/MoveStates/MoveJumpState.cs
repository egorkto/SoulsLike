public class MoveJumpState : InterruptedState
{
    public override string AnimatorStateName { get { return "MoveJump"; } }

    private IPlayerMoveStats _stats;

    public MoveJumpState(IPlayerStateMachine stateMachine, IPlayerMoveStats stats) : base(stateMachine) 
    { 
        _stats = stats;
    }

    public override void OnEnter()
    {
        StateMachine.Mover.SetVerticalSpeed(_stats.JumpForce);
    }

    public override void Attack()
    {
        StateMachine.SwitchState<FallAttack>();
    }
}