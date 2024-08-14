public abstract class InteractionState : UninterruptedState
{
    public override abstract string AnimatorStateName { get; }

    private IInteraction _interaction;

    public InteractionState(IPlayerStateMachine stateMachine, IInteraction interaction) : base(stateMachine)
    {
        _interaction = interaction;
    }

    ~InteractionState() 
    {
        _interaction.Finished -= OnInteractionFinished;
    }

    protected override sealed void Enter()
    {
        StateMachine.Mover.SetPlaneSpeed(0);
    }

    protected override void Complete()
    {
        _interaction.StartInteraction();
        _interaction.Finished += OnInteractionFinished;
    }

    public void OnInteractionFinished()
    {
        _interaction.Finished -= OnInteractionFinished;
        StateMachine.SwitchState<GetWeaponState>();
    }
}