using Timer = System.Timers.Timer;

public class ComboAttack2State : ComboAttackState
{
    public override string AnimatorStateName { get { return "ComboAttack2"; } }

    public ComboAttack2State(IPlayerStateMachine stateMachine, ComboTimer timer) : base(stateMachine, timer)
    {
    }

    protected override void SwitchToNextAttackState()
    {
        StateMachine.SwitchState<FinalComboAttackState>();
    }
}