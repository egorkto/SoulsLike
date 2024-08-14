using System;

public abstract class UninterruptedState : PlayerState
{
    private Type _nextState;

    protected UninterruptedState(IPlayerStateMachine stateMachine) : base(stateMachine) 
    {
        _nextState = typeof(IdleState);
    }

    public override sealed void OnEnter()
    {
        StateMachine.Rotator.SetRotating(false);
        Enter();
    }

    public override void OnAnimationComplete()
    {
        StateMachine.Rotator.SetRotating(true);
        Complete();
    }

    protected abstract void Enter();

    protected abstract void Complete();

    protected void Exit()
    {
        StateMachine.GetType().GetMethod(nameof(StateMachine.SwitchState)).MakeGenericMethod(_nextState).Invoke(StateMachine, null);
    }

    public override void Fall()
    {
        _nextState = typeof(FallState);
    }

    public override void Land()
    {
        _nextState = typeof(IdleState);
    }
}