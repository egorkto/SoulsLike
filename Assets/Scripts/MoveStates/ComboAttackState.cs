using UnityEngine;

public abstract class ComboAttackState : UninterruptedState
{
    public override string AnimatorStateName { get { return ""; } }

    private ComboTimer _timer;
    private bool _completeAttack = false;

    public ComboAttackState(IPlayerStateMachine stateMachine, ComboTimer timer) : base(stateMachine)
    {
        _timer = timer;
        _timer.Elapsed += StopCombo;
    }

    ~ComboAttackState() 
    {
        _timer.Elapsed -= StopCombo;
    }

    protected virtual void SwitchToNextAttackState() { }

    public override void Attack()
    {
        if (TryExit())
        {
            SwitchToNextAttackState();
        }
    }

    protected override void Enter()
    {
        StateMachine.Mover.SetPlaneSpeed(0);
        _completeAttack = false;
    }

    protected override void Complete()
    {
        _completeAttack = true;
        _timer.StartTimer();
    }

    private void StopCombo()
    {
        StateMachine.SwitchState<IdleState>();
    }

    private bool TryExit() 
    {
        if(_completeAttack)
        {
            _timer.StopTimer();
            return true;
        }
        return false;
    }
}
