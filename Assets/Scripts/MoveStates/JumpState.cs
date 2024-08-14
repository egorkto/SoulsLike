public class JumpState : InterruptedState
{
    public override string AnimatorStateName { get { return "Jump"; } }

    private IPlayerMoveStats _stats;
    
    public JumpState(IPlayerStateMachine stateMachine, IPlayerMoveStats stats) : base(stateMachine) 
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
