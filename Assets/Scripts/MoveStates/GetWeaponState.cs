public class GetWeaponState : UninterruptedState
{
    public override string AnimatorStateName => "GetWeapon";

    private WeaponView _holder;

    public GetWeaponState(IPlayerStateMachine stateMachine, WeaponView holder) : base(stateMachine)
    {
        _holder = holder;
    }

    protected override void Enter() { }

    protected override void Complete()
    {
        _holder.ShowWeapon();
        StateMachine.SwitchState<IdleState>();
    }
}