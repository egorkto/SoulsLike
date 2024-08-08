public abstract class InterruptedState : PlayerState, IInterruptedState
{
    public InterruptedState(IMoveStateMachine stateMachine) : base(stateMachine) { }

    protected override void Animate()
    {
        StateMachine.Animator.Animate(this);
    }

    protected override abstract void OnEnter();

    public override void Fall()
    {
        StateMachine.SwitchState<FallState>();
    }
}
