public class RemoveWeaponState : UninterruptedState
{
    public override string AnimatorTrigger => throw new System.NotImplementedException();

    private PlayerInteractionsHandler _interactionHandler;

    public RemoveWeaponState(IMoveStateMachine stateMachine, IPlayerRotator rotator, PlayerInteractionsHandler interactionsHandler) : base(stateMachine, rotator) 
    { 
        _interactionHandler = interactionsHandler;
    }

    public override void Complete()
    {
        //StateMachine.GetType().GetMethod(nameof(StateMachine.SwitchState)).MakeGenericMethod(_interactionHandler.CurrentObject.InterractionType).Invoke(StateMachine, null);
    }

    protected override void OnEnter()
    {
        Mover.SetPlaneSpeed(0);
    }
}