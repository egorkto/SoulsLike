public class FinalComboAttackState : UninterruptedState
{
    public override string AnimatorTrigger { get { return "FinalComboAttack"; } }

    public FinalComboAttackState(IMoveStateMachine stateMachine, IPlayerRotator rotator) : base(stateMachine, rotator) { }

    protected override void OnEnter()
    {
        Rotator.SetRotating(false);
    }

    public override void Complete()
    {
        Rotator.SetRotating(true);
        Exit();
    }
}