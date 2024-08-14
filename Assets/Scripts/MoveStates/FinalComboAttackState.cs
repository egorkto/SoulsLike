public class FinalComboAttackState : UninterruptedState
{
    public override string AnimatorStateName { get { return "FinalComboAttack"; } }

    public FinalComboAttackState(IPlayerStateMachine stateMachine) : base(stateMachine) { }

    protected override void Enter()
    {
        StateMachine.Mover.SetPlaneSpeed(0);
    }
    
    protected override void Complete()
    {
        Exit();
    }
}