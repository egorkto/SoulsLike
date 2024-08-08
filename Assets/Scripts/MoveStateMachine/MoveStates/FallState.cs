public class FallState : InterruptedState
{
    public override string AnimatorTrigger { get { return "Fall"; } }

    public FallState(IMoveStateMachine stateMachine) : base(stateMachine) { }

    public override void Land()
    {
        StateMachine.SwitchState<LandState>();
    }

    protected override void OnEnter() { }
}