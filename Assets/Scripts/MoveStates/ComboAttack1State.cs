public class ComboAttack1State : ComboAttackState
{
    public override string AnimatorStateName { get { return "ComboAttack1"; } }

    public ComboAttack1State(IPlayerStateMachine stateMachine, ComboTimer timer) : base(stateMachine, timer)
    {
    }

    protected override void SwitchToNextAttackState()
    {
        StateMachine.SwitchState<ComboAttack2State>();
    }
}