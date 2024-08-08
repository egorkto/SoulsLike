public class LandState : UninterruptedState
{
    public override string AnimatorTrigger { get { return "Land"; } }

    public LandState(IMoveStateMachine stateMachine, IPlayerRotator rotator) : base(stateMachine, rotator)  { }

    public override void Complete()
    {
        Rotator.SetRotating(true);
        Exit();
    }

    protected override void OnEnter()
    {
        Mover.SetYSpeed(0);
        Mover.SetPlaneSpeed(0);
        Rotator.SetRotating(false);
    }
}