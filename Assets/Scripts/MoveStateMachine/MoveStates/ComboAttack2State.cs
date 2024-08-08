public class ComboAttack2State : ComboAttackState
{
    public override string AnimatorTrigger { get { return "ComboAttack2"; } }

    public ComboAttack2State(IMoveStateMachine stateMachine, IPlayerRotator rotator, ComboAttackTimer attacker) : base(stateMachine, rotator, attacker)
    {
    }

    protected override void SwitchToNextAttackState()
    {
        StateMachine.SwitchState<FinalComboAttackState>();
    }
}