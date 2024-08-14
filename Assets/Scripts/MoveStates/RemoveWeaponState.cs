public class RemoveWeaponState : UninterruptedState, IInteractionApplyerState
{
    public override string AnimatorStateName => "RemoveWeapon";

    private PlayerInteractionsHandler _interactionHandler;
    private WeaponView _holder;

    public RemoveWeaponState(IPlayerStateMachine stateMachine, PlayerInteractionsHandler interactionsHandler, WeaponView holder) : base(stateMachine) 
    { 
        _interactionHandler = interactionsHandler;
        _holder = holder;
    }

    protected override void Enter()
    {
        StateMachine.Mover.SetPlaneSpeed(0);
    }

    protected override void Complete()
    {
        _holder.HideWeapon();
        _interactionHandler.CurrentInteraction.ApplyInteractionState(this);
    }

    public void ApplyInteraction<T>() where T : InteractionState
    {
        StateMachine.SwitchState<T>();
    }
}