public class LandState : UninterruptedState
{
    public override string AnimatorStateName { get { return "Land"; } }

    public LandState(IPlayerStateMachine stateMachine) : base(stateMachine)  { }

    protected override void Enter()
    {
        StateMachine.Mover.SetVerticalSpeed(0);
        StateMachine.Mover.SetPlaneSpeed(0);
    }

    protected override void Complete()
    {
        Exit();
    }
}