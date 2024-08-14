public class FallState : InterruptedState
{
    public override string AnimatorStateName { get { return "Fall"; } }

    public FallState(IPlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void OnEnter() { }

    public override void Land()
    {
        StateMachine.SwitchState<LandState>();
    }

    public override void Attack()
    {
        StateMachine.SwitchState<FallAttack>();
    }
}