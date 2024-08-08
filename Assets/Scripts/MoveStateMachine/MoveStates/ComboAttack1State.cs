public class ComboAttack1State : ComboAttackState
{
    public override string AnimatorTrigger { get { return "ComboAttack1"; } }

    public ComboAttack1State(IMoveStateMachine stateMachine, IPlayerRotator rotator, ComboAttackTimer attacker) : base(stateMachine, rotator, attacker)
    {
    }

    protected override void SwitchToNextAttackState()
    {
        StateMachine.SwitchState<ComboAttack2State>();
    }
}