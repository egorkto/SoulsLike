public class JumpState : InterruptedState
{
    public override string AnimatorTrigger { get { return "Jump"; } }

    public JumpState(IMoveStateMachine stateMachine) : base(stateMachine) { }

    protected override void OnEnter()
    {
        Mover.SetYSpeed(Stats.JumpForce);
    }
}
