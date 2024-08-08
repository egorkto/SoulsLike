using System;

public abstract class UninterruptedState : PlayerState, IUninterruptedState
{
    protected IPlayerRotator Rotator => _rotator;

    private readonly IPlayerRotator _rotator;
    private Type _nextState;

    protected UninterruptedState(IMoveStateMachine stateMachine, IPlayerRotator rotator) : base(stateMachine) 
    {
        _rotator = rotator;
        _nextState = typeof(IdleState);
    }

    protected override void Animate()
    {
        StateMachine.Animator.Animate(this);
    }

    protected override abstract void OnEnter();

    protected void Exit()
    {
        StateMachine.GetType().GetMethod(nameof(StateMachine.SwitchState)).MakeGenericMethod(_nextState).Invoke(StateMachine, null);
    }

    public abstract void Complete();

    public override void Fall()
    {
        _nextState = typeof(FallState);
    }

    public override void Land()
    {
        _nextState = typeof(IdleState);
    }
}
