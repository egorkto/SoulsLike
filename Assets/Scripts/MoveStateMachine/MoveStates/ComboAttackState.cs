public abstract class ComboAttackState : UninterruptedState, IComboAttackState
{
    public override string AnimatorTrigger { get { return ""; } }

    private ComboAttackTimer _attacker;
    private bool _completeAttack = false;

    public ComboAttackState(IMoveStateMachine stateMachine, IPlayerRotator rotator, ComboAttackTimer attacker) : base(stateMachine, rotator)
    {
        _attacker = attacker;
    }

    protected virtual void SwitchToNextAttackState() { }

    protected override void OnEnter()
    {
        _completeAttack = false;
        Rotator.SetRotating(false);
    }

    public override void Complete()
    {
        Rotator.SetRotating(true);
        _completeAttack = true;
        _attacker.WaitForNextAttack(this);
    }

    public void StopCombo()
    {
        Exit();
    }

    public override void Dash()
    {
        if (_completeAttack)
        {
            _attacker.StopAllCoroutines();
            if(StateMachine.IsMoving)
                StateMachine.SwitchState<RollState>();
            else
                StateMachine.SwitchState<JumpBackState>();
        }
    }

    public override void Attack()
    {
        if (_completeAttack)
        {
            _attacker.StopAllCoroutines();
            SwitchToNextAttackState();
        }
    }
}
