public class JumpBackState : UninterruptedState
{
    public override string AnimatorTrigger { get { return "JumpBack"; } }

    public JumpBackState(IMoveStateMachine stateMachine, IPlayerRotator rotator) : base(stateMachine, rotator) { }

    public override void Complete()
    {
        Rotator.SetRotating(true);
        Exit();
    }

    protected override void OnEnter()
    {
        Mover.SetPlaneSpeed(-Stats.JumpBackForce);
        Rotator.SetRotating(false);
    }
}