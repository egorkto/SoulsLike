public class MoveJumpState : InterruptedState
{
    public override string AnimatorTrigger { get { return "MoveJump"; } }

    public MoveJumpState(IMoveStateMachine stateMachine) : base(stateMachine) { }

    protected override void OnEnter()
    {
        Mover.SetYSpeed(Stats.JumpForce);
    }
}